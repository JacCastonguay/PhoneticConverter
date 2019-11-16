using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticTranslator
{
    public static class Translation
    {
        public static string LetterSubstitution(string phrase)
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
                if (i > 0)
                {
                    last = current;
                    current = next;
                    if (i < phonetic.Length - 1)
                        next = phonetic[i + 1];
                    else
                        next = '|';
                }
                else if (i == 0)
                {
                    last = '|';
                    current = phonetic[0];
                    next = phonetic[1];
                }

                //TODO: Does not account for x, e before coda, tildes (only need to change to regular), n changes, l changes, nasal vowels, s derrivatives, ʎismo, ʃismo
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
                    case 'y':
                        YModifier(ref phonetic, last, ref current, i);
                        break;
                    ////Here we go
                    case 'l':
                        LModifier(ref phonetic, next, last, ref current , ref i);
                        break;
                    case 'c':
                        CModifier(ref phonetic, ref next, ref current, ref i);
                        break;
                    //Limiting /s/ to [s] & [z]. Might expand later.
                    case 's':
                        SModifier(ref phonetic, ref current, next, ref i);
                        break;
                    case 'q':
                        QModifier(ref phonetic, ref current, ref next, ref i);
                        break;
                    case 'h':
                        HModifier(ref phonetic, ref current, last, ref next, ref i);
                        break;
                    case 'r':
                        RModifier(ref phonetic, last, ref current, ref next, ref i);
                        break;
                    case 'x':
                        XModifier(ref phonetic, ref current, next, ref i);
                        break;
                    default:
                        break;
                }
            }
            return phonetic.ToString();
        }

        private static void RModifier(ref StringBuilder phonetic, char last, ref char current, ref char next, ref int i)
        {
            if (last == '|')//r
            {

            }
            else if (next == 'r') //<rr> -> [r]
            {
                //if (phonetic.Length > i + 2)
                //    next = phonetic[i + 2];
                //else
                //    next = '|';
                current = last;
                next = 'R';
                phonetic.Remove(i + 1, 1);
                i--;
            }
            //since rr gets changed to r and r gets turned to ɾ when we revisit, R will be temperarily assigned to be turned back into r
            else if (current == 'R')
            {
                phonetic[i] = 'r';
                current = 'r';
            }
            else //ɾ
            {
                phonetic[i] = 'ɾ';
                current = 'ɾ';
            }
        }

        private static void HModifier(ref StringBuilder phonetic, ref char current, char last, ref char next, ref int i)
        {
            //need to assign for last in order to set up for next
            current = last;
            phonetic.Remove(i, 1);
            i--;
        }
        private static void QModifier(ref StringBuilder phonetic, ref char current, ref char next, ref int i)
        {
            //Nahuatl based words might have <q>s without <u>s, I am not accounting for those yet.
            phonetic[i] = 'k';
            current = 'k';
            next = current;
            phonetic.Remove(i + 1, 1);
            i--;
        }


        private static void CModifier(ref StringBuilder phonetic, ref char next, ref char current, ref int i)
        {
            if (next == 'h')
            {
                phonetic[i] = 'ʧ';
                current = 'ʧ';
                next = current;
                phonetic.Remove(i + 1, 1);
                i--;
            }
            else if (Classifications.cModifiers.Contains(next))
            {
                phonetic[i] = 's';
                current = 's';
            }
            else
            {
                phonetic[i] = 'k';
                current = 'k';
            }
        }

        private static void LModifier(ref StringBuilder phonetic, char next, char last, ref char current, ref int i)
        {
            if (next == 'l')// <ll> -> /y/ -> [ʝ], [ɉ]
            {
                //Change ll to y
                phonetic[i] = 'y';
                current = 'y';
                YModifier(ref phonetic, last, ref current, i);
                phonetic.Remove(i+1, 1);
                i--;
            }
        }

        private static void YModifier(ref StringBuilder phonetic, char last, ref char current, int i)
        {
            if (!Classifications.bdgNonModifiers.Contains(last) && last != 'l')
            {
                phonetic[i] = 'ʝ';
                current = 'ʝ';
            }
            else
            {
                phonetic[i] = 'ɉ';
                current = 'ɉ';
            }
        }

        private static void GModifier(ref StringBuilder phonetic, char last, ref char current, char next, int i)
        {
            if (Classifications.cModifiers.Contains(next))
            {
                phonetic[i] = 'x';
                current = 'x';
            }
            else if (!Classifications.bdgNonModifiers.Contains(last))
            {
                phonetic[i] = 'Ɣ';
                current = 'Ɣ';
            }
        }

        private static void DModifier(ref StringBuilder phonetic, char last, ref char current, int i)
        {
            if (!Classifications.bdgNonModifiers.Contains(last) && last != 'l')
            {
                phonetic[i] = 'ð';
                current = 'ð';
            }
        }

        private static void BVModifier(ref StringBuilder phonetic, char last, ref char current, int i)
        {
            if (!Classifications.bdgNonModifiers.Contains(last))
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
            if (Classifications.vowels.Contains(last) || Classifications.vowels.Contains(next))
            {
                phonetic[i] = 'j';
                current = 'j';
            }

        }

        private static void UModifier(ref StringBuilder phonetic, int i, ref char current, char last, char next)
        {
            if (Classifications.vowels.Contains(last) || Classifications.vowels.Contains(next))
            {
                phonetic[i] = 'w';
                current = 'w';
            }

        }

        private static void JModifier(ref StringBuilder phonetic, int i, ref char current)
        {
            phonetic[i] = 'x';
            current = 'x';
        }

        private static void SModifier(ref StringBuilder phonetic, ref char current, char next, ref int i)
        {
            //TODO: Move to inter-word check (to be created)
            //if (next == 'r')//S is generally silent before [r]
            //{
            //    phonetic.Remove(i, 1);
            //    i = i--;
            //}
            //else 
            if (Classifications.sonaras.Contains(next))
            {
                phonetic[i] = 'z';
                current = 'z';
            }
        }

        private static void XModifier(ref StringBuilder phonetic, ref char current, char next, ref int i)
        { 
            //phonetic[i] = 'z';
            //current = 'z';
            phonetic.Remove(i, 1);
            phonetic.Insert(i, "ks");
            current = 's';
            i++;
        }
    }
}
