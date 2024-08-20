using BarnCase.Entities;

public sealed class Cow:Animal
{


    public int AgeInMinutes { get; set; }
    public int MilkProduced { get; set; }

    public Cow()
    {
        AgeInMinutes = 0;
        MilkProduced = 0;
    }

    public override int ProductTimeTick { get => base.ProductTimeTick; set => base.ProductTimeTick = value; }




}



