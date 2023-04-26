using pudelko;
using System.Globalization;

var p1 = new Pudelko(2, 3, 5);
var p2 = new Pudelko(4,6,3);
double P3A = 0, P3B = 0, P3C = 0;
double x = 0, y = 0, z = 0;
double[] P1 = { p1.A, p1.B, p1.C };
double[] P2 = { p2.A, p2.B, p2.C };
//double max1 = P1[1], max2 = P2[1];
//double min1 = P1[1], min2 = P2[1];
double obj = 0;

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        double max1 = 0.001, max2 = 0.001;
        double min1 = 9.999, min2 = 9.999;
        x = P1[i] + P2[j];
        // szuka najdluzszego i najkrotszego boku p1
        foreach (var bok in P1)
        {
            //Console.WriteLine(bok);
            if (bok > max1 && bok != P1[i])
                max1 = bok;
            if (bok < min1 && bok != P1[i])
                min1 = bok;
        }
        // szuka najdluzszego i najkrotszego boku p2
        foreach (var bok in P2)
        {
            if (bok > max2 && bok != P2[j])
                max2 = bok;
            if (bok < min2 && bok != P2[j])
                min2 = bok;
        }
        // bok B nowego pudelka
        if (max1 >= max2) y = max1;
        else y = max2;
        // bok C nowego pudelka
        if (min1 >= min2) z = min1;
        else z = min2;
        // liczymy objetosc pudelka ktore pomiesci dwa poprzednie
        double obj_temp = x * y * z;
        if (i == 0 && j == 0)
        {
            obj = x * y * z; // po przejsciu petli pierwszy raz zapisujemy objetosc pierwszego znalezionego pudelka
            P3A = x; P3B = y; P3C = z; // zapisujemy dlugosci bokow ktore tworza to pudelko
        }
        if (obj_temp < obj)
        {
            obj = x * y * z; // przy kazdym nastepny przejsciu petli zapisujemy mniejsza objetosc
            P3A = x; P3B = y; P3C = z; // zapisujemy dlugosci bokow ktore tworza to pudelko
        }
    }
}
Console.WriteLine("_____________________");
Console.WriteLine(P3A);
Console.WriteLine(P3B);
Console.WriteLine(P3C);