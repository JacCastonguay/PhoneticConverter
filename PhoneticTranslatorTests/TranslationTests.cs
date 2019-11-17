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
            string bɾuxo = Translation.LetterSubstitution("brujo");
            Assert.AreEqual("bɾuxo", bɾuxo);

            string xamón = Translation.LetterSubstitution("jamón");
            Assert.AreEqual("xamón", xamón);
        }

        [TestMethod()]
        public void LetterSubstitueUTest()
        {
            string awtoɾ = Translation.LetterSubstitution("autor");
            Assert.AreEqual("awtoɾ", awtoɾ);

            string bɾuxo = Translation.LetterSubstitution("brujo");
            Assert.AreEqual("bɾuxo", bɾuxo);
        }

        [TestMethod()]
        public void LetterSubITest()
        {
            string bjen = Translation.LetterSubstitution("bien");
            Assert.AreEqual("bjen", bjen);

            string isla = Translation.LetterSubstitution("isla");
            Assert.AreEqual("isla", isla);
        }

        [TestMethod()]
        public void LetterSubVBTest()
        {
            string bjen = Translation.LetterSubstitution("bien");
            Assert.AreEqual("bjen", bjen);

            string bota = Translation.LetterSubstitution("vota");
            Assert.AreEqual("bota", bota);

            string beße = Translation.LetterSubstitution("bebe");
            Assert.AreEqual("beße", beße);

            string ombɾe = Translation.LetterSubstitution("hombre");
            Assert.AreEqual("ombɾe", ombɾe);

            string ußa = Translation.LetterSubstitution("uva");
            Assert.AreEqual("ußa", ußa);
        }

        [TestMethod()]
        public void LetterSubDTest()
        {
            string deðo = Translation.LetterSubstitution("dedo");
            Assert.AreEqual("deðo", deðo);

            string eldoɾamdo = Translation.LetterSubstitution("eldoramdo"); //Not a real word btw
            Assert.AreEqual("eldoɾamdo", eldoɾamdo);
        }

        [TestMethod()]
        public void LetterSubGTest()
        {
            string xiƔantiko = Translation.LetterSubstitution("gigantico");
            Assert.AreEqual("xiƔantiko", xiƔantiko);

            string gɾingo = Translation.LetterSubstitution("gringo");
            Assert.AreEqual("gɾingo", gɾingo);
        }

        [TestMethod()]
        public void LetterSubYTest()
        {
            string baʝa = Translation.LetterSubstitution("vaya");
            Assert.AreEqual("baʝa", baʝa);

            string unɉanki = Translation.LetterSubstitution("unyanqui");//Not a real word
            Assert.AreEqual("unɉanki", unɉanki);

            string elɉoðo = Translation.LetterSubstitution("elyodo");//Not a real word
            Assert.AreEqual("elɉoðo", elɉoðo);
        }

        [TestMethod()]
        public void LetterSubLTest()
        {
            string laðo = Translation.LetterSubstitution("lado");
            Assert.AreEqual("laðo", laðo);

            string ɉamo = Translation.LetterSubstitution("llamo");
            Assert.AreEqual("ɉamo", ɉamo);

            string siʝa = Translation.LetterSubstitution("silla");
            Assert.AreEqual("siʝa", siʝa);
        }

        [TestMethod()]
        public void LetterSubCTest()
        {
            string ʧiko = Translation.LetterSubstitution("chico");
            Assert.AreEqual("ʧiko", ʧiko);

            string nesesito = Translation.LetterSubstitution("necesito");
            Assert.AreEqual("nesesito", nesesito);
        }

        [TestMethod()]
        public void LetterSubSTest()
        {
            string dezðe = Translation.LetterSubstitution("desde");
            Assert.AreEqual("dezðe", dezðe);

            string sopa = Translation.LetterSubstitution("sopa");
            Assert.AreEqual("sopa", sopa);
        }

        [TestMethod()]
        public void LetterSubQTest()
        {
            string keɾeɾ = Translation.LetterSubstitution("querer");
            Assert.AreEqual("keɾeɾ", keɾeɾ);

            string takeɾía = Translation.LetterSubstitution("taquería");
            Assert.AreEqual("takeɾía", takeɾía);
        }

        [TestMethod()]
        public void LetterSubHTest()
        {
            string ixo = Translation.LetterSubstitution("hijo");
            Assert.AreEqual("ixo", ixo);

            string ʧiwawa = Translation.LetterSubstitution("chihuahua");
            Assert.AreEqual("ʧiwawa", ʧiwawa);

            //ahumado will give us issues currently. add h flag?
            //spanishdict says is pronounce aw.ma.do, search for rule?
        }

        [TestMethod()]
        public void LetterSubRTest()
        {
            string riko = Translation.LetterSubstitution("rico");
            Assert.AreEqual("riko", riko);

            string taɾea = Translation.LetterSubstitution("tarea");
            Assert.AreEqual("taɾea", taɾea);

            string fjera = Translation.LetterSubstitution("fierra");
            Assert.AreEqual("fjera", fjera);
        }

        [TestMethod()]
        public void LetterXTest()
        {
            string eksiste = Translation.LetterSubstitution("existe");
            Assert.AreEqual("eksiste", eksiste);

            string eksplika = Translation.LetterSubstitution("explica");
            Assert.AreEqual("eksplika", eksplika);
        }

        [TestMethod()]
        public void RandomTests()
        {
            //last r was left unchanged.
            string kompɾaɾ = Translation.LetterSubstitution("comprar");
            Assert.AreEqual("kompɾaɾ", kompɾaɾ);
        }
    }
}