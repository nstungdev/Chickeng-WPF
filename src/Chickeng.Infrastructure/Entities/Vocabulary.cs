using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Infrastructure.Entities
{
    public class Vocabulary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Word { get; set; }
        [Required, MaxLength(255)]
        public string? Mean { get; set; }
        [Required, MaxLength(50)]
        public string? WordType { get; set; }
        public string? Pronounce { get; set; }
        public string? Note { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedAt { get; set; }
        public int? TopicId { get; set; }
        public virtual Topic? Topic { get; set; }
    }
}
