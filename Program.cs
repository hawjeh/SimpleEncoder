using System;

namespace EncoderCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mappingType = 'F';
            var myCase = "HELLO WORLD";

            Console.WriteLine(myCase);

            var work = new Work(mappingType);
            var encoded = work.Encode(myCase);

            Console.WriteLine("Encoding");
            Console.WriteLine(encoded);

            var decoded = work.Decode(encoded);

            Console.WriteLine("Decoding");
            Console.WriteLine(decoded);

            Console.ReadKey();
        }
    }
}
