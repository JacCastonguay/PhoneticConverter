using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticTranslator
{
    public class Word
    {
        public string word { get; set; }
        public List<int> points = new List<int>();

        private List<Letter> Letters { get;}
        private bool containsRulebreaker = false;
        private string unsyllabilizedWord;

        //TODO: Doesn't account for [ks] + C Ex: existe -> ek.sis.te, but experencía -> eks.pe.....
        public Word(string _word)
        {
            _word = Translation.LetterSubstitution(_word);

            Letters = new List<Letter>();
            if (_word.Contains("sp") || _word.Contains("sk") || _word.Contains("st"))
                containsRulebreaker = true;
            unsyllabilizedWord = _word;

            foreach (char letter in _word)
            {
                Letter ltr = new Letter(letter);
                Letters.Add(ltr);
            }

            FindPointPositions();

            if (containsRulebreaker)
                SPSKFix();
            //Put together.
            PutTogether();
        }

        private void FindPointPositions()
        {
            for (int i = 0; i < Letters.Count - 1; i++)//i < syls.Count - 1 because we're checking between chars and don't need to check between last & null
            {
                if (Letters[i].typeLetter == 'V')
                {
                    //[V]V -> V.V (add)
                    //[V*]V or [V*]V -> VV (nothing)
                    //ALL VV
                    if (Letters[i + 1].typeLetter == 'V')
                    {
                        //[V]V -> V.V (add)
                        if (Classifications.strongVowels.Contains(Letters[i].phonema) &&
                            Classifications.strongVowels.Contains(Letters[i + i].phonema))
                        {
                            points.Add(i);
                        }
                        //[V*]V or [V*]V -> VV (nothing)
                    }
                    //[V]C
                    //if VCC(joinable)
                    //V.CC (add)
                    //if VCC(not join)
                    //VC.C (nothing)
                    //if VC_(empty)
                    //nothing
                    //if VCV
                    //V.CV (add)
                    else//ALL VC
                    {
                        if (Letters.Count > i + 2)
                        {
                            //if VCV -> V.CV
                            if (Letters[i + 2].typeLetter == 'V')
                            {
                                points.Add(i);
                            }
                            else//VCC
                            {
                                //VCC (joinable) -> V.CC
                                if (Classifications.phoneticConsonantBlends.Contains((Letters[i + 1].phonema + Letters[i + 2].phonema).ToString()))
                                    points.Add(i);
                                //else VC.C (handled next by CC)
                            }
                        }
                        else
                        { }//VC_(empty) nothing
                    }


                }
                else//C
                {
                    //[C]V -> CV
                    //[C]C 
                    //if joinable CC
                    // else C.C
                    if (Letters[i + 1].typeLetter == 'C')
                    {
                        string potentialBlend = Letters[i].phonema.ToString() + Letters[i + 1].phonema.ToString();
                        //joinable CC -> CC
                        if (Classifications.phoneticConsonantBlends.Contains(potentialBlend))
                        { }
                        //CC -> C.C
                        else
                            points.Add(i);
                    }
                    //else [C]V -> CV
                }
            }
        }

        private void SPSKFix()
        {
            //This will go wack if there's any words with two <x>s. (Never seen that before)
            List<int> ruleBreakers = new List<int>();
            int temp = unsyllabilizedWord.IndexOf("sp"); //returns -1 if not there. which might throw an error later.
            if (temp > 0)
                ruleBreakers.Add(temp);
            temp = unsyllabilizedWord.IndexOf("sk");
            if (temp > 0)
                ruleBreakers.Add(temp);
            temp = unsyllabilizedWord.IndexOf("st");
            if (temp > 0)
                ruleBreakers.Add(temp);

            /*
             * target = i - 1
             * s = i
             * k/p = i+1
             * recall: seperate when 
             */
            foreach (int rb in ruleBreakers)
                points.Remove(rb - 1); //No biggie if it's not there
            
        }

        private void PutTogether()
        {
            word = unsyllabilizedWord;
            int offset = 0;// Each <.> added will increase where the next should be added.
            for(int i = 0; i < points.Count; i++)
            {
                word = word.Insert(points[i] + 1 + offset, ".");//+1 is so the period comes after the letter.
                offset++;
            }
        }
    }
}
