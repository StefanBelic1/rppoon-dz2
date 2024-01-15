// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



public class Perilica
{
    public void PeriSudje()
    {
        Console.WriteLine("Operi sudje");
    }

    public void PeriOdjecu()
    {
        Console.WriteLine("Operi odjecu");
    }

    /*ovaj primjer narusava SRP nacelo jer perilica nema jednu odgovornost, vec 2 razlicite. Bolje bi bilo razdvojiti
    ove dvije metode, napraviti klasu za perilicu sudja i perilicu za odjecu*/
}

public class Placanje
{
    public double IzracunajIznos(double iznos, string tipPlacanja)
    {
        if (tipPlacanja == "Gotovina")
        {
            return iznos;
        }
        else if (tipPlacanja == "Kartica")
        {
            return iznos + (iznos * 0.05);
        }

        else
        {
            throw new ArgumentException("Neispravno");
        }
    }

    /* ovaj primjer narusava OCP jer je klasa zatvorena za prosirenje. Ukoliko dodje do nove opcije placanja npr
     kripto valutom moramo mijenjati klasu Placanje. Bolje bi bilo da koristimo apstraktnu klasu ili interface
     da mozemo lako dodati novu metodu placanja*/
}

public class Sword
{
    public virtual int sharpness { get; set; }
    public virtual int damage { get; set; }
    public virtual int lenght { get; set; }
}
public class DamageCalculator
{
    public double CalculateDamage(Sword sword)
    {
        return sword.sharpness + sword.damage;
    }

    /*Ovaj primjer narusava LSP jer klasa damagecalculator ovisi o klasi sword. Moze nastati problem ukoliko imamo vise
     oruzja. Bolje bi bilo napraviti interface weapon sa metodom Damagecalculator i onda nasljedjivati svakom oruzju taj 
    interface */
}

public interface IBird
{
    public void feed();
    public void fly();
    public void feathers();
}

public class Penguin : IBird
{
    public void feed() { Console.WriteLine("fish"); }
    public void fly() { throw new ArgumentException("can't fly"); }
    public void feathers() { Console.WriteLine("black and white"); }

    /*ovo narusava ISP jer imamo previse metoda u jednom interfaceu, nemaju sve ptice te osobine i onda dolazi
     * do toga da ih sve moramo implementirati bez obzira ima li ptica tu osobinu ili ne. Bolje bi bilo da ih razdvojimo 
     u vise interfacea */
}

public class Goblin
{
    public void Attack()
    {
        Console.WriteLine("Goblin attacked");
    }
}

public class Wizard
{
    private Goblin goblin = new Goblin();

    public void DoMagic()
    {
        this.goblin.Attack();
    }
    /*Ovaj primjer narusava DIP jer klasa wizard ovisi o implementaciji klase goblin a ne o apstrakciji. Bolje bi bilo
     koristiti interface ili apstraktnu klasu sa metodom attack*/
}