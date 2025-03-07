using System.Globalization;
using System.Text;

namespace RepresentationPattern;
public class ListPersonNameRepresentation : PersonNameRepresentation
{
    private string _name = null!;
    private string _surname = null!;

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetSurname(string surname)
    {
        _surname = surname;
    }

    public string Serialize()
    {
        return $"{_surname}, {_name}";
    }
}

public class FullPersonNameRepresentation : PersonNameRepresentation
{
    private string _name = null!;
    private string _surname = null!;

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetSurname(string surname)
    {
        _surname = surname;
    }

    public string Serialize()
    {
        return $"{_name} {_surname}";
    }
}

public class DniPersonNameRepresentation : PersonNameRepresentation
{
    private string _name = null!;
    private string _surname = null!;

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetSurname(string surname)
    {
        _surname = surname;
    }

    public string Serialize()
    {
        var fullName = string.Format("{1}<<{0}", RemovePunctuation(_name).Trim(), RemovePunctuation(_surname).Trim())
            .Replace(" ", "<")
            .ToUpperInvariant();
        return fullName;
    }

    private static string RemovePunctuation(string text)
    {
        return new String(
                text.Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    .ToArray()
            )
            .Normalize(NormalizationForm.FormC);
    }
}

public class DbPersonNameRepresentation : PersonNameRepresentation
{
    private string _name = null!;
    private string _surname = null!;

    public PersonNameDto Dto()
    {
        return new PersonNameDto(_name, _surname);
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetSurname(string surname)
    {
        _surname = surname;
    }
}

public record PersonNameDto
{
    private readonly string _name;
    private readonly string _surname;

    public PersonNameDto(string name, string surname)
    {
        _name = name;
        _surname = surname;
    }

    public string Name()
    {
        return _name;
    }

    public string Surname()
    {
        return _surname;
    }
}

