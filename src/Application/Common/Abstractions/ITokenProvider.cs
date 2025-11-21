
namespace Application.Common.Abstractions;

public interface ITokenProvider
{
    // Task<Result<TokenResponse>> GenerateJwtTokenAsync(AppUserDto user, CancellationToken ct = default);

    // ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
