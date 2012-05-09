using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Random
{
    class Program
    {
        public class MiRandom {
            
            public long x0;
            public MiRandom(int semilla) {
                x0 = semilla;
            }
            public MiRandom() {
                x0 = DateTime.Now.Millisecond;                
            }
            protected long GetX()
            {
                x0 = (25214903917 * x0 + 11) % (long)Math.Pow(2, 48);
                return x0 < 0 ? -x0 : x0;
            }
            public double NextDouble() {
                double d0 = Math.Pow(2,27)*this.GetX()/Math.Pow(2,22);
                d0 += this.GetX() / Math.Pow(2, 21);
                d0 /= Math.Pow(2,53);
                return d0;
            }
            public int NextInt(int minimo, int maximo) {

                return minimo+(int)((maximo-minimo)*NextDouble());
            }
            public int NextInt(int maximo) {
                return NextInt(0, maximo);
            }
            public int NextInt() {
                return NextInt(0, int.MaxValue);
            }
        }
        static void Main(string[] args)
        {
            MiRandom ran= new MiRandom();
            Console.WriteLine("Fredy G. Quiroz Rivera");
            Console.WriteLine("Programa de numeros aleatorios");
            Console.WriteLine("Utilizando el algoritmo que usa JAVA en el metodo nextDouble");
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine("10 Numeros enteros");
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("{0}\t{1}", i+1, ran.NextInt());
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine("10 numeros reales");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}\t{1}", i + 1, ran.NextDouble());
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
