namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NewsAgency bnsAgency = new BNSAgency("BNS agency");
            NewsAgency eltaAgency = new EltaAgency("Elta agency");

            bnsAgency.subscribe(new LietusRadio(bnsAgency, "Lietus radio"));
            bnsAgency.subscribe(new DienaNewsPaper(bnsAgency, "Diena newspaper"));

            NewsEvent newsEvent1 = new NewsEvent("New news event 1");
            NewsEvent newsEvent2 = new NewsEvent("New news event 2");

            eltaAgency.subscribe(new LietusRadio(eltaAgency, "Lietus radio"));

            bnsAgency.handleNewsEvent(newsEvent1);
            eltaAgency.handleNewsEvent(newsEvent2);

            Console.ReadKey();
        }
    }

    //subject
    public abstract class NewsAgency
    {
        private List<MassMedia> observers = new List<MassMedia>();
        private NewsEvent state;
        protected string name;

        public void subscribe(MassMedia observer)
        {
            observers.Add(observer);
        }
        public void unsubscribe(MassMedia observer)
        {
            observers.Remove(observer);
        }

        public void notifySubscribers()
        {
            foreach (var observer in observers)
            {
                observer.updateLatestNews();
            }
        }

        public void handleNewsEvent(NewsEvent newsEvent)
        {
            state = newsEvent;
            notifySubscribers();
        }

        public NewsEvent State
        {
            get { return state; }
            set { state = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    //concrete subjects
    public class BNSAgency : NewsAgency
    {
        public BNSAgency(string name)
        {
            this.name = name;
        }
    }
    public class EltaAgency : NewsAgency
    {
        public EltaAgency(string name)
        {
            this.name = name;
        }
    }


    // observer
    public abstract class MassMedia
    {
        public abstract void updateLatestNews();
        protected NewsAgency subject;
    }

    //concrete observers
    public class LietusRadio : MassMedia
    {
        public string Name { get; set; }

        public LietusRadio(NewsAgency newsAgency, string name)
        {
            subject = newsAgency;
            Name = name;
        }

        public override void updateLatestNews()
        {
            Console.WriteLine($"{Name}: {subject.State.EventInfo}, source: {subject.Name}");
        }
    }

    public class DienaNewsPaper : MassMedia
    {
        public string Name { get; set; }

        public DienaNewsPaper(NewsAgency newsAgency, string name)
        {
            subject = newsAgency;
            Name = name;
        }

        public override void updateLatestNews()
        {
            Console.WriteLine($"{Name}: {subject.State.EventInfo}, source: {subject.Name}");
        }
    }

    public class NewsEvent
    {
        public string EventInfo { get; set; }

        public NewsEvent(string eventInfo)
        {
            EventInfo = eventInfo;
        }
    }
}