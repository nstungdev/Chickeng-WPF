using Chickeng.Domain.Forms;
using Chickeng.Domain.Helpers;
using Chickeng.Infrastructure;
using Chickeng.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Domain.Services
{
    public class VocabularyService
    {
        public VocabularyService()
        {

        }

        public async Task CreateOneAsync(Vocabulary vocabulary)
        {
            var model = vocabulary.NormalizeForm();
            using var context = new ChickengContext();
            await context.Vocabularies.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task UpdateOne(int id, Vocabulary vocabulary)
        {
            var model = vocabulary.NormalizeForm();
            using var context = new ChickengContext();
            var vocabularyInDb = await context.Vocabularies
                .FirstOrDefaultAsync(e => e.Id == id);

            if (vocabularyInDb != null)
            {
                vocabularyInDb.Pronounce = model.Pronounce;
                vocabularyInDb.Note = model.Note;
                vocabularyInDb.Mean = model.Mean;
                vocabularyInDb.Word = model.Word;
                vocabularyInDb.WordType = model.WordType;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Vocabulary>> GetAll()
        {
            using var context = new ChickengContext();
            var results = await context.Vocabularies.AsNoTracking().ToArrayAsync();
            return results;
        }

        public async Task<Vocabulary?> GetOne(int id)
        {
            using var context = new ChickengContext();
            var result = await (from vo in context.Vocabularies
                                where vo.Id == id
                                select vo).FirstOrDefaultAsync();
            return result;
        }
    }
}
