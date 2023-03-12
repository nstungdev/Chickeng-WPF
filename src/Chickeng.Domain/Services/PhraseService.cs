using Chickeng.Domain.DTOs;
using Chickeng.Domain.Models;
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
        public async Task<IEnumerable<Phrase>> GetAllAsync()
        {
            return await _dbContext.Phrases
                .OrderByDescending(e => e.LastUpdatedAt)
                .ThenByDescending(e => e.CreatedAt)
                .ToArrayAsync();
        }
        public async Task<CardModel> GetCardInfoAsync()
        {
            var today = DateTime.Today;
            var total = await _dbContext.Phrases.CountAsync();
            var newItemsCount = await _dbContext.Phrases.AsNoTracking()
                .Where(e => e.CreatedAt.Date == today)
                .CountAsync();
            return new CardModel
            {
                Name = nameof(Phrase),
                NewItemsCount = newItemsCount,
                Total = total
            };
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
        public async Task<Phrase?> GetOneByIdAsync(int id)
        {
            var result = await _dbContext.Phrases.FindAsync(id);
            return result;
        }
        public async Task UpdateOneAsync(int id, PhraseDTO phraseDTO)
        {
            var phraseInDB = await _dbContext.Phrases.FindAsync(id);
            if (phraseInDB == null)
                throw new ArgumentNullException("Phrase not found");
            phraseInDB.Content = phraseDTO.Content;
            phraseInDB.Note = phraseDTO.Note;
            phraseInDB.Pronounce = phraseDTO.Pronounce;
            phraseInDB.Tone = phraseDTO.Tone;
            phraseInDB.LastUpdatedAt = DateTime.Now;
            phraseInDB.Mean = phraseDTO.Mean;
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
