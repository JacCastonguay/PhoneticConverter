using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneticTranslator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticTranslator.Tests
{
    [TestClass()]
    public class TranslationTests
    {
        [TestMethod()]
        public void LetterSubstitueJTest()
        {
            string bruxo = Translation.LetterSubstitue("brujo");
            Assert.AreEqual("bruxo"[3], bruxo[3]);
            Assert.AreEqual("bruxo".Length, bruxo.Length);

            string xamón = Translation.LetterSubstitue("jamón");
            Assert.AreEqual("xamón"[0], xamón[0]);
            Assert.AreEqual("xamón".Length, xamón.Length);
        }

        [TestMethod()]
        public void LetterSubstitueUTest()
        {
            //Should only compare specific chars to avoid errors from other letters
            string awtor = Translation.LetterSubstitue("autor");
            Assert.AreEqual("awtor"[1], awtor[1]);
            Assert.AreEqual("awtor".Length, awtor.Length);

            string brujo = Translation.LetterSubstitue("brujo");
            Assert.AreEqual("brujo"[2], brujo[2]);
            Assert.AreEqual("brujo".Length, brujo.Length);
        }

        [TestMethod()]
        public void LetterSubITest()
        {
            string bjen = Translation.LetterSubstitue("bien");
            Assert.AreEqual("bjen"[1], bjen[1]);
            Assert.AreEqual("bjen".Length, bjen.Length);

            string isla = Translation.LetterSubstitue("isla");
            Assert.AreEqual("isla"[0], isla[0]);
            Assert.AreEqual("isla".Length, isla.Length);
        }

        [TestMethod()]
        public void LetterSubVBTest()
        {
            string bjen = Translation.LetterSubstitue("bien");
            Assert.AreEqual("bjen"[0], bjen[0]);
            Assert.AreEqual("bjen".Length, bjen.Length);

            string bota = Translation.LetterSubstitue("vota");
            Assert.AreEqual("bota"[0], bota[0]);
            Assert.AreEqual("bota".Length, bota.Length);

            string beße = Translation.LetterSubstitue("bebe");
            Assert.AreEqual("beße"[0], beße[0]);
            Assert.AreEqual("beße"[2], beße[2]);
            Assert.AreEqual("beße".Length, beße.Length);

            string ußa = Translation.LetterSubstitue("uva");
            Assert.AreEqual("ußa"[1], ußa[1]);
            Assert.AreEqual("ußa".Length, ußa.Length);
        }

        public void LetterSubDTest()
        {
            string deðo = Translation.LetterSubstitue("dedo");
            Assert.AreEqual("deðo"[0], deðo[0]);
            Assert.AreEqual("deðo"[2], deðo[2]);
            Assert.AreEqual("deðo".Length, deðo.Length);

            string eldoramdo = Translation.LetterSubstitue("eldoramdo"); //Not a real word btw
            Assert.AreEqual("eldoramdo"[2], eldoramdo[2]);
            Assert.AreEqual("eldoramdo"[8], eldoramdo[8]);
            Assert.AreEqual("eldoramdo".Length, eldoramdo.Length);
        }

        [TestMethod()]
        public void LetterSubGTest()
        {
            string xiƔantico = Translation.LetterSubstitue("gigantico");
            Assert.AreEqual("xiƔantico"[0], xiƔantico[0]);
            Assert.AreEqual("xiƔantico"[2], xiƔantico[2]);
            Assert.AreEqual("xiƔantico".Length, xiƔantico.Length);

            string gringo = "gringo";
            Assert.AreEqual("gringo"[0], gringo[0]);
            Assert.AreEqual("gringo".Length, gringo.Length);
        }

        [TestMethod()]
        public void LetterSubYTest()
        {
            string baʝa = Translation.LetterSubstitue("vaya");
            Assert.AreEqual("baʝa"[2], baʝa[2]);
            Assert.AreEqual("baʝa".Length, baʝa.Length);

            //Will change once q is implemented
            string unɉanqui = Translation.LetterSubstitue("unyanqui");//Not a real word
            Assert.AreEqual("unɉanqui"[2], unɉanqui[2]);
            Assert.AreEqual("unɉanqui".Length, unɉanqui.Length);

            string elɉoðo = Translation.LetterSubstitue("elyodo");//Not a real word
            Assert.AreEqual("elɉoðo"[2], elɉoðo[2]);
            Assert.AreEqual("elɉoðo".Length, elɉoðo.Length);
        }

        [TestMethod()]
        public void LetterSubLTest()
        {
            string laðo = Translation.LetterSubstitue("lado");
            Assert.AreEqual("laðo"[0], laðo[0]);
            Assert.AreEqual("laðo".Length, laðo.Length);

            string ɉamo = Translation.LetterSubstitue("llamo");
            Assert.AreEqual("ɉamo"[0], ɉamo[0]);
            Assert.AreEqual("ɉamo"[1], ɉamo[1]);
            Assert.AreEqual("ɉamo".Length, ɉamo.Length);

            string siʝa = Translation.LetterSubstitue("silla");
            Assert.AreEqual("siʝa"[2], siʝa[2]);
            Assert.AreEqual("siʝa"[3], siʝa[3]);
            Assert.AreEqual("siʝa".Length, siʝa.Length);
        }

        [TestMethod()]
        public void LetterSubCTest()
        {
            string ʧiko = Translation.LetterSubstitue("chico");
            Assert.AreEqual("ʧiko"[0], ʧiko[0]);
            Assert.AreEqual("ʧiko"[2], ʧiko[2]);
            Assert.AreEqual("ʧiko".Length, ʧiko.Length);

            string nesesito = Translation.LetterSubstitue("necesito");
            Assert.AreEqual("nesesito"[2], nesesito[2]);
            Assert.AreEqual("nesesito".Length, nesesito.Length);
        }

        [TestMethod()]
        public void LetterSubSTest()
        {
            string dezðe = Translation.LetterSubstitue("desde");
            Assert.AreEqual("dezðe"[1], dezðe[1]);
            Assert.AreEqual("dezðe".Length, dezðe.Length);

            string sopa = Translation.LetterSubstitue("sopa");
            Assert.AreEqual("sopa"[0], sopa[0]);
            Assert.AreEqual("sopa".Length, sopa.Length);
            
            string loricos = Translation.LetterSubstitue("losricos"); //Not a real word
            Assert.AreEqual("loricos"[2], loricos[2]);
            Assert.AreEqual("loricos".Length, loricos.Length);
        }
    }
}