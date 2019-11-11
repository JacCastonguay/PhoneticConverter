using System;
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


        }
    }
}
