using FluentValidation;
using MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept;
using System;

namespace MGK.ServiceTemplate.API.Validators.ProofOfConcept
{
	public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
	{
		public AddPersonCommandValidator()
		{
			RuleFor(x => x.Name).NotNull().NotEmpty();
			RuleFor(x => x.Surname).NotNull().NotEmpty();
			RuleFor(x => x.DocumentNumber).NotNull().NotEmpty();
			RuleFor(x => x.BirthDate).Must(bd => bd < DateTime.Today.AddDays(1));
		}
	}
}
