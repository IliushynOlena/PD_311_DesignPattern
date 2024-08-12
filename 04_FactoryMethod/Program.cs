namespace _04_FactoryMethod
{
    abstract class User
    {
        public abstract void Info();
    }
    class Admin : User
    {
        public override void Info()
        {
            Console.WriteLine("I am admin");
        }
    }
    class Manager : User
    {
        public override void Info()
        {
            Console.WriteLine("I am manager");
        }
    }
    class Guest : User
    {
        public override void Info()
        {
            Console.WriteLine("I am guest");
        }
    }
    enum UserTypes { ADMIN, GUEST, MANAGER}

    class UserFactory
    {
        public User CreateUser(UserTypes type)
        {
            switch (type)
            {
                case UserTypes.ADMIN:
                    return new Admin();
                case UserTypes.GUEST:
                    return new Guest(); 
                case UserTypes.MANAGER:
                    return new Manager();   
                default:
                    return null;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            UserFactory factory = new UserFactory();
            User user = factory.CreateUser(UserTypes.ADMIN);    
            user.Info();
            user = factory.CreateUser(UserTypes.GUEST);
            user.Info();
            user = factory.CreateUser(UserTypes.MANAGER);
            user.Info();
        }
    }
}
