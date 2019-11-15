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
            Word tiempo = new Word("tiempo");
            string tjempoResult = "tjem.po";
            Assert.AreEqual(tiempo.word, tjempoResult);

            Word vaca = new Word("vaca");
            string bakaResult = "ba.ka";
            Assert.AreEqual(vaca.word, bakaResult);


            Word bienvenidos = new Word("bienvenidos");
            string bjenbenidosResult = "bjen.be.ni.ðos";
            Assert.AreEqual(bienvenidos.word, bjenbenidosResult);

            //TODO: Fix last r (or maybe last conversion in general)
            //Word comprar = new Word("comprar");
            //string komprarResult = "kom.pɾar";
            //Assert.AreEqual(comprar.word, komprarResult);

            Word telemundo = new Word("telemundo");
            string telemundoResult = "te.le.mun.do";
            Assert.AreEqual(telemundo.word, telemundoResult);

            //TODO: X not implemented
            //Word existe = new Word("existe");
            //string eksisteResult = "ek.sis.te";
            //Assert.AreEqual(existe.word, eksisteResult);

            //Word explica = new Word("explica");
            //string eksplikaResult = "eks.pli.ka";
            //Assert.AreEqual(explica.word, eksplikaResult);

            Word estɾella = new Word("estɾella");
            string estreyaResult = "es.tɾe.ʝa";
            Assert.AreEqual(estɾella.word, estreyaResult);
        }
    }
}
