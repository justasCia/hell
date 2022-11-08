namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarBody sedan = new Sedan();
            CarBody univesal = new Universal();
            CarBody cabriolet = new Cabriolet();

            Engine diesel = new Diesel();
            Engine petrol = new Petrol();

            sedan.Engine = diesel;
            univesal.Engine = diesel;
            cabriolet.Engine = petrol;
            sedan.drive();
            univesal.drive();
            cabriolet.drive();

            sedan.Engine = petrol;
            univesal.Engine = petrol;
            cabriolet.Engine = diesel;
            sedan.drive();
            univesal.drive();
            cabriolet.drive();

            Console.ReadKey();
        }

        public abstract class CarBody
        {
            protected Engine engine;
            public abstract void drive();

            public Engine Engine
            {
                set { engine = value; }
            }
        }

        public class Sedan : CarBody
        {
            public override void drive()
            {
                Console.WriteLine($"Sedan driving with {engine.getEngineType()} engine.");
            }
        }
        public class Universal : CarBody
        {
            public override void drive()
            {
                Console.WriteLine($"Universal driving with {engine.getEngineType()} engine.");
            }
        }
        public class Cabriolet : CarBody
        {
            public override void drive()
            {
                Console.WriteLine($"Cabriolet driving with {engine.getEngineType()} engine.");
            }
        }

        public abstract class Engine
        {
            public abstract string getEngineType();
        }
        public class Diesel : Engine
        {
            public override string getEngineType()
            {
                return "diesel";
            }
        }
        public class Petrol : Engine
        {
            public override string getEngineType()
            {
                return "petrol";
            }
        }

    }
}