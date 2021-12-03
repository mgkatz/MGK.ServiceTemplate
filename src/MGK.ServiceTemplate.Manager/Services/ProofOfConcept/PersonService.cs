using MGK.Acceptance;
using MGK.Extensions;
using MGK.ServiceBase.Services.Infrastructure.Exceptions;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.Infrastructure.UnitOfWork;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.SeedWork;
using MGK.ServiceTemplate.Manager.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.Manager.Services.ProofOfConcept
{
	public class PersonService : ManagerServiceBase<PersonService>, IPersonService
	{
		public PersonService(
			IManagerInternalServices<PersonService> internalServices)
			: base(internalServices)
		{
		}

		private IPersonQueryConstructor PersonQueryConstructor
			=> DataAccessServiceProvider.Get<IPersonQueryConstructor>();

		private IProofOfConceptUoW ProofOfConceptUoW
			=> DataAccessServiceProvider.Get<IProofOfConceptUoW>();

		public async Task<PersonDto> AddPersonAsync(AddPersonDto addPersonDto, CancellationToken cancellationToken = default)
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
			await ProofOfConceptUoW.CommitChangesAsync(cancellationToken);

			return Mapper.Map<PersonDto>(person);
		}

		public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
			=> await PersonQueryConstructor
				.Start()
				.OrderByFullName()
				.QueryAsArrayAsync<PersonDto>();

		public async Task<PersonDto> GetPersonByIdAsync(Guid personId)
			=> await PersonQueryConstructor
				.Start()
				.FilterById(personId)
				.GetRecordAsync<PersonDto>();

		public async Task<PersonDto> RemovePerson(Guid personId, CancellationToken cancellationToken = default)
		{
			var personDto = await GetPersonByIdAsync(personId);

			if (personDto == null)
			{
				Raise.Error.Generic<ServiceValidationException>(
					ManagerResources.MessagesResources.ErrorPersonNotExists,
					ManagerResources.MessagesResources.ErrorPersonNotExistsDetails.Format(personId));
			}

			ProofOfConceptUoW.RemoveByIds<Person>(personId);
			await ProofOfConceptUoW.CommitChangesAsync(cancellationToken);

			return personDto;
		}

		public async Task<PersonDto> UpdatePerson(PersonDto personDto, CancellationToken cancellationToken = default)
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

			await ProofOfConceptUoW.CommitChangesAsync(cancellationToken);

			return Mapper.Map(person, personDto);
		}
	}
}
