using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideProjects
{
    class CaesarCipher
    {
        private string Sentence;
        private int Shift;
        private bool IsEncrypted = false;

        public CaesarCipher(string input, int shifting)
        {
            Sentence = input;
            Shift = shifting;
        }

        public string Encrypt()
        {
            if (IsEncrypted)
                return Sentence;
            throw new NotImplementedException();
        }

        public string Decrypt()
        {
            if (!IsEncrypted)
                return Sentence;
            throw new NotImplementedException();
        }
    }
}
