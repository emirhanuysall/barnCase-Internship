using BarnCase.Entities;

public abstract class Chicken:Animal
{
    public const int ProductionTime = 4; // Dakika
    public const int EggsPerBatch = 5;
    public const int EggPrice = 10; // Birim
    public const int BirthInterval = 10; // Dakika
    public const int Lifespan = 20; // Dakika
    public const int Cost = 100; // Birim
    public const int MaxCount = 5;
    public const int MaxEarningsPerChicken = 50; // Birim
    public const int MaxTotalEarnings = 250; // 5 tavuk için maksimum

    public int AgeInMinutes { get; set; }
    public int EggsProduced { get; set; }

    public Chicken()
    {
        AgeInMinutes = 0;
        EggsProduced = 0;
    }

    public bool IsAlive()
    {
        return AgeInMinutes < Lifespan;
    }

    public void PassTime(int minutes)
    {
        AgeInMinutes += minutes;
        if (AgeInMinutes >= Lifespan)
        {
            // Tavuk öldü
        }
    }
}




