


namespace Web.Api.Services;

public sealed class UserContext(IHttpContextAccessor context) : IUserContext
{
    public Guid Id
    {
        get
        {
            if (Guid.TryParse(context.HttpContext?.User?.
            FindFirstValue(ClaimTypes.NameIdentifier)!, out var parsedId))
            {
                field = parsedId;
            }
            else
            {
                field = SystemService.SystemId;
            }
            return field;
        }
    }

}
