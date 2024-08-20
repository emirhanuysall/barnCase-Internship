using BarnCase.Entities;

public sealed class Sheep:Animal
{


    public int AgeInMinutes { get; set; }
    public int WoolProduced { get; set; }

    public Sheep()
    {
        AgeInMinutes = 0;
        WoolProduced = 0;
    }

    
}


