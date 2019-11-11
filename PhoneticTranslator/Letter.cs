using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticTranslator
{
    class Letter
    {
        public char phonema { get; }
        public char typeLetter { get; }

        public Letter(char letter)
        {
            phonema = letter;
            if (Classifications.phoneticvowels.Contains(letter))
            {
                typeLetter = 'V';
            }
            else
            {
                typeLetter = 'C';
            }
        }
    }
}
