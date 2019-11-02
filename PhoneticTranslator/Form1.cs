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
            //Remove all spacing
            phrase = phrase.Replace(" ", string.Empty);

            //Remove pauses
            phrase = phrase.Replace(",", "|");
            phrase = phrase.Replace(".", "||");


            //Replace characters that are have s
            phrase = LetterSubstitue(phrase);
            //acentuate

            //silaficación

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
