    using System;

    namespace Vezba08a
    {
        class Kompleksni // -3.1 - 4.1i
        {
            private double re;
            private double im;
            public double Re { get { return re; } set { re = value; } }
            public double Im { get { return im; } set { im = value; } }
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
                return !(k1==k2);
            }
            public 
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Kompleksni u1 = new Kompleksni(3.1, 4.1);
                Kompleksni u2 = new Kompleksni(3.0, 4.1);
                Console.WriteLine(u2.ToString());
                Kompleksni u = u1 - u2;//2.1+3.1i
                Console.WriteLine(u.ToString());
                if (u1 == u2)
                    Console.Write("Jednaki");
                if (u1 != u2)
                    Console.Write("Nisu jednaki");
            }
        }
    }
