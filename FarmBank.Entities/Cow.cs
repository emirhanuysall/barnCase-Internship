using BarnCase.Entities;

public abstract class Cow:Animal
{
    public const int ProductionTimeBase = 3; // Dakika
    public const int ProductionTimeReductionPerCow = 15; // Saniye
    public const int MinMilkToSell = 1; // Litre
    public const int MilkPrice = 20; // Birim
    public const int BirthInterval = 15; // Dakika
    public const int Lifespan = 30; // Dakika
    public const int Cost = 120; // Birim
    public const int MaxCount = 8;

    public int AgeInMinutes { get; set; }
    public int MilkProduced { get; set; }

    public Cow()
    {
        AgeInMinutes = 0;
        MilkProduced = 0;
    }

    public int GetMilkProductionTime(int currentCowCount)
    {
        // Her yeni inek eklendiği durumda üretim süresinin 15 saniye düşmesi
        int reducedTime = ProductionTimeBase - (ProductionTimeReductionPerCow * (currentCowCount - 1) / 60);
        return Math.Max(reducedTime, 1); // En az 1 dakikalık süre
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
            // İnek öldü
        }
    }
}



