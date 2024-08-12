using BarnCase.Entities;

public abstract class Sheep:Animal
{
    public const int ProductionTime = 40; // Dakika
    public const int MinWoolToSell = 1; // kg
    public const int WoolPrice = 30; // Birim
    public const int BirthInterval = 40; // Dakika
    public const int Lifespan = 40; // Dakika
    public const int Cost = 200; // Birim
    public const int MaxCount = 10;
    public const int MaxEarningsPerSheep = 30; // Birim
    public const int MaxTotalEarnings = 700; // 10 koyun için maksimum

    public int AgeInMinutes { get; set; }
    public int WoolProduced { get; set; }

    public Sheep()
    {
        AgeInMinutes = 0;
        WoolProduced = 0;
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
            // Koyun öldü
        }
    }
}


