namespace RepresentationPattern;

public sealed class PersonName
{
    private string _name;
    private string _surname;

    public PersonName(string name, string surname)
    {
        _name = name;
        _surname = surname;
    }
    
    public void RepresentAs(PersonNameRepresentation representation)
    {
        representation.SetName(_name);
        representation.SetSurname(_surname);
    }
}