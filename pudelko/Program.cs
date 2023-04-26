using pudelko;
using System.Globalization;


var p = new Pudelko(2,2,3);
Console.WriteLine(p.Kompresuj());
public static class PudelkoExtensions
{
    public static Pudelko Kompresuj(this Pudelko p)
    {
        double a = Math.Pow(p.Objetosc, (1.0/3.0));
        return new Pudelko(a,a,a);
    }
}

