namespace DocSeeker.API.Profile.Domain.Models;

public class Patient
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public double Height { get; set; }

    public double Weight { get; set; }

    public double BodyMass { get; set; }

}