namespace Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookFactory hardCoverBookFactory = new HardCoverBookFactory();
            Book hardCoverBook = hardCoverBookFactory.publishBook();
            Console.WriteLine(hardCoverBook.Name);

            BookFactory paperBackBookFactory = new PaperBackBookFactory();
            Book paperBackBook = paperBackBookFactory.publishBook();
            Console.WriteLine(paperBackBook.Name);

            Console.ReadKey();
        }
    }
    public abstract class Book
    {
        protected string name;
        public string Name
        {
            get { return name; }
        }
    }
    public class PaperBackBook : Book
    {
        public PaperBackBook()
        {
            name = "Paper back book";
        }
    }
    public class HardCoverBook : Book
    {
        public HardCoverBook()
        {
            name = "Hard cover book";
        }
    }

    public abstract class BookFactory
    {
        public abstract Book publishBook();
    }
    public class PaperBackBookFactory : BookFactory
    {
        public override Book publishBook()
        {
            return new PaperBackBook();
        }
    }
    public class HardCoverBookFactory : BookFactory
    {
        public override Book publishBook()
        {
            return new HardCoverBook();
        }
    }
}