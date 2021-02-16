using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept
{
	public interface IPersonService
	{
		Task<PersonDto> AddPersonAsync(AddPersonDto personDto);

		Task<IEnumerable<PersonDto>> GetAllPersonsAsync();

		Task<PersonDto> GetPersonByIdAsync(Guid personId);

		Task<PersonDto> RemovePerson(Guid personId);

		Task<PersonDto> UpdatePerson(PersonDto personDto);
	}
}
