namespace Structural.Decorator
{
    public interface ICreature
    {
        int Age { get; set; }
    }

    public interface IBird : ICreature
    {
        string Fly()
        {
            return (Age >= 10) ? "flying" : "too young";
        }
    }

    public interface ILizard : ICreature
    {
        string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Bird : IBird
    {
        public int Age { get; set; }
    }

    public class Lizard : ILizard
    {
        public int Age { get; set; }
    }

    public class Dragon : IBird, ILizard
    {
        private readonly IBird bird;
        private readonly ILizard lizard;

        public int Age
        {
            get => bird.Age;
            set => bird.Age = lizard.Age = value;
        }

        public Dragon(IBird bird, ILizard lizard)
        {
            this.bird = bird;
            this.lizard = lizard;
            bird.Age = lizard.Age;
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }

        public string Fly()
        {
            return bird.Fly();
        }
    }
}
