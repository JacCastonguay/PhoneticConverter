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

            /*##########################
             * current goal: Ability to transcribe any single word
             * 
             #########################*/

            if (TBPhrase.Text.Contains(" "))
            {
                MessageBox.Show("Right now, you can only convert individual words");
                return;
            }
            string phrase = TBPhrase.Text.ToLower();
            //quick special words fix
            phrase = phrase.Replace(" y ", " Y ");
            phrase = phrase.Replace(" un ", " UN ");
            phrase = phrase.Replace(" una ", " UNA ");

            //Remove all spacing
            //phrase = phrase.Replace(" ", string.Empty);

            //Remove pauses
            //phrase = phrase.Replace(",", "|");
            //phrase = phrase.Replace(".", "||");

            //Replace characters that are have s
            Word word = new Word(Translation.LetterSubstitution(phrase));
            string response = word.word;
            //acentuate

            //resilaficación. How do I check if against un/una (and others)? thought is maybe capitalize the words before hand so they don't get turned to 'w's.
                                //if not, will have to acentuate before letter conversion.

            //modify coda

            TBResults.Text = response;
        }
    }
}
