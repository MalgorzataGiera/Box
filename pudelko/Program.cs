using pudelko;
using System.Collections.Generic;
using System.Globalization;

List<Pudelko> pudelka = new List<Pudelko>();
pudelka.Add(new Pudelko());
pudelka.Add(new Pudelko(2, 2, 3));
pudelka.Add(new Pudelko(b: 5));
pudelka.Add(new Pudelko(a: 2, c: 9.5, unit: UnitOfMeasure.centimeter));
pudelka.Add(new Pudelko(a: 1562, unit: UnitOfMeasure.milimeter));

foreach (var item in pudelka)
    Console.WriteLine(item.Objetosc);
Console.WriteLine("________________");




Comparison<Pudelko> kryterium = (p1, p2) =>
{
    // sortowanie według objętości
    int compareResult = p1.Objetosc.CompareTo(p2.Objetosc);
    if (compareResult != 0)
    {
        return compareResult;
    }

    // sortowanie według powierzchni całkowitej
    compareResult = p1.Pole.CompareTo(p2.Pole);
    if (compareResult != 0)
    {
        return compareResult;
    }

    // sortowanie według sumy długości krawędzi
    return (p1.A + p1.B + p1.C).CompareTo(p2.A + p2.B + p2.C);
};
pudelka.Sort(kryterium);

foreach (var item in pudelka)
    Console.WriteLine(item.Objetosc);


public static class PudelkoExtensions
{
    public static Pudelko Kompresuj(this Pudelko p)
    {
        double a = Math.Pow(p.Objetosc, (1.0/3.0));
        return new Pudelko(a,a,a);
    }

}



