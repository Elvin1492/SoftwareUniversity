//Define a class Person that has name, age and email. The name and age are mandatory. The email is optional. 
//Define properties that accept non-empty name and age in the range [1...100]. In case of invalid argument, 
//throw an exception. Define a property for the email that accepts either null or non-empty string containing '@'.
//Define two constructors. The first constructor should take name, age and email. The second constructor should take
//name and age only and call the first constructor. Implement the ToString() method to enable printing persons at the console.

using System;
using System.Text;
using System.ComponentModel.DataAnnotations;

public class Person
{
    //defining class fields
    private string name;
    private int age;
    private string email;

    //defining a Name poperty
    public string Name
    {
        get { return this.name; }
        set
        {
            //check if the name is an empty string and throw an exception if it is
            if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(this.name, "Name must be a non-empty string!");
            this.name = value;
        }
    }

    //defining an Age property
    public int Age
    {
        get { return this.age; }
        set
        {
            //check if the age is a valid integer number  and throw and exception if it's not
            if (value > 100 || value < 1) throw new ArgumentOutOfRangeException(Convert.ToString(this.age),
                "Age should be an integer number in the range [1..100]");
            this.age = value;
        }
    }

    //defining an Email property
    public string Email
    {
        get { return this.email; }
        set
        {
            //check if the Email is vaid with our custom function and throw exception if it's not
            if (!isValidEmail(value) && value.Length > 0) throw new ArgumentException("Email is not valid!");
            if (value != null && value == String.Empty) throw new ArgumentException("Email can not be an empty string!");
            this.email = value;
        }
    }

    //define constructor which takes name, age and email as parameters
    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }
    //define constructor which takes name and  age and chains to the previus cunstroctor, setting a default value of null to the email parameter
    public Person(string name, int age)
        : this(name, age, null) { }


    //Implement the ToString() method to enable printing persons at the console
    public override string ToString()
    {
        StringBuilder personInfo = new StringBuilder();
        personInfo.Append("Name: " + this.name + ", Age: " + this.age);
        if (this.email != null)
        {
            personInfo.Append(", Email: " + this.email);
        }
        return personInfo.ToString();
    }

    //a private function to chek if the Email is a valid email address
    private bool isValidEmail(string email)
    {
        //using the built-in .NET class for email address annotation
        bool isValid = new EmailAddressAttribute().IsValid(email);
        return isValid;
    }

}

//testing and running the Person class
class PersonTester
{
    static void Main()
    {
        //first test is clean all data is valid
        Person firstPerson = new Person("Gosho", 23, "gosho@epich.bg");
        Console.WriteLine(firstPerson);

        //second test is clean all data is valid but we dont assign email to the new object
        Person secondPerson = new Person("Pesho", 33);
        Console.WriteLine(secondPerson);

        //third test we assign invalid empty string for a name  and an exception is thrown
        Person thirdPerson = new Person("", 19);
        Console.WriteLine(thirdPerson);

        //fourth test we assign invalid integer for an age  and an exception is thrown
        Person fourthPerson = new Person("Penka", 101);
        Console.WriteLine(fourthPerson);

        //fifth test we assign invalid email and an exception is thrown
        Person fifthPerson = new Person("Ginka", 26, "ginkaepichka.som");
        Console.WriteLine(fifthPerson);

        //fifth test we assign invalid invalid empty string for an email and an  exception is thrown
        Person sixthPerson = new Person("Grozdanka", 66, "");
        Console.WriteLine(sixthPerson);
    }
}

