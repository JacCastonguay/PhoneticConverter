using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneticTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            string phrase = TBPhrase.Text.ToLower();
            //quick special words fix
            phrase = phrase.Replace(" y ", " Y ");
            phrase = phrase.Replace(" un ", " UN ");
            phrase = phrase.Replace(" una ", " UNA ");

            //Remove all spacing
            phrase = phrase.Replace(" ", string.Empty);

            //Remove pauses
            phrase = phrase.Replace(",", "|");
            phrase = phrase.Replace(".", "||");


            //Replace characters that are have s
            phrase = LetterSubstitue(phrase);
            //acentuate

            //resilaficación. How do I check if against un/una (and others)? thought is maybe capitalize the words before hand so they don't get turned to 'w's.
                                //if not, will have to acentuate before letter conversion.

            //modify coda


            TBResults.Text = phrase;
        }

        private static string LetterSubstitue(string phrase)
        {
            //change to string builder. use ref.
            char last = '|';
            char current = phrase[0];
            char next = phrase[1];
            StringBuilder phonetic = new StringBuilder(phrase);


            for (int i = 0; i < phonetic.Length; i++)
            {
                switch (phrase[i])
                {
                    //Simple replacement
                    case 'j': //lol there are actually two 'x's, will change that eventually.
                        JModifier(ref phonetic, i, ref current);
                        break;
                    //TODO: will currently incorrectly convert a llena with a <u> by itself in the pen-ultimate position (Do those exist?)
                    case 'u'://since ú is a different char, we can always change u
                        UModifier(ref phonetic, i, ref current);
                        break;
                    //case 'i'://since í is a different char, we can always change u
                    //    current = IModifier(ref phrase, i);
                    //    break;
                    ////More complex
                    //case 'b':
                    //    BVModifier(ref phrase, last, ref current, i);
                    //    break;
                    //case 'v':
                    //    BVModifier(ref phrase, last, ref current, i);
                    //    break;
                    //case 'd':
                    //    DModifier(ref phrase, last, ref current, i);
                    //    break;
                    //case 'g':
                    //    GModifier(ref phrase, last, ref current, next, i);
                    //    break;
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


                last = current;
                current = next;
                if (i < phrase.Length - 1)
                    next = phrase[i + 1];
                else
                    next = '|';
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

        private static void GModifier(ref string phrase, char last, ref char current, char next, int i)
        {
            if (Conventions.cModifiers.Contains(next))
            {
                phrase = phrase.Insert(i, "x");
                phrase = phrase.Remove(i + 1, 1);
                current = 'x';
            }
            else if (!Conventions.bdgNonModifiers.Contains(last))
            {
                phrase = phrase.Insert(i, "Ɣ");
                phrase = phrase.Remove(i + 1, 1);
                current = 'Ɣ';
            }
        }

        private static void DModifier(ref string phrase, char last, ref char current, int i)
        {
            if (!Conventions.bdgNonModifiers.Contains(last) && last != 'l')
            {
                phrase = phrase.Insert(i, "ð");
                phrase = phrase.Remove(i + 1, 1);
                current = 'ð';
            }
        }

        private static void BVModifier(ref string phrase, char last, ref char current, int i)
        {
            if (!Conventions.bdgNonModifiers.Contains(last))
            {
                phrase = phrase.Insert(i, "ß");
                phrase = phrase.Remove(i + 1, 1);
                current = 'ß';
            }
            else if (current == 'v')//TODO: test
            {
                phrase = phrase.Insert(i, "b");
                phrase = phrase.Remove(i + 1, 1);
                current = 'b';
            }
        }

        private static char IModifier(ref string phrase, int i)
        {
            char current;
            phrase = phrase.Insert(i, "j");
            phrase = phrase.Remove(i + 1, 1);
            current = 'j';
            return current;
        }

        private static void UModifier(ref StringBuilder phonetic, int i, ref char current)
        {
            phonetic[i] = 'w';
            current = 'w';
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
