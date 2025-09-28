namespace GameStore.Models;

public enum Gender
{
    Female,
    Male
}
public class Person
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber
    { get; set; }
}
