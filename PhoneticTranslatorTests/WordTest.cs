using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneticTranslator;

namespace PhoneticTranslator.Tests
{
    [TestClass]
    public class WordTest
    {
        [TestMethod]
        public void TestPointCheck()
        {
            Word tjempo = new Word("tjempo");
            string tjempoResult = "tjem.po";
            Assert.AreEqual(tjempo.word, tjempoResult);

            Word baka = new Word("baka");
            string bakaResult = "ba.ka";
            Assert.AreEqual(baka.word, bakaResult);


            Word bjenbenidos = new Word("bjenbenidos");
            string bjenbenidosResult = "bjen.be.ni.dos";
            Assert.AreEqual(bjenbenidos.word, bjenbenidosResult);

            Word kompɾar = new Word("kompɾar");
            string komprarResult = "kom.pɾar";
            Assert.AreEqual(kompɾar.word, komprarResult);

            Word telemundo = new Word("telemundo");
            string telemundoResult = "te.le.mun.do";
            Assert.AreEqual(telemundo.word, telemundoResult);

            Word eksiste = new Word("eksiste");
            string eksisteResult = "ek.sis.te";
            Assert.AreEqual(eksiste.word, eksisteResult);

            Word eksplika = new Word("eksplika");
            string eksplikaResult = "eks.pli.ka";
            Assert.AreEqual(eksplika.word, eksplikaResult);


        }
    }
}
