using FluentValidation;
using MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept;

namespace MGK.ServiceTemplate.API.Validators.ProofOfConcept
{
	public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
	{
		public UpdatePersonCommandValidator()
		{
			RuleFor(x => x.PersonId).NotEmpty();
			RuleFor(x => x.Name).NotNull().NotEmpty();
			RuleFor(x => x.Surname).NotNull().NotEmpty();
		}
	}
}
