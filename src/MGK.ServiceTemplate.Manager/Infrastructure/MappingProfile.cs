using AutoMapper;
using System;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;

namespace MGK.ServiceTemplate.Manager.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
			CreateMap<Person, PersonDto>()
				.ForMember(dest => dest.PersonId, mo => mo.MapFrom(src => src.Id))
				.ReverseMap();

			CreateMap<AddPersonDto, Person>()
				.ForMember(dest => dest.Id, mo => mo.MapFrom(_ => Guid.NewGuid()))
				.ForMember(dest => dest.CreationDate, mo => mo.MapFrom(_ => DateTime.UtcNow));
		}
	}
}
