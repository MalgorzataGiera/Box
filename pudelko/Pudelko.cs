namespace pudelko
{
    public sealed class Pudelko : IEquatable<Pudelko>
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
        private readonly UnitOfMeasure unit;
        //private double objetosc;
        //private double pole;

        public double A 
        { 
            get
            {
                if (unit == UnitOfMeasure.milimeter) return Math.Round(a/100, 3);
                if (unit == UnitOfMeasure.centimeter) return Math.Round(a/10, 3);
                return Math.Round(a, 3);
            }
        }
        public double B
        {
            get
            {
                if (unit == UnitOfMeasure.milimeter) return Math.Round(b / 100, 3);
                if (unit == UnitOfMeasure.centimeter) return Math.Round(b / 10, 3);
                return Math.Round(a, 3);
            }
        }
        public double C
        {
            get
            {
                if (unit == UnitOfMeasure.milimeter) return Math.Round(c / 100, 3);
                if (unit == UnitOfMeasure.centimeter) return Math.Round(c / 10, 3);
                return Math.Round(a, 3);
            }
        }
        // zwraca objętość pudełka w m^3 w zaokrągleniu do 9 miejsc po przecinku
        public double Objetosc => Math.Round(A * B * C, 9);
        // zwraca pole powierzchni całkowitej pudełka w m^2 w zaokrągleniu do 6 miejsc po przecinku
        public double Pole => Math.Round(2 * A * B + 2 * A * C + 2 * B * C, 6);
        public Pudelko()
        {
            unit= UnitOfMeasure.centimeter;
            this.a = 10;
            this.b = 10;
            this.c = 10;
        }
        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.unit = unit;
            
            if (unit == UnitOfMeasure.centimeter)
            {
                if (this.a == default) this.a = a * 10;
                if (this.b == default) this.b = b * 10;
                if (this.c == default) this.c = c * 10;

                if (a > 1000 || b > 1000 || c > 1000) throw new ArgumentOutOfRangeException("Długość krawędzi nie może przekrozyć 10m");
            }
            if (unit == UnitOfMeasure.milimeter)
            {
                if (this.a == default) this.a = a * 100;
                if (this.b == default) this.b = b * 100;
                if (this.c == default) this.c = c * 100;

                if (a > 10000 || b > 10000 || c > 10000) throw new ArgumentOutOfRangeException("Długość krawędzi nie może przekrozyć 10m");
            }

            this.a = a;
            this.b = b;
            this.c = c;

            if (a > 10 || b > 10 || c > 10) throw new ArgumentOutOfRangeException("Długość krawędzi nie może przekrozyć 10m");
            if (a <= 0 || b <= 0 || c <= 0) throw new ArgumentOutOfRangeException("Długość krawędzi musi być dodatnia");
            
        }

        public override string ToString()
        {
            if (unit == UnitOfMeasure.centimeter)
                return $"{Math.Round(A / 10, 3)} m × {Math.Round(B / 10, 3)} m × {Math.Round(C / 10, 3)} m";
            if (unit == UnitOfMeasure.milimeter)
                return $"{Math.Round(A / 100, 3)} m × {Math.Round(B / 100, 3)} m × {Math.Round(C / 100, 3)} m";
            return $"{Math.Round(A, 3)} m × {Math.Round(B, 3)} m × {Math.Round(C, 3)} m";
        }

        public string ToString(string fmt)
        {

            if (fmt == "m")
                return $"{Math.Round(A, 3)} m × {Math.Round(B, 3)} m × {Math.Round(C, 3)} m";
            if (fmt == "cm")
                return $"{Math.Round(A, 3)} cm × {Math.Round(B, 3)} cm × {Math.Round(C, 3)} cm";
            if (fmt == "mm")
                return $"{Math.Round(A, 3)} mm × {Math.Round(B, 3)} mm × {Math.Round(C, 3)} mm";
            throw new FormatException();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return false;
        }
        public bool Equals(Pudelko? other)
        {
            if (this.A == this.B && this.A == this.C)
                if (other.A == other.B && other.A == other.C && other.A == this.A) return true;
            if (this.A == other.A)
                if ((this.B == other.B && this.C == other.C) || (this.B == other.C && this.C == other.B)) return true;
            if (this.A == other.B)
                if ((this.B == other.C && this.C == other.A) || (this.B == other.A && this.C == other.C)) return true;
            if (this.A == other.C)
                if ((this.B == other.B && this.C == other.A) || (this.B == other.A && this.C == other.B)) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public static bool operator==(Pudelko p1, Pudelko p2) => p1.Equals(p2);

        public static bool operator !=(Pudelko p1, Pudelko p2) => !(p1.Equals(p2));

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {

            double P3A = 0, P3B = 0, P3C = 0;
            double x = 0, y = 0, z = 0;
            double[] P1 = { p1.A, p1.B, p1.C };
            double[] P2 = { p2.A, p2.B, p2.C };
            double max1 = P1[1], max2 = P2[1];
            double min1 = P1[1], min2 = P2[1];
            double obj = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
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
                        obj = x * y * z; // po przejciu petli pierwszy raz zapisujemy objetosc pierwszego znalezionego pudelka
                        P3A = x; P3B = y; P3C = z; // zapisujemy dlugosci bokow ktore tworza to pudelko
                    }
                    if (obj_temp < obj)
                    {
                        obj = x * y * z; // przy kazdym nastepny przejsciu petli zapisujemy mniejsza objetosc
                        P3A = x; P3B = y; P3C = z; // zapisujemy dlugosci bokow ktore tworza to pudelko
                    }
                }
            }
            return new Pudelko(P3A, P3B, P3C);
        }
    }
}
