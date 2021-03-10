namespace EncoderCore
{
    public interface IWork
    {
        public string Encode(string plainText);
        public string Decode(string encodedText);
    }
}
