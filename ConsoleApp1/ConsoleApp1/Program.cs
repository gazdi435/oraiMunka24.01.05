namespace ConsoleApp1
{
    public interface IKezel
    {
        /// <summary>
        /// A megadott mennyiséget betölti a testbe.
        /// </summary>
        /// <param name="mennyit">A töltés mennyisége.</param>
        void Tolt(double mennyit);
        /// <summary>
        /// Kiüríti a testet, így a töltöttsége 0% lesz!
        /// </summary>
        void Kiurit();
        //Megadja, hogy a test térfogata mekkora %-ban van kitöltve.
        double JelenlegiToltottsegSzazalekban { get; }
    }
    public interface ITest
    {
        double Felszin();
        double Terfogat();
        
    }

    abstract class Test
    {
        public abstract double Felszin();
        public abstract double Terfogat();

        public abstract double K;
    }
    


    class Gomb:ITest,IKezel
    {
        double sugar,toltottseg;
        public override string ToString()
        {
            return   $"Sugár:{sugar}, Töltöttség:{toltottseg}";
        }

        public Gomb(int sugar)
        {
            this.sugar = sugar;
            this.toltottseg = 0;
        }

        public double JelenlegiToltottsegSzazalekban => (toltottseg/this.Terfogat())*100;

        public double Felszin()
        {
            return 4* Math.Pow(sugar, 2) * Math.PI;
        }

        public void Kiurit()
        {
            toltottseg = 0;
        }

        public double Terfogat()
        {
            return 4/3 *Math.PI*Math.Pow(sugar, 3);
        }

        public void Tolt(double mennyit)
        {
            if (toltottseg+mennyit<=this.Terfogat())
            {
                toltottseg += mennyit;
            }
            else
            {
                throw new Exception("Nem fér bele ennyi!");
            }
        }
    }

    class Teglatest : ITest,IKezel
    {
        double aOldal, bOldal, cOldal, toltottseg;
        public override string ToString()
        {
            return $"aOldal:{aOldal}, bOldal{bOldal}, cOldal{cOldal}, Töltöttség:{toltottseg}";
        }

        public Teglatest(int aOldal, int bOldal, int cOldal)
        {
            this.aOldal = aOldal;
            this.bOldal = bOldal;
            this.cOldal = cOldal;
            this.toltottseg = 0;
        }

        public double Felszin()
        {
            return 2*(aOldal*bOldal+aOldal*cOldal+bOldal*cOldal);
        }

        public double Terfogat()
        {
            return aOldal * bOldal * cOldal;
        }
        public void Tolt(double mennyit)
        {
            if (toltottseg + mennyit <= this.Terfogat())
            {
                toltottseg += mennyit;
            }
            else
            {
                throw new Exception("Nem fér bele ennyi!");
            }
        }

        public void Kiurit()
        {
            toltottseg = 0;
        }

        public double JelenlegiToltottsegSzazalekban => (toltottseg / this.Terfogat()) * 100;
    }

    class Henger : ITest,IKezel
    {
        double sugar, magassag, toltottseg;
        public override string ToString()
        {
            return $"Sugár:{sugar}, Magasság{magassag}, Töltöttség:{toltottseg}";
        }

        public Henger(double sugar, double magassag)
        {
            this.sugar = sugar;
            this.magassag = magassag;
            this.toltottseg=0;
        }

        public double Felszin()
        {
            return Math.Pow(sugar, 2) * Math.PI*2 + magassag*sugar;
        }

        public double Terfogat()
        {
            return Math.Pow(sugar, 2) * Math.PI * magassag;
        }

        public void Tolt(double mennyit)
        {
            if (toltottseg + mennyit <= this.Terfogat())
            {
                toltottseg += mennyit;
            }
            else
            {
                throw new Exception("Nem fér bele ennyi!");
            }
        }

        public void Kiurit()
        {
            toltottseg = 0;
        }

        public double JelenlegiToltottsegSzazalekban => (toltottseg / this.Terfogat()) * 100;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Gomb gomb = new Gomb();
        }
    }
}