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

            //pauses
            phrase = phrase.Replace(",", "|");
            phrase = phrase.Replace(".", "||");

            phrase = SimpleSubstitute(phrase);

            TBResults.Text = phrase;
        }

        private static string SimpleSubstitute(string phrase)
        {
            for (int i = 0; i < phrase.Length; i++)
            {
                if (Conventions.easyFlips.ContainsKey(phrase[i].ToString()))
                {
                    string letter = phrase[i].ToString();
                    phrase = phrase.Remove(i, 1);
                    phrase = phrase.Insert(i, Conventions.easyFlips[letter]);
                    //adjust for new length
                    i += Conventions.easyFlips[letter].Length;
                }
            }

            return phrase;
        }
    }
}
