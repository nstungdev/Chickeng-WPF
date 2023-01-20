using Chickeng.Infrastructure;
using Chickeng.Infrastructure.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.NUnitTest
{
    [TestFixture]
    public class VocabularyDbTestSuite
    {
        
        private ChickengContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new ChickengContext();
        }

        [Test]
        public void CreateOne()
        {
            var voc = new Vocabulary
            {
                Mean = "mean",
                Pronounce = "pronounce",
                Word = "word",
                WordType = "word-type"
            };

            _context.Add(voc);
            _context.SaveChanges();

            Assert.IsTrue(voc.Id != 0);
        }

        [TestCase("ga")]
        [TestCase("con")]
        [TestCase("gay")]
        public void GetOne(string word)
        {
            var vocs = new Vocabulary[]
            {
                new Vocabulary { Mean = "mean", Pronounce = "pro", Word = word, WordType = "wp" },
            };

            _context.AddRange(vocs);
            _context.SaveChanges();

            var results = _context.Vocabularies
                .Where(e => e.Word == word)
                .ToList();

            Assert.IsTrue(results.Count > 0);
        }


    }
}
