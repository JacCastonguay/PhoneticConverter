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
            char last = '|';
            char current = phrase[0];
            char next = phrase[1];

            for (int i = 0; i < phrase.Length; i++)
            {
                switch (phrase[i])
                {
                    //Simple replacement
                    case 'j': //lol there are actually two 'x's, will change that eventually.
                        phrase = phrase.Insert(i, "x");
                        phrase = phrase.Remove(i+1, 1);
                        current = 'x';
                        //1 for 1, no need to adjust i.
                        break;
                    case 'u'://since ú is a different char, we can always change u
                        phrase = phrase.Insert(i, "w");
                        phrase = phrase.Remove(i + 1, 1);
                        current = 'w';
                        break;
                    case 'i'://since í is a different char, we can always change u
                        phrase = phrase.Insert(i, "j");
                        phrase = phrase.Remove(i + 1, 1);
                        current = 'j';
                        break;
                    //More complex
                    case 'b':
                        if (!Conventions.bdgNonModifiers.Contains(last))
                        {
                            phrase = phrase.Insert(i, "ß");
                            phrase = phrase.Remove(i + 1, 1);
                            current = 'ß';
                        }
                        break;
                    case 'd':
                        if (!Conventions.bdgNonModifiers.Contains(last) && last != 'l')
                        {
                            phrase = phrase.Insert(i, "ð");
                            phrase = phrase.Remove(i + 1, 1);
                            current = 'ð';
                        }
                        break;
                    case 'g':
                        if (Conventions.cModifiers.Contains(next))
                        {
                            phrase = phrase.Insert(i, "x");
                            phrase = phrase.Remove(i + 1, 1);
                            current = 'x';
                        }
                        else if(!Conventions.bdgNonModifiers.Contains(last))
                        {
                            phrase = phrase.Insert(i, "Ɣ");
                            phrase = phrase.Remove(i + 1, 1);
                            current = 'Ɣ';
                        }
                        break;
                    case 'y':
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
                        break;
                    //Here we go
                    case 'l':
                        if (next == 'l')
                        {
                            phrase = phrase.Insert(i, "ʝ");
                            phrase = phrase.Remove(i + 1, 2);
                            current = 'ʝ';
                        }
                        else
                        {
                            phrase = phrase.Insert(i, "ɉ");
                            phrase = phrase.Remove(i + 1, 2);
                            current = 'ɉ';
                        }
                        i--;
                        break;
                    case 'c':
                        if(next == 'h')
                        {
                            phrase = phrase.Insert(i, "ʧ");
                            phrase = phrase.Remove(i + 1, 2);
                            current = 'ʧ';
                            i--;
                        }
                        else if (Conventions.cModifiers.Contains(next))
                        {
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
                        break;

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

            return phrase;
        }
    }
}
