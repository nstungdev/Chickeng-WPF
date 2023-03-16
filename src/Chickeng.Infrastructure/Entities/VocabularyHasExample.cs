using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Infrastructure.Entities
{
    [PrimaryKey(nameof(VocabularyId), nameof(WordExampleId))]
    public class VocabularyHasExample
    {
        public int VocabularyId { get; set; }
        public int WordExampleId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey("VocabularyId")]
        public Vocabulary? Vocabulary { get; set; }
        [ForeignKey("WordExampleId")]
        public WordExample? Example { get; set; }
    }
}
