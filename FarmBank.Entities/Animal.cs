namespace BarnCase.Entities
{
    public abstract class Animal
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public TimeSpan LifeSpan { get; set; }

        public virtual int ProductTimeTick { get; set; } = 1;
        
    }
}



