using AutoMapper;
using MGK.Acceptance;
using MGK.Extensions;
using MGK.ServiceBase.Infrastructure.Exceptions;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.Infrastructure.UnitOfWork;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.Manager.Services.ProofOfConcept
{
	public class PersonService : IPersonService
	{
		private readonly IProofOfConceptUoW _proofOfConceptUoW;
		private readonly IPersonQueryBuilder _personQueryBuilder;
		private readonly IMapper _mapper;

		public PersonService(
			IProofOfConceptUoW proofOfConceptUoW,
			IPersonQueryBuilder personQueryBuilder,
			IMapper mapper)
		{
			Ensure.Parameter.IsNotNull(proofOfConceptUoW, nameof(proofOfConceptUoW));
			Ensure.Parameter.IsNotNull(personQueryBuilder, nameof(personQueryBuilder));
			Ensure.Parameter.IsNotNull(mapper, nameof(mapper));

			_proofOfConceptUoW = proofOfConceptUoW;
			_personQueryBuilder = personQueryBuilder;
			_mapper = mapper;
		}

		public async Task<PersonDto> AddPersonAsync(AddPersonDto addPersonDto)
		{
			Ensure.Parameter.IsNotNull(addPersonDto, nameof(addPersonDto));

			var person = await _personQueryBuilder
				.Start()
				.FilterByDocumentNumber(addPersonDto.DocumentNumber)
				.GetRecordAsync();

			if (person != null)
			{
				Raise.Error.Generic<ServiceValidationException>(
					ManagerResources.MessagesResources.ErrorPersonAlreadyExists,
					ManagerResources.MessagesResources.ErrorPersonAlreadyExistsDetails.Format(addPersonDto.DocumentNumber));
			}

			person = _proofOfConceptUoW.Add(_mapper.Map<Person>(addPersonDto));
			await _proofOfConceptUoW.CommitChangesAsync();

			return _mapper.Map<PersonDto>(person);
		}

		public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
		{
			return await _personQueryBuilder
				.Start()
				.OrderByFullName()
				.QueryAsArrayAsync<PersonDto>();
		}

		public async Task<PersonDto> GetPersonByIdAsync(Guid personId)
		{
			return await _personQueryBuilder
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

			_proofOfConceptUoW.RemoveByIds<Person>(personId);
			await _proofOfConceptUoW.CommitChangesAsync();

			return personDto;
		}

		public async Task<PersonDto> UpdatePerson(PersonDto personDto)
		{
			Ensure.Parameter.IsNotNull(personDto, nameof(personDto));

			var person = await _personQueryBuilder
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

			await _proofOfConceptUoW.CommitChangesAsync();

			return _mapper.Map(person, personDto);
		}
	}
}
