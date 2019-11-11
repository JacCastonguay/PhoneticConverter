using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticTranslator
{
    public class Word
    {
        public string word {get;}
        public List<int> points = new List<int>();
        private List<Letter> Syls { get;}

        //TODO: Doesn't account for [ks] + C Ex: existe -> ek.sis.te, but experencía -> eks.pe.....
        public Word(string _word)
        {
            Syls = new List<Letter>();

            foreach (char letter in _word)
            {
                Letter ltr = new Letter(letter);
                Syls.Add(ltr);
            }

            FindPointPositions();

            //Put together.
        }

        private void FindPointPositions()
        {
            for (int i = 0; i < Syls.Count - 1; i++)//i < syls.Count - 1 because we're checking between chars and don't need to check between last & null
            {
                if (Syls[i].typeLetter == 'V')
                {
                    //[V]V -> V.V (add)
                    //[V*]V or [V*]V -> VV (nothing)
                    //ALL VV
                    if (Syls[i + 1].typeLetter == 'V')
                    {
                        //[V]V -> V.V (add)
                        if (Classifications.strongVowels.Contains(Syls[i].phonema) &&
                            Classifications.strongVowels.Contains(Syls[i + i].phonema))
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
                        if (Syls.Count > i + 2)
                        {
                            //if VCV -> V.CV
                            if (Classifications.strongVowels.Contains(Syls[i + 2].typeLetter))
                            {
                                points.Add(i);
                            }
                            else//VCC
                            {
                                //VCC (joinable) -> V.CC
                                if (Classifications.phoneticConsonantBlends.Contains((Syls[i + 1].phonema + Syls[i + 2].phonema).ToString()))
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

                    if (Syls[i + 1].typeLetter == 'C')
                    {
                        string potentialBlend = Syls[i].phonema.ToString() + Syls[i + 1].phonema.ToString();
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
    }
}
