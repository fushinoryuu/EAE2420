namespace SideProjects
{
    class CaesarCipher
    {
        private string Sentence;
        private int EncryptShift;
        private int DecryptShift;
        private bool IsEncrypted = false;

        public CaesarCipher(string input, int shifting)
        {
            Sentence = input.ToLower();
            EncryptShift = shifting;
            DecryptShift = -shifting;
        }

        public string Encrypt()
        {
            if (IsEncrypted)
                return Sentence;

            char[] char_array = Sentence.ToCharArray();

            Shuffle(char_array, EncryptShift);

            Recunstruct(char_array);

            return Sentence;
        }

        public string Decrypt()
        {
            if (!IsEncrypted)
                return Sentence;

            char[] char_array = Sentence.ToCharArray();

            Shuffle(char_array, DecryptShift);

            Recunstruct(char_array);

            return Sentence;
        }

        private void Shuffle(char[] char_array, int shift)
        {
            for (int index = 0; index < char_array.Length; index++)
            {
                char letter = char_array[index];

                if (letter >= 'a' && letter <= 'z')
                {
                    letter = (char)(letter + shift);

                    if (letter > 'z')
                        letter = (char)(letter - 26);

                    else if (letter < 'a')
                        letter = (char)(letter + 26);
                }

                char_array[index] = letter;
            }
        }

        private void Recunstruct(char[] char_array)
        {
            Sentence = null;

            foreach (char letter in char_array)
                Sentence += letter;

            IsEncrypted = true;
        }
    }
}
