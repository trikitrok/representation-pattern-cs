using RepresentationPattern;

namespace RepresentationPatternTests;

public class PersonNameTest
{
    [Test]
    public void Should_Be_Represented_As_List_Name()
    {
        AssertListName(
            new PersonName("Fran", "Iglesias Gómez"),
            "Iglesias Gómez, Fran"
        );
    }

    [Test]
    public void Should_Be_Represented_As_Full_Name()
    {
        AssertFullName(
            new PersonName("Fran", "Iglesias Gómez"),
            "Fran Iglesias Gómez"
        );
    }

    [Test]
    public void Should_Be_Represented_As_DNI()
    {
        AssertDniName(
            new PersonName("Francisco José", "Iglesias Gómez"),
            "IGLESIAS<GOMEZ<<FRANCISCO<JOSE"
        );
    }

    [Test]
    public void Should_Be_Represented_As_DTO()
    {
        AssertDto(
            new PersonName("Fran", "Iglesias Gómez"),
            new PersonNameDto("Fran", "Iglesias Gómez")
        );
    }

    private void AssertDto(PersonName name, PersonNameDto expected)
    {
        var representation = new DbPersonNameRepresentation();
        name.Fill(representation);
        var dto = representation.Dto();
        Assert.That(dto, Is.EqualTo(expected));
    }

    private void AssertListName(PersonName name, string expected)
    {
        var representation = new ListPersonNameRepresentation();
        name.Fill(representation);
        Assert.That(representation.Serialize(), Is.EqualTo(expected));
    }

    private void AssertFullName(PersonName name, string expected)
    {
        var representation = new FullPersonNameRepresentation();
        name.Fill(representation);
        Assert.That(representation.Serialize(), Is.EqualTo(expected));
    }

    private void AssertDniName(PersonName name, string expected)
    {
        var representation = new DniPersonNameRepresentation();
        name.Fill(representation);
        Assert.That(representation.Serialize(), Is.EqualTo(expected));
    }
}

