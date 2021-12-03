using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept
{
	public interface IPersonService : IManagerService
	{
		Task<PersonDto> AddPersonAsync(AddPersonDto personDto, CancellationToken cancellationToken = default);

		Task<IEnumerable<PersonDto>> GetAllPersonsAsync();

		Task<PersonDto> GetPersonByIdAsync(Guid personId);

		Task<PersonDto> RemovePerson(Guid personId, CancellationToken cancellationToken = default);

		Task<PersonDto> UpdatePerson(PersonDto personDto, CancellationToken cancellationToken = default);
	}
}
