using Chickeng.Domain.DTOs;
using Chickeng.Infrastructure.DbContexts;
using Chickeng.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Domain.Services
{
    public class PhraseService
    {
        private readonly ChickengDbContext _dbContext;
        public PhraseService(ChickengDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Vocabulary>> GetAllAsync()
        {
            return await _dbContext.Vocabularies.ToArrayAsync();
        }

        public async Task AddOneAsync(PhraseDTO phraseDto)
        {
            var phrase = new Phrase
            {
                Content = phraseDto.Content,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = null,
                Mean = phraseDto.Mean,
                Note = phraseDto.Note,
                Pronounce = phraseDto.Pronounce,
                Tone = phraseDto.Tone,
                TopicId = null
            };
            await _dbContext.Phrases.AddAsync(phrase);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Vocabulary?> GetOneByIdAsync(int id)
        {
            var result = await _dbContext.Vocabularies.FindAsync(id);
            return result;
        }

        public async Task UpdateOneAsync(int id, VocabularyDTO vocDto)
        {
            var voc = await _dbContext.Vocabularies.FindAsync(id);
            if (voc == null)
                throw new ArgumentNullException("Word not found");
            voc.Word = vocDto.Word;
            voc.WordType = vocDto.WordType;
            voc.Mean = vocDto.Mean;
            voc.Pronounce = vocDto.Pronounce;
            voc.Note = vocDto.Note;
            voc.LastUpdatedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync();
        }
    }
}
