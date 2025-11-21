using Domain.Common.Constants;

namespace Domain.Entities.Example;

public static class EmployeeErrors
{
    public static Error InvalidEmployeeAge => Error.Forbidden("Employee.InvalidEmployeeAge", $"Employee should be atleast {DomainConstants.EmployeeMinimumAge} years old");


}
