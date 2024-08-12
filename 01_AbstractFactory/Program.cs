namespace _01_AbstractFactory
{

    abstract class Toy
    {
        public string Name { get; set; }
        public Toy(string name)
        {
            Name = name;
        }
        virtual public void Print()
        {
            Console.WriteLine($"I am a toy . My name : {Name}");
        }
    }
    abstract class Cat: Toy
    {
        public Cat(string name): base(name) { }

        public override void Print()
        {
            Console.WriteLine($"I am a cat . My name : {Name}");
        }
    }
    abstract class Bear : Toy
    {
        public Bear(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"I am a Bear . My name : {Name}");
        }
    }
    class WoodenCat: Cat
    {
        public WoodenCat(string name) : base(name) { }
       
        public override void Print()
        {
            Console.WriteLine($"I am a Wooden Cat . My name : {Name}");
        }
    }
    class TeddyCat : Cat
    {
        public TeddyCat(string name) : base(name) { }

         public override void Print()
        {
            Console.WriteLine($"I am a Teddy Cat . My name : {Name}");
        }
    }
    class WoodenBear : Bear
    {
        public WoodenBear(string name) : base(name) { }

         public override void Print()
        {
            Console.WriteLine($"I am a Wooden Bear . My name : {Name}");
        }
    }
    class TeddyBear : Bear
    {
        public TeddyBear(string name) : base(name) { }

         public override void Print()
        {
            Console.WriteLine($"I am a Teddy Bear . My name : {Name}");
        }
    }
    interface IToyFactory
    {
        Bear CreateBear();
        Cat CreateCat();
    }
    class TeddyToyFactory : IToyFactory
    {
        public Bear CreateBear()
        {
            return new TeddyBear("Teddy Bear TED");
        }

        public Cat CreateCat()
        {
            return new TeddyCat("Teddy Cat Tom");
        }
    }
    class WoodenToyFactory : IToyFactory
    {
        public Bear CreateBear()
        {
            return new WoodenBear("Wooden Bear GRIZLI");
        }

        public Cat CreateCat()
        {
            return new WoodenCat("Wooden Cat Tom");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           //IToyFactory factory = new WoodenToyFactory();
           IToyFactory factory = new TeddyToyFactory();
           Bear bear =  factory.CreateBear();  
         
           Cat cat = factory.CreateCat();

            bear.Print();
            cat.Print();

        }
    }
}
