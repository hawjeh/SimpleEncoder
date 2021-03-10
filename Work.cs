namespace EncoderCore
{
    public class Work : IWork
    {
        private readonly char _empty = '\0';
        private readonly string _dRefTable = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789()*+,-./";
        private readonly string _bRefTable = @"/ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789()*+,-.";
        private readonly string _fRefTable = @"+,-./ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789()*";

        public Work() { }

        public string Encode(string plainText)
        {
            plainText = plainText.Trim().ToUpper();
            string encodedStr = "";
            WorkAction action = plainText[0] == 'B' ? WorkAction.EncodeBToF : WorkAction.EncodeDToB;

            if (action == WorkAction.EncodeDToB)
            {
                encodedStr += 'B';
            }
            else
            {
                encodedStr += 'F';
            }

            for (var i = (action == WorkAction.EncodeDToB ? 0 : 1); i < plainText.Length; i++)
            {
                encodedStr += FindChar(plainText[i], action);
            }

            return encodedStr;
        }

        public string Decode(string encodedText)
        {
            encodedText = encodedText.Trim().ToUpper();
            string decodedStr = "";
            WorkAction action = encodedText[0] == 'F' ? WorkAction.DecodeFToB : WorkAction.DecodeBToD;

            if (action == WorkAction.DecodeFToB)
            {
                decodedStr += 'B';
            }

            for (var i = 1; i < encodedText.Length; i++)
            {
                decodedStr += FindChar(encodedText[i], action);
            }

            return decodedStr;
        }

        private char FindChar(char current, WorkAction action)
        {
            char resp = _empty;
            int ref1;
            switch (action)
            {
                case WorkAction.EncodeDToB:
                    ref1 = _dRefTable.IndexOf(current);
                    resp = ref1 != -1 ? _bRefTable[ref1] : _empty;
                    break;
                case WorkAction.EncodeBToF:
                    ref1 = _bRefTable.IndexOf(current);
                    resp = ref1 != -1 ? _fRefTable[ref1] : _empty;
                    break;
                case WorkAction.DecodeFToB:
                    ref1 = _fRefTable.IndexOf(current);
                    resp = ref1 != -1 ? _bRefTable[ref1] : _empty;
                    break;
                case WorkAction.DecodeBToD:
                    ref1 = _bRefTable.IndexOf(current);
                    resp = ref1 != -1 ? _dRefTable[ref1] : _empty;
                    break;
            }

            return resp;
        }

        private enum WorkAction
        {
            EncodeDToB,
            EncodeBToF,
            DecodeFToB,
            DecodeBToD
        }
    }
}
