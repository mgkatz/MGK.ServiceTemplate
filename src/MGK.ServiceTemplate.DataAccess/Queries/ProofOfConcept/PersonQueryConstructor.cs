using AutoMapper;
using MGK.ServiceBase.DAL.Infrastructure.Queries;
using MGK.ServiceTemplate.DataAccess.Contexts;
using MGK.ServiceTemplate.DataAccess.Expressions.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using System;
using System.Collections.Generic;

namespace MGK.ServiceTemplate.DataAccess.Queries.ProofOfConcept
{
	public class PersonQueryConstructor :
		ProofOfConceptQueryConstructor<Person, IPersonQueryConstructor>,
		IPersonQueryConstructor
	{
		public PersonQueryConstructor(ProofOfConceptContext context, IMapper mapper)
			: base(context, mapper)
		{
		}

		public IPersonQueryConstructor FilterByDocumentNumber(string documentNumber)
			=> FilterBy(PersonExpressions.DocumentNumberFilter(documentNumber));

		public IPersonQueryConstructor FilterById(Guid personId)
			=> FilterBy(PersonExpressions.PersonIdFilter(personId));

		public IPersonQueryConstructor OrderByFullName()
		{
			var keySelectors = new List<OrderSelector<Person, object>>
			{
				new OrderSelector<Person, object> { Key = p => p.Name },
				new OrderSelector<Person, object> { Key = p => p.Surname }
			};

			return OrderByMany(keySelectors);
		}
	}
}
