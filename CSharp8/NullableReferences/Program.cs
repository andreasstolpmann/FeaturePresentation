using System;

#nullable enable
namespace NullableReferences
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int GetNameLength(Person person)
        {
            person.MiddleName ??= "asdi";

            return person.FirstName.Length + person.MiddleName.Length + person.LastName.Length;
        }

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Person(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
