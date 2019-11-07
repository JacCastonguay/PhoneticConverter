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
        public void LetterSubstitueUTest()
        {
            //Should only compare specific chars to avoid errors from other letters
            string awtor = Translation.LetterSubstitue("autor");
            Assert.AreEqual("awtor"[1], awtor[1]);

            string brujo = Translation.LetterSubstitue("brujo");
            Assert.AreEqual("brujo"[2], brujo[2]);
        }
    }
}