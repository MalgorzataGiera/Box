namespace pudelko
{
    public sealed class Pudelko 
    {
        private readonly decimal a;
        private readonly decimal b;
        private readonly decimal c;
        private readonly UnitOfMeasure unit;
        public decimal A 
        { 
            get
            {
                if (unit == UnitOfMeasure.milimeter) return Math.Round(a/100, 3);
                if (unit == UnitOfMeasure.centimeter) return Math.Round(a/10, 3);
                return Math.Round(a, 3);
            }
        }
        public decimal B { get => b; }
        public decimal C { get => c; }

        public Pudelko()
        {
            this.a = 10;
            this.b = 10;
            this.c = 10;
        }
        public Pudelko(decimal a, decimal b, decimal c, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.unit = unit;
            this.a = a;
            this.b = b;
            this.c = c;

            // zmienia dlugosc na cm
            if (unit == UnitOfMeasure.milimeter)
            {
                this.a *= 10;
                this.b *= 10;
                this.c *= 10;

            }
            if (unit == UnitOfMeasure.meter)
            {
                this.a %= 10;
                this.b %= 10;
                this.c %= 10;
            }


            // sprawdza ograniczenia dot. krawedzi
            if (this.a <= 0 || this.b <= 0 || this.c <= 0) throw new ArgumentOutOfRangeException("Długość krawędzi musi być dodatnia");
            if (this.a > 10 || this.b > 10 || this.c > 10) throw new ArgumentOutOfRangeException("Długość krawędzi nie może przekrozyć 10m");
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


    
    }
}
