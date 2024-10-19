using System.Numerics;

namespace Qn2
{
    class Source
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        public double Add(double a, double b, double c)
        {
            return a + b + c;

        }
        class Program
        {
            static void Main(string[] args)
            {
                Source source = new Source();
               int Addition= source.Add(1, 2, 3);
               double Addition1= source.Add(2.5, 5.5, 9.7);
                Console.WriteLine(Addition);
                Console.WriteLine(Addition1);
            }
        }
    }
}