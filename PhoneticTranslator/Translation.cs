﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticTranslator
{
    public static class Translation
    {
        public static string LetterSubstitue(string phrase)
        {
            //change to string builder. use ref.
            StringBuilder phonetic = new StringBuilder(phrase);
            char last = '|';
            char current = phonetic[0];
            char next = phonetic[1];

            //TODO: can probably wait to assign phonetic index until the end of the loop, but should consider ll -> ʝ, ch -> ʧ, etc first
            //Probably move this to its own class and set up automated tests.
            for (int i = 0; i < phonetic.Length; i++)
            {
                if (i != 0)
                {
                    last = current;
                    current = next;
                    if (i < phonetic.Length - 1)
                        next = phonetic[i + 1];
                    else
                        next = '|';
                }

                switch (current)
                {
                    //Simple replacement
                    case 'j': //lol there are actually two 'x's, will change that eventually.
                        JModifier(ref phonetic, i, ref current);
                        break;
                    case 'u'://since ú is a different char, we can always change u
                        UModifier(ref phonetic, i, ref current, last, next);
                        break;
                    case 'i'://since í is a different char, we can always change u
                        IModifier(ref phonetic, i, ref current, last, next);
                        break;
                    ////More complex
                    case 'b':
                        BVModifier(ref phonetic, last, ref current, i);
                        break;
                    case 'v':
                        BVModifier(ref phonetic, last, ref current, i);
                        break;
                    case 'd':
                        DModifier(ref phonetic, last, ref current, i);
                        break;
                    case 'g':
                        GModifier(ref phonetic, last, ref current, next, i);
                        break;
                    //case 'y':
                    //    current = YModifier(ref phrase, last, i);
                    //    break;
                    ////Here we go
                    //case 'l':
                    //    current = LModifier(ref phrase, next, ref i);
                    //    break;
                    //case 'c':
                    //    current = CModifier(ref phrase, next, ref i);
                    //    break;
                    ////Limiting /s/ to [s] & [z]. Might expand later.
                    //case 's':
                    //    current = SModifier(ref phrase, next, ref i);
                    //    break;
                    default:
                        break;
                }

            }

            return phonetic.ToString();
        }

        private static char CModifier(ref string phrase, char next, ref int i)
        {
            char current;
            if (next == 'h')
            {
                phrase = phrase.Insert(i, "ʧ");
                phrase = phrase.Remove(i + 1, 2);
                current = 'ʧ';
                i--;
            }
            else if (Conventions.cModifiers.Contains(next))
            {
                //Need to change to SModifier
                phrase = phrase.Insert(i, "s");
                phrase = phrase.Remove(i + 1, 1);
                current = 's';
            }
            else
            {
                phrase = phrase.Insert(i, "k");
                phrase = phrase.Remove(i + 1, 1);
                current = 'k';
            }

            return current;
        }

        private static char LModifier(ref string phrase, char next, ref int i)
        {
            char current;
            if (next == 'l')
            {
                phrase = phrase.Insert(i, "ʝ");
                phrase = phrase.Remove(i + 1, 2);
                current = 'ʝ';
            }
            else
            {
                phrase = phrase.Insert(i, "ɉ");
                phrase = phrase.Remove(i + 1, 1);
                current = 'ɉ';
            }
            i--;
            return current;
        }

        private static char YModifier(ref string phrase, char last, int i)
        {
            char current;
            if (!Conventions.bdgNonModifiers.Contains(last) && last != 'l')
            {
                phrase = phrase.Insert(i, "ʝ");
                phrase = phrase.Remove(i + 1, 1);
                current = 'ʝ';
            }
            else
            {
                phrase = phrase.Insert(i, "ɉ");
                phrase = phrase.Remove(i + 1, 1);
                current = 'ɉ';
            }

            return current;
        }

        private static void GModifier(ref StringBuilder phonetic, char last, ref char current, char next, int i)
        {
            if (Conventions.cModifiers.Contains(next))
            {
                phonetic[i] = 'x';
                current = 'x';
            }
            else if (!Conventions.bdgNonModifiers.Contains(last))
            {
                phonetic[i] = 'Ɣ';
                current = 'Ɣ';
            }
        }

        private static void DModifier(ref StringBuilder phonetic, char last, ref char current, int i)
        {
            if (!Conventions.bdgNonModifiers.Contains(last) && last != 'l')
            {
                phonetic[i] = 'ð';
                current = 'ð';
            }
        }

        private static void BVModifier(ref StringBuilder phonetic, char last, ref char current, int i)
        {
            if (!Conventions.bdgNonModifiers.Contains(last))
            {
                phonetic[i] = 'ß';
                current = 'ß';
            }
            else if (current == 'v')//<v> doesn't exist, if not [ß] replace with [b]
            {
                phonetic[i] = 'b';
                current = 'b';
            }
        }

        private static void IModifier(ref StringBuilder phonetic, int i, ref char current, char last, char next)
        {
            if (Conventions.vowels.Contains(last) || Conventions.vowels.Contains(next))
            {
                phonetic[i] = 'j';
                current = 'j';
            }

        }

        private static void UModifier(ref StringBuilder phonetic, int i, ref char current, char last, char next)
        {
            if (Conventions.vowels.Contains(last) || Conventions.vowels.Contains(next))
            {
                phonetic[i] = 'w';
                current = 'w';
            }

        }

        private static void JModifier(ref StringBuilder phonetic, int i, ref char current)
        {
            phonetic[i] = 'x';
            current = 'x';
            //1 for 1, no need to adjust i.
        }

        //TODO: apply and test.
        private static char SModifier(ref string phrase, char next, ref int i)
        {
            char current;
            if (next == 'r')//S is generally silent before [r]
            {
                current = next;
                phrase = phrase.Remove(i + 1, 1);
                i = i--;
            }
            else if (Conventions.sonaras.Contains(next))
            {
                phrase = phrase.Insert(i, "z");
                phrase = phrase.Remove(i + 1, 1);
                current = 'z';
            }
            else
            {
                current = 's';
            }

            return current;
        }
    }
}
