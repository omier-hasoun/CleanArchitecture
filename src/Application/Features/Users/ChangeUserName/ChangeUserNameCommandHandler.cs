
namespace Application.Features.Users.ChangeUserName;

public class ChangeUserNameCommandHandler : IRequestHandler<ChangeUserNameCommand, Result<Updated>>
{


    Task<Result<Updated>> IRequestHandler<ChangeUserNameCommand, Result<Updated>>.Handle(ChangeUserNameCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
