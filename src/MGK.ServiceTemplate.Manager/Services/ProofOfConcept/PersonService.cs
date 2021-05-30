using MGK.Acceptance;
using MGK.Extensions;
using MGK.ServiceBase.Services.Infrastructure.Exceptions;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.Infrastructure.UnitOfWork;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.ServiceProviders;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.SeedWork;
using MGK.ServiceTemplate.Manager.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.Manager.Services.ProofOfConcept
{
	public class PersonService : ManagerServiceBase<PersonService>, IPersonService
	{
		private readonly IDataAccessServiceProvider _dataAccessServiceProvider;

		public PersonService(
			IDataAccessServiceProvider dataAccessServiceProvider,
			IManagerInternalServices<PersonService> internalServices)
			: base(internalServices)
		{
			Ensure.Parameter.IsNotNull(dataAccessServiceProvider, nameof(dataAccessServiceProvider));

			_dataAccessServiceProvider = dataAccessServiceProvider;
		}

		private IPersonQueryConstructor PersonQueryConstructor
			=> _dataAccessServiceProvider.Get<IPersonQueryConstructor>();

		private IProofOfConceptUoW ProofOfConceptUoW
			=> _dataAccessServiceProvider.Get<IProofOfConceptUoW>();

		public async Task<PersonDto> AddPersonAsync(AddPersonDto addPersonDto)
		{
			Ensure.Parameter.IsNotNull(addPersonDto, nameof(addPersonDto));

			var person = await PersonQueryConstructor
				.Start()
				.FilterByDocumentNumber(addPersonDto.DocumentNumber)
				.GetRecordAsync();

			if (person != null)
			{
				Raise.Error.Generic<ServiceValidationException>(
					ManagerResources.MessagesResources.ErrorPersonAlreadyExists,
					ManagerResources.MessagesResources.ErrorPersonAlreadyExistsDetails.Format(addPersonDto.DocumentNumber));
			}

			person = ProofOfConceptUoW.Add(Mapper.Map<Person>(addPersonDto));
			await ProofOfConceptUoW.CommitChangesAsync();

			return Mapper.Map<PersonDto>(person);
		}

		public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
		{
			return await PersonQueryConstructor
				.Start()
				.OrderByFullName()
				.QueryAsArrayAsync<PersonDto>();
		}

		public async Task<PersonDto> GetPersonByIdAsync(Guid personId)
		{
			return await PersonQueryConstructor
				.Start()
				.FilterById(personId)
				.GetRecordAsync<PersonDto>();
		}

		public async Task<PersonDto> RemovePerson(Guid personId)
		{
			var personDto = await GetPersonByIdAsync(personId);

			if (personDto == null)
			{
				Raise.Error.Generic<ServiceValidationException>(
					ManagerResources.MessagesResources.ErrorPersonNotExists,
					ManagerResources.MessagesResources.ErrorPersonNotExistsDetails.Format(personId));
			}

			ProofOfConceptUoW.RemoveByIds<Person>(personId);
			await ProofOfConceptUoW.CommitChangesAsync();

			return personDto;
		}

		public async Task<PersonDto> UpdatePerson(PersonDto personDto)
		{
			Ensure.Parameter.IsNotNull(personDto, nameof(personDto));

			var person = await PersonQueryConstructor
				.Start()
				.FilterById(personDto.PersonId)
				.GetRecordAsync(true);

			if (person == null)
			{
				Raise.Error.Generic<ServiceValidationException>(
					ManagerResources.MessagesResources.ErrorPersonNotExists,
					ManagerResources.MessagesResources.ErrorPersonNotExistsDetails.Format(personDto.PersonId));
			}

			person.Name = personDto.Name;
			person.Surname = personDto.Surname;
			person.LastUpdateDate = DateTime.UtcNow;

			await ProofOfConceptUoW.CommitChangesAsync();

			return Mapper.Map(person, personDto);
		}
	}
}
