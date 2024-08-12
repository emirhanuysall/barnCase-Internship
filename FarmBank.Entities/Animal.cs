namespace BarnCase.Entities
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public TimeSpan Lifespan { get; set; }

        public abstract void Produce();
    }
}



