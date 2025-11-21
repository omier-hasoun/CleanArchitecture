
using System.Reflection.Metadata;
using Domain.Common.Constants;

namespace Domain.Entities.Example;

public class Employee : AuditableEntity, ISofDeletable
{

    protected Employee(Guid id = default) : base(id)
    {

    }

    public static Result<Employee> Create(string firstName, string LastName, DateTime dateOfBirth, Guid id = default)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ValidationException($"{nameof(firstName)} was null or empty");
        }

        if (string.IsNullOrWhiteSpace(LastName))
        {
            throw new ValidationException($"{nameof(LastName)} was null or empty");
        }

        if (dateOfBirth.AddYears(DomainConstants.EmployeeMinimumAge) < DateTime.Now)
        {
            return EmployeeErrors.InvalidEmployeeAge;
        }

        Employee emp = new(id)
        {
            FirstName = firstName,
            LastName = LastName,
            DateOfBirth = dateOfBirth,
        };

        return emp;
    }

    // all your properties here
    #region Properties


    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public string FullName { get { return $"{FirstName} {LastName}"; } }
    public DateTime DateOfBirth { get; private set; }

    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    #endregion

    public Result<Updated> ChangeEmployeeName(string firstName, string LastName)
    {

        FirstName = firstName;

        return Result.Updated;
    }
}
