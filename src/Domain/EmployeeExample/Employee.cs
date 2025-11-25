
namespace Domain.EmployeeExample;

/*
-Validatation:
when creating a new instance using Factory method always check if data is
valid (not null or empty,) and throw InvalidDataException that means
that application layer validation didnt validate the data correctly
just enforce validation in Application layer
After that you check the business rules and return a result based on the context.
*/

public class Employee : AuditableEntity, ISofDeletable
{
    private Employee()
    {

    }
    protected Employee(string firstName, string lastName, DateTime dateOfBirth, Guid id = default)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public static Result<Employee> Create(string firstName, string lastName, DateTime dateOfBirth, Guid id = default)
    {
        if (string.IsNullOrWhiteSpace(firstName.Trim()))
        {
            throw new InvalidDataException(nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName.Trim()))
        {
            throw new InvalidDataException(nameof(lastName));
        }

        bool IsValidEmployeeAge = dateOfBirth.AddYears(DomainConstants.MinimumLegalEmployeeAge) < DateTime.Now;

        if (!IsValidEmployeeAge)
        {
            return EmployeeErrors.InvalidEmployeeAge;
        }


        return new Employee
        {
            Id = id,
            DateOfBirth = dateOfBirth,
            FirstName = firstName,
            LastName = lastName,
        };
    }

    // all your properties here
    #region Properties


    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName { get { return $"{FirstName} {LastName}"; } }
    public DateTime DateOfBirth { get; private set; }

    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    #endregion



}
