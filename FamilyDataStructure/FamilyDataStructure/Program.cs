using System;
using System.Collections.Generic;
using System.Reflection;


public enum Gender
{
    Male,
    Female
}

public enum Relationships
{
    Parent,
    Child,
    Sibling,
    Grandparent,
    AuntOrUncle,
    Cousin,
    NieceOrNephew,
    Unrelated
}
public class Person
{
    // Properties
    public string Name { get; set; }
    public string Surname { get; set; }
    public Person Spouse { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Sex { get; set; }

    // Relationships
    public List<Person> Parents { get; set; } = new List<Person>();
    public List<Person> Children { get; set; } = new List<Person>();
    public List<Person> Siblings { get; set; } = new List<Person>();

    // Constructor
    public Person(string name, string surname, DateTime dateOfBirth, Gender sex)
    {
        Name = name;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        Sex = sex;
    }

    public void AddChild(Person child)
    {
        Children.Add(child);
    }
    public bool isMarried()
    {
        if (Spouse.Equals(null))
        {
            return false;
        } else
        {
            return true;
        }
    }

    public bool isPersonsEqual(Person person)
    {
        if (person == null)
        {
            return false;
        }

        bool areNamesEqual = string.Equals(this.Name, person.Name);
        bool areSurnamesEqual = string.Equals(this.Surname, person.Surname);
        bool areDatesOfBirthEqual = DateTime.Equals(this.DateOfBirth, person.DateOfBirth);
        bool areSexEqual = this.Sex == person.Sex;
  

        return areNamesEqual && areSurnamesEqual && areDatesOfBirthEqual && areSexEqual;
    }


    public override string ToString()
    {
        return $"{Name} {Surname} ({(Sex == Gender.Male ? "Male" : "Female")}) - DOB: {DateOfBirth.ToShortDateString()}";
    }
}

public class Family
{
    public List<Person> Members { get; set; } = new List<Person>();

    public void AddPerson(Person person)
    {
        Members.Add(person);
    }

    public Relationships GetRelationship(Person person1, Person person2)
    {
        if (person1.Children.Contains(person2))
        {
            return Relationships.Parent;
        }
        if (person1.Parents.Contains(person2)){
            return Relationships.Child;
        }
        if (person1.Siblings.Contains(person2))
        {
            return Relationships.Sibling;
        }


        return Relationships.Unrelated;
    }

    // Override ToString() for better representation
    public override string ToString()
    {
        string familyInfo = "Family Members:\n";
        foreach (var member in Members)
        {
            familyInfo += $"{member}\n";
        }
        return familyInfo;
    }
}

class Program
{
    static void Main()
    {
        Person doeFather = new Person("John", "Doe", new DateTime(1980, 5, 15), Gender.Male);
        Person doeMother = new Person("Jane", "Doe", new DateTime(1985, 8, 20), Gender.Female);

        Person doeChild1 = new Person("Alice", "Doe", new DateTime(2010, 3, 8), Gender.Female);
        Person doeChild2 = new Person("Bob", "Doe", new DateTime(2012, 7, 12), Gender.Male);
        Person doeChild3 = new Person("Mike", "Doe", new DateTime(2015, 12, 3), Gender.Female);




    }
}
