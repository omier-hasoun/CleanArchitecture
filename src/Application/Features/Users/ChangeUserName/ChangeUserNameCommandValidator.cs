


namespace Application.Features.Users.ChangeUserName;

public class ChangeUserNameCommandValidator : AbstractValidator<ChangeUserNameCommand>
{
    public ChangeUserNameCommandValidator(IOptions<UserAccountOptions> options)
    {
        var op = options.Value;

        RuleFor(x => x.UserId)
        .NotEmpty()
        .WithErrorCode(UsersErrors.UserIdInvalid)
        .WithMessage("The given User Id was invalid.");

        RuleFor(x => x.NewUserName)
        .NotEmpty()
        .WithErrorCode(UsersErrors.UserNameRequired)
        .WithMessage("username is required.")
        .Length(op., op.MaxUserNameLength)
        .WithErrorCode(UsersErrors.UserNameLengthInvalid)
        .WithMessage("The new username must be between {MinLength} and {MaxLength} characters. You entered {TotalLength} characters.");

    }
}
