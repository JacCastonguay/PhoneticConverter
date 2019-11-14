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
            var distinct = tjempo.points.Except(new System.Collections.Generic.List<int> { 3 }).ToList();
            Assert.AreEqual(0, distinct.Count);

            Word baka = new Word("baka");
            var distinct2 = baka.points.Except(new System.Collections.Generic.List<int> { 1 }).ToList();
            Assert.AreEqual(0, distinct2.Count);


            Word bjenbenidos = new Word("bjenbenidos");
            var distinct3 = bjenbenidos.points.Except(new System.Collections.Generic.List<int> { 3, 5, 7 }).ToList();
            Assert.AreEqual(0, distinct3.Count);

            Word kompɾar = new Word("kompɾar");
            var distinct4 = kompɾar.points.Except(new System.Collections.Generic.List<int> { 2 }).ToList();
            Assert.AreEqual(0, distinct4.Count);

            Word telemundo = new Word("telemundo");
            var distinct5 = telemundo.points.Except(new System.Collections.Generic.List<int> { 1, 3, 6 }).ToList();
            Assert.AreEqual(0, distinct5.Count);

            Word eksiste = new Word("eksiste");
            var distinct6 = eksiste.points.Except(new System.Collections.Generic.List<int> { 1, 4 }).ToList();
            Assert.AreEqual(0, distinct6.Count);

            Word eksplica = new Word("eksplika");
            var distinct7 = eksplica.points.Except(new System.Collections.Generic.List<int> { 2, 5 }).ToList();
            Assert.AreEqual(0, distinct7.Count);


        }
    }
}
