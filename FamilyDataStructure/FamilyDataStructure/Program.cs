using System;
using System.Collections.Generic;
using System.Reflection;


public enum Gender
{
    Male,
    Female
}
public class Person
{
    // Properties
    public string Name { get; set; }
    public string Surname { get; set; }
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

    // Method to add a child
    public void AddChild(Person child)
    {
        Children.Add(child);
        child.Parents.Add(this);

        // Update siblings' information
        foreach (var sibling in Children)
        {
            if (sibling != child && !Siblings.Contains(sibling))
            {
                Siblings.Add(sibling);
                sibling.Siblings.Add(child);
            }
        }
    }

    // Override ToString() for better representation
    public override string ToString()
    {
        return $"{Name} {Surname} ({(Sex == Gender.Male ? "Male" : "Female")}) - DOB: {DateOfBirth.ToShortDateString()}";
    }
}

public class Family
{
    // Properties
    public List<Person> Members { get; set; } = new List<Person>();

    // Method to add a person to the family
    public void AddPerson(Person person)
    {
        Members.Add(person);
    }

    // Method to determine the relationship between two persons
    public string GetRelationship(Person person1, Person person2)
    {
        if (person1.Parents.Contains(person2) || person2.Parents.Contains(person1))
        {
            return "Parent";
        }

        if (person1.Children.Contains(person2) || person2.Children.Contains(person1))
        {
            return "Child";
        }

        if (person1.Siblings.Contains(person2))
        {
            return "Sibling";
        }


        return "No direct relationship";
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

        // Establishing relationships
        doeFather.AddChild(doeChild1);
        doeMother.AddChild(doeChild1);

        doeFather.AddChild(doeChild2);
        doeMother.AddChild(doeChild2);

        doeFather.AddChild(doeChild3);
        doeMother.AddChild(doeChild3);

        Family doeFamily = new Family();
        doeFamily.AddPerson(doeFather);
        doeFamily.AddPerson(doeMother);
        doeFamily.AddPerson(doeChild1);
        doeFamily.AddPerson(doeChild2);
        doeFamily.AddPerson(doeChild3);

    }
}
