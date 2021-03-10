using System;

namespace EncoderCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myCase = "HELLO WORLD";
            Console.WriteLine(myCase);

            var work = new Work();
            var encodedB = work.Encode(myCase);
            var encodedC = work.Encode(encodedB);

            Console.WriteLine("Encoding");
            Console.WriteLine(encodedB);
            Console.WriteLine(encodedC);

            var decodedC = work.Decode(encodedC);
            var decodedB = work.Decode(decodedC);

            Console.WriteLine("Decoding");
            Console.WriteLine(decodedC);
            Console.WriteLine(decodedB);

            Console.ReadKey();
        }
    }
}
