using FluentValidation;
using MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept;

namespace MGK.ServiceTemplate.API.Validators.ProofOfConcept
{
	public class RemovePersonCommandValidator : AbstractValidator<RemovePersonCommand>
	{
		public RemovePersonCommandValidator()
		{
			RuleFor(x => x.PersonId).NotEmpty();
		}
	}
}
