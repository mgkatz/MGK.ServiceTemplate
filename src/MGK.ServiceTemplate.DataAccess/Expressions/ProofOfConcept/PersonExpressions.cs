using LinqKit;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using System;
using System.Linq.Expressions;

namespace MGK.ServiceTemplate.DataAccess.Expressions.ProofOfConcept
{
	public static class PersonExpressions
	{
		public static Expression<Func<Person, bool>> DocumentNumberFilter(string documentNumber)
			=> PredicateBuilder.New<Person>().And(p => p.DocumentNumber == documentNumber);

		public static Expression<Func<Person, bool>> PersonIdFilter(Guid personId)
			=> PredicateBuilder.New<Person>().And(p => p.Id == personId);
	}
}
