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
        public void TestPenultimaWords()
        {
            Word tiempo = new Word("tiempo");
            string tjempoResult = "\'tjem.po";
            Assert.AreEqual(tiempo.word, tjempoResult);

            Word vaca = new Word("vaca");
            string bakaResult = "\'ba.ka";
            Assert.AreEqual(vaca.word, bakaResult);


            Word bienvenidos = new Word("bienvenidos");
            string bjenbenidosResult = "bjen.be.\'ni.ðos";
            Assert.AreEqual(bienvenidos.word, bjenbenidosResult);

            Word telemundo = new Word("telemundo");
            string telemundoResult = "te.le.\'mun.do";
            Assert.AreEqual(telemundo.word, telemundoResult);
        }

        [TestMethod()]
        public void TestUltima()
        {
            Word comprar = new Word("comprar");
            string komprarResult = "kom.\'pɾaɾ";
            Assert.AreEqual(comprar.word, komprarResult);
        }

        [TestMethod()]
        public void TestSSpecials()
        {
            Word existe = new Word("existe");
            string eksisteResult = "ek.\'sis.te";
            Assert.AreEqual(existe.word, eksisteResult);

            Word explica = new Word("explica");
            string eksplikaResult = "eks.\'pli.ka";
            Assert.AreEqual(explica.word, eksplikaResult);

            Word estɾella = new Word("estɾella");
            string estreyaResult = "es.\'tɾe.ʝa";
            Assert.AreEqual(estɾella.word, estreyaResult);
        }

        public void TestSingleSyllable()
        {
            Word bien = new Word("bien");
            string bjenResult = "\'bjen";
            Assert.AreEqual(bien.word, bjenResult);
        }

        public void TestStressBasedOnTilde()
        {
            Word pelicula = new Word("película");
            string peliculaResult = "pe.\'li.ku.la";
            Assert.AreEqual(peliculaResult, pelicula.word);
        }
    }
}
