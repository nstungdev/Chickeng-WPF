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

        public async Task AddOneAsync(Vocabulary vocabulary)
        {
            await _dbContext.Vocabularies.AddAsync(vocabulary);
            await Task.Delay(10000);
            await _dbContext.SaveChangesAsync();
            return;
        }
    }
}
