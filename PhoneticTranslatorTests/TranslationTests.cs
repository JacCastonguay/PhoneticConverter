﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}