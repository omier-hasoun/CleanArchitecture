namespace Application.Common.Abstractions;


public interface IPasswordHasher
{
    string Hash(string passwordPlain);

    bool Verify(string passwordPlain, string passwordHash);

}
