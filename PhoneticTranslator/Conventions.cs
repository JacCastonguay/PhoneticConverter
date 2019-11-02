using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticTranslator
{
    static class Conventions
    {
        public static readonly List<string> consonantBlends = new List<string>()
        {"bl", "fl", "cl", "gl", "pl", "cr", "br", "tr", "gr", "fr", "pr", "dr", "tl"};

        public static readonly List<char> vowels = new List<char>()
        {'a', 'e', 'o', 'i', 'u'};

        public static readonly List<char> strongVowels = new List<char>()
        {'a', 'e', 'o'};

        public static readonly List<char> diptongs = new List<char>()
        {'i', 'u'};

        public static readonly List<char> cModifiers = new List<char>()
        {'i', 'e'};

        //public static readonly Dictionary<string, string> easyFlips = new Dictionary<string, string>() 
        //{
        //    {"j", "x"}, {"v","b"}, {"h","" }
        //};

        public static readonly List<char> bdgNonModifiers = new List<char>()
        {'|','m','n','ɲ' };//ɲ will have already been changed
    }
}
