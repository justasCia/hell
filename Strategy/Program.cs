namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            player.Strategy = new Fly();
            player.move();

            player.Strategy = new Walk();
            player.move();

            player.Strategy = new Swim();
            player.move();

            player.Strategy = new Jump();
            player.move();

            Console.ReadKey();
        }
    }
    public class Player
    {
        private Strategy strategy;
        public void move()
        {
            strategy.move();
        }

        public Strategy Strategy
        {
            set { strategy = value; }
        }
    }

    public abstract class Strategy
    {
        public abstract void move();
    }
    public class Fly : Strategy
    {
        public override void move()
        {
            Console.WriteLine("Flying");
        }
    }
    public class Walk : Strategy
    {
        public override void move()
        {
            Console.WriteLine("Walking");
        }
    }
    public class Swim : Strategy
    {
        public override void move()
        {
            Console.WriteLine("Swimming");
        }
    }
    public class Jump : Strategy
    {
        public override void move()
        {
            Console.WriteLine("Jumping");
        }
    }
}