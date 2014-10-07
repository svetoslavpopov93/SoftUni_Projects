using System;

namespace DefiningClasses_HW
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Person(string name, int age, string email)
        {
            this.name = name;
            this.age = age;
            this.email = email;
        }

        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { age = value; }
        }

        public string Email
        {
            get {
                if (this.email == null)
                {
                    throw new ArgumentNullException("Email should not be null!");
                }
                else
                {
                    if (this.email.Contains("@") == true)
                    {
                        return this.email;
                    }
                    else
                    {
                        throw new FormatException("Invalid email exception!");
                    }
                }
            }
            set { email = value; }
        }

        public override string ToString()
        {
            return (Name + " " + Age + " " + Email);
        }
    }

    class Problem1_Persons
    {
        static void Main()
        {
            //Person goshy = new Person("Goshy Petrov", 15, null);
            //Person goshy = new Person("Goshy Petrov", 15, "asdasdad");
            Person goshy = new Person("Goshy Petrov", 15, "this@should.run");

            Console.WriteLine(goshy.ToString());
        }
    }
}
