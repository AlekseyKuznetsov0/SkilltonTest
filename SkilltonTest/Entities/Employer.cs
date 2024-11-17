namespace SkilltonTest.Entities;

public class Employer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public double Salary { get; set; }

    public Employer()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        DateOfBirth = DateOnly.FromDateTime(DateTime.Now);
        Salary = 0;
    }
}