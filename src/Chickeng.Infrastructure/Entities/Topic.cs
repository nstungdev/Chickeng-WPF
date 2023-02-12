using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Infrastructure.Entities
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(100), MinLength(3)]        
        public string? Name { get; set; }
        public string? ForegroundColor { get; set; }
        public string? BackgroundColor { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedAt { get; set; }
        public virtual List<Vocabulary>? Vocabularies { get; set; }
        public virtual List<Phrase>? Phrases { get; set; }
    }
}
