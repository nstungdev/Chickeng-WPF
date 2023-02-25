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
    public class VocabularyService
    {
        private readonly ChickengDbContext _dbContext;
        public VocabularyService(ChickengDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Vocabulary>> GetAllAsync()
        {
            return await _dbContext.Vocabularies.ToArrayAsync();
        }
        public async Task<CardModel> GetCardInfoAsync()
        {
            var today = DateTime.Today;
            var total = await _dbContext.Vocabularies.CountAsync();
            var newItemsCount = await _dbContext.Vocabularies.AsNoTracking()
                .Where(e => e.CreatedAt.Date == today)
                .CountAsync();
            return new CardModel
            {
                Name = nameof(Vocabulary),
                NewItemsCount = newItemsCount,
                Total = total
            };
        }
        public async Task AddOneAsync(Vocabulary vocabulary)
        {
            await _dbContext.Vocabularies.AddAsync(vocabulary);
            await _dbContext.SaveChangesAsync();
            return;
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
