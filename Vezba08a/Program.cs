using System;
// Komentar
namespace Vezba08a
{
    class Kompleksni // -3.1 - 4.1i
    {
        private double re;
        private double im;
        public double Re { get { return re; } set { re = value; } }
        public double Im { get { return im; } set { im = value; } }
        public double Modul
        {
            get { return Math.Sqrt(re * re + im * im); }
        }
        public double Argument
        {
            get { return Math.Atan2(im, re); }
        }
        public Kompleksni()
        {
            re = 0;
            im = 0;
        }
        public Kompleksni(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        public override string ToString()
        {
            if (im >= 0)
                return $"{re} + {im}i";
            return $"{re} - {-im}i";
            //return re + " - " + -im + "i";
        }
        // Equals() metoda je nasledjena iz klase Object, pa je potrebno da je redefinisemo
        // da bi smo mogli da poredimo dva kompleksna broja
        // Kada redefinisemo Equals() metodu, potrebno je da redefinisemo i GetHashCode() metodu
        // da bi smo mogli da koristimo kompleksne brojeve kao kljuceve
        // u kolekcijama tipa Dictionary
        // Kada redefinisemo Equals() metodu, potrebno je da
        // redefinisemo i operator == i operator !=
        // da bi smo mogli da poredimo dva kompleksna broja
        // Kada redefinisemo operator == i operator !=,
        // potrebno je da redefinisemo i Equals() metodu
        // da bi smo mogli da poredimo dva kompleksna broja
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            Kompleksni k = (Kompleksni)obj;
            return this.re == k.re && this.im == k.im;
        }
        // GetHashCode() metoda je nasledjena iz klase Object,
        // pa je potrebno da je redefinisemo
        // da bi smo mogli da koristimo kompleksne brojeve kao kljuceve
        // u kolekcijama tipa Dictionary
        // GetHashCode() metoda treba da vrati jedinstveni hash kod za svaki kompleksni broj
        // Hash kod treba da bude isti za dva kompleksna broja koji su jednaki
        // Hash kod treba da bude razlicit za dva kompleksna broja koji nisu jednaki
        // xor operator (^) se koristi za kombinovanje hash kodova realnog i imaginarnog dela kompleksnog broja
        // XOR operator vraća 1 ako su bitovi različiti, a 0 ako su isti
        // Na taj način se dobija jedinstveni hash kod za svaki kompleksni broj
        public override int GetHashCode() 
        {
            return re.GetHashCode() ^ im.GetHashCode(); // XOR operator
        }

        public static Kompleksni operator +(Kompleksni k1, Kompleksni k2)
        {
            Kompleksni k = new Kompleksni(k1.re + k2.re, k1.im + k2.im);
            return k;
        }
        public static Kompleksni operator -(Kompleksni k1, Kompleksni k2)
        {
            Kompleksni k = new Kompleksni(k1.re - k2.re, k1.im - k2.im);
            return k;
        }
        public static bool operator ==(Kompleksni k1, Kompleksni k2)
        {
            return k1.re == k2.re && k1.im == k2.im;
        }
        public static bool operator !=(Kompleksni k1, Kompleksni k2)
        {
            return !(k1 == k2);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kompleksni u1 = new Kompleksni(3.1, 4.1);
            Kompleksni u2 = new Kompleksni(3.1, 4.1);
            Console.WriteLine(u2.ToString());
            Kompleksni u = u1 - u2;//2.1+3.1i
            Console.WriteLine(u.ToString());
            if (u1 == u2)
                Console.WriteLine("Jednaki");
            if (u1 != u2)
                Console.WriteLine("Nisu jednaki");
            // primena Equals() metode
            if (u1.Equals(u2))
                Console.WriteLine("Jednaki");
            // primena GetHashCode() metode
            Console.WriteLine(u1.GetHashCode());
            Console.WriteLine(u2.GetHashCode());

        }
    }
}
