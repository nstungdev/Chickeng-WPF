using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Infrastructure.Entities
{
    public class Phrase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string? Content { get; set; }
        [Required, MaxLength(255)]
        public string? Mean { get; set; }
        public string? Note { get; set; }
        public string? Pronounce { get; set; }
        public string? Tone { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedAt { get; set; }
        public int? TopicId { get; set; }
        public virtual Topic? Topic { get; set; }
    }
}
