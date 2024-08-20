using BarnCase.Entities;

public sealed class Chicken:Animal
{


    public int AgeInMinutes { get; set; }
    public int EggsProduced { get; set; }

    public Chicken()
    {
        AgeInMinutes = 0;
        EggsProduced = 0;
    }


}




