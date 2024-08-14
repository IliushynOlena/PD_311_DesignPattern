namespace _06_Adapter
{
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "220V";
        }
    }
    // Широковикористовуваний інтерфейс нової системи (специфікація до квартири)
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }
    // Ну і власне сама розетка у новій квартирі
    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "220V";
        }
    }
    // Адаптер назовні виглядає як нові євроразетки,
    // шляхом наслідування прийнятного у // системі інтерфейсу
    class Adapter : INewElectricitySystem
    {
        // Але всередині він таки знає, що коїлося в СРСР
        private readonly OldElectricitySystem _adaptee;
        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }
        // А тут відбувається вся магія -
        // наш адаптер «перекладає»
        // функціональність із нового стандарту на старий
        public string MatchWideSocket()
        {
            // Якщо б була різниця в напрузі (не 220V)
            // то тут ми б помістили трансформатор
            return _adaptee.MatchThinSocket();
        }
    }
    class ElectricityConsumer
    {
        // Зарядний пристрій розуміє тільки нову систему
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1)
            // Ми можемо користуватися новою системою без проблем
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);
            // 2)
            // Ми повинні адаптуватися до старої системи, використовуючи адаптер
            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new Adapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);
        }
    }
}
