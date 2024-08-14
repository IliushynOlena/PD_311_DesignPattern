namespace _05_Prototype
{
    interface Prototype<T>
    {
        public T Clone();
    }
    public class IdInfo
    {
        public int IdNumber { get; set; }

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
    public class Person : Prototype<Person> 
    {
        public int Age { get; set; }//value 15 = 15
        public DateTime BirthDate { get; set; }//value 15.01.2000 = 15.01.2000
        public string Name { get; set; }//ref 0258855 = 0258855
        public IdInfo IdInfo { get; set; }// ref 028965 = 028965

        //public Person ShallowCopy()
        //{
        //    return (Person)this.MemberwiseClone();
        //}

        //public Person DeepCopy()
        //{
        //    Person clone = (Person)this.MemberwiseClone();
        //    clone.IdInfo = new IdInfo(IdInfo.IdNumber);
        //    clone.Name = String.Copy(Name);
        //    return clone;
        //}

        public Person Clone()
        {
            //return (Person)this.MemberwiseClone();

            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(777);

            // Perform a shallow copy of p1 and assign it to p2.
            //Person p2 = p1.ShallowCopy();
            // Make a deep copy of p1 and assign it to p3.
            //Person p3 = p1.DeepCopy();

           
            Person p2 = p1.Clone();
            // Make a deep copy of p1 and assign it to p3.
            Person p3 = p1.Clone();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Change the value of p1 properties and display the values of p1,
            // p2 and p3.
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}
