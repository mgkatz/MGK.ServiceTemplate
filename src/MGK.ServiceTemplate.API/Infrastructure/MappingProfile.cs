using AutoMapper;
using MGK.ServiceTemplate.API.Application.Requests.ProofOfConcept;
using MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;

namespace MGK.ServiceTemplate.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
			CreateMap<AddPersonRequest, AddPersonCommand>();

			CreateMap<AddPersonCommand, AddPersonDto>();

			CreateMap<PersonViewModel, PersonDto>()
				.ReverseMap();

			CreateMap<UpdatePersonRequest, UpdatePersonCommand>();

			CreateMap<UpdatePersonCommand, PersonDto>();
		}
	}
}
