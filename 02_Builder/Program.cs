namespace _02_Builder
{
    class Laptop
    {
        public string MonitorResolution { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Hdd { get; set; }
        public string Battery { get; set; }

        public void Print()
        {
            Console.WriteLine($"Monitor resolurion : {MonitorResolution} ");
            Console.WriteLine($"Processor : {Processor} ");
            Console.WriteLine($"Memory : {Memory} ");
            Console.WriteLine($"Hdd : {Hdd} ");
            Console.WriteLine($"Battery : {Battery} ");
        }
    }
    abstract class LaptopBuilder
    {
        protected Laptop Laptop { get; private set; }
        public void CreateNewLaptop()
        {
            Laptop = new Laptop();
        }
        // Метод, який повертає готовий ноутбук назовні
        public Laptop GetMyLaptop()
        {
            return Laptop;
        }
        // Кроки, необхідні щоб створити ноутбук
        public abstract void SetMonitorResolution();//abstract = virtual
        public abstract void SetProcessor();
        public abstract void SetMemory();
        public abstract void SetHDD();
        public abstract void SetBattery();
    }
    class GamingLaptopBuilder : LaptopBuilder
    {
        public override void SetMonitorResolution()
        {

            Laptop.MonitorResolution = "1900X1200";
        }
        public override void SetProcessor()
        {
            Laptop.Processor = "Intel Core i7 13700K";
        }
        public override void SetMemory()
        {
            Laptop.Memory = "36 Gb";
        }
        public override void SetHDD()
        {
            Laptop.Hdd = "2 Tb";
        }
        public override void SetBattery()
        {
            Laptop.Battery = "6 lbs";
        }
    }
    class WorkLaptopBuilder : LaptopBuilder
    {
        public override void SetMonitorResolution()
        {

            Laptop.MonitorResolution = "1200x900";
        }
        public override void SetProcessor()
        {
            Laptop.Processor = "Intel Core i5 3330";
        }
        public override void SetMemory()
        {
            Laptop.Memory = "16 Gb";
        }
        public override void SetHDD()
        {
            Laptop.Hdd = "500 Gb";
        }
        public override void SetBattery()
        {
            Laptop.Battery = "6 lbs";
        }
    }

    class LaptopDirector
    {
        private LaptopBuilder _laptopBuilder = null;
        public void SetLaptopBuilder(LaptopBuilder lBuilder)
        {
            _laptopBuilder = lBuilder;
        }

        // Змушує будівельника повернути цілий ноутбук
        public Laptop GetLaptop()
        {
            return _laptopBuilder.GetMyLaptop();
        }
        // Змушує будівельника додавати деталі
        public void ConstructLaptop()
        {
            _laptopBuilder.CreateNewLaptop();
            _laptopBuilder.SetMonitorResolution();
            _laptopBuilder.SetProcessor();
            _laptopBuilder.SetMemory();
            _laptopBuilder.SetHDD();
            _laptopBuilder.SetBattery();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var workBuilder = new WorkLaptopBuilder();
            var gamingBuilder = new GamingLaptopBuilder();
            var shopForYou = new LaptopDirector();//Директор
                                             // Покупець каже, що хоче грати ігри
            shopForYou.SetLaptopBuilder(gamingBuilder);
            shopForYou.ConstructLaptop();
            // Ну то нехай бере що хоче!
            Laptop laptop = shopForYou.GetLaptop();
            laptop.Print();
            //Console.WriteLine(laptop.ToString());
            Console.WriteLine();
            shopForYou.SetLaptopBuilder(workBuilder);
            shopForYou.ConstructLaptop();
            // Ну то нехай бере що хоче!
            laptop = shopForYou.GetLaptop();
            laptop.Print();





        }
    }
}
