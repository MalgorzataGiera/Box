using pudelko;
using System.Globalization;
CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
Pudelko p1 = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter);
//Pudelko p2 = Pudelko.Parse("2.500 m × 9.321 m × 0.100 m");
Console.WriteLine(p1.ToString("cm"));
//Console.WriteLine(p2.ToString("cm"));
