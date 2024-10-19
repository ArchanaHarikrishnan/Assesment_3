namespace ConsoleApp5 { 
using System;
using System.Collections.Generic;
public class Person
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
}
class PersonImplementation
{
    public string GetName(IList<Person> persons)
    {
        string result = "";
        foreach (var person in persons)
        {
            result += person.Name + " " + person.Address + " ";
        }
        return result.Trim();
    }
    public double Average(IList<Person> persons)
    {
        return persons.Average(p => p.Age);
    }
    public int Max(IList<Person> persons)
    {
        return persons.Max(p => p.Age);
    }
}
class Source
{
    static void Main()
    {
        IList<Person> persons = new List<Person>{
      new Person{Name="Aarya",Address="A2101",Age=69},
      new Person{Name="Daniel",Address="D104",Age=40},
      new Person{Name="Ira",Address="H801",Age=25},
      new Person{Name="Jenifer",Address="I1704",Age=33}
        };
        PersonImplementation personimple = new PersonImplementation();
        string NameandAddress = personimple.GetName(persons);
        Console.WriteLine(NameandAddress);

        double Average = personimple.Average(persons);
        Console.WriteLine(Average);

        int MaximumAge = personimple.Max(persons);
        Console.WriteLine(MaximumAge);
    }
}
}