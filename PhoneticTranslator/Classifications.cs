using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticTranslator
{
    static class Classifications
    {
        public static readonly List<string> consonantBlends = new List<string>()
        {"bl", "fl", "cl", "gl", "pl", "cr", "br", "tr", "gr", "fr", "pr", "dr", "tl"};

        public static readonly List<string> phoneticConsonantBlends = new List<string>()
        {"bl", "ßl",  "fl", "kl", "gl", "Ɣl", "pl", "kɾ", "bɾ", "ßɾ", "tɾ", "gɾ", "Ɣɾ", "fɾ", "pɾ", "dɾ", "ðɾ" , "tl"};

        public static readonly List<char> phoneticConsonants = new List<char>()
        {'b', 'ß', 'ʧ', 'd', 'ð', 'f', 'g', 'Ɣ', 'ʝ', 'ɉ', 'k', 'l', 'm', 'n', 'ɲ', 'p', 'r', 'ɾ', 's', 't', 'x', 'z'}; //j & w are diptongs and are not consonants in this context

        public static readonly List<char> vowels = new List<char>()
        {'a', 'e', 'o', 'i', 'u'};

        public static readonly List<char> phoneticvowels = new List<char>()
        {'a', 'e', 'o', 'i', 'u', 'w', 'j'};

        public static readonly List<char> strongVowels = new List<char>()
        {'a', 'e', 'o'};

        public static readonly List<char> diptongs = new List<char>()
        {'i', 'u'};

        public static readonly List<char> cModifiers = new List<char>()
        {'i', 'e'};

        //TODO: do nasals count as sonoras?
        public static readonly List<char> sonaras = new List<char>()
        {'b', 'd', 'ɉ', 'g', 'v', 'x', 'ß', 'ð', 'Ɣ'};

        public static readonly List<char> bdgNonModifiers = new List<char>()
        {'|','m','n','ɲ' };//ɲ will have already been changed
    }
}
