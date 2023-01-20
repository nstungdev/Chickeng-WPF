using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Infrastructure.Entities
{
    public class Vocabulary
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(255)]
        [DisplayName("Từ")]
        public string? Word { get; set; }


        [Required]
        [MaxLength(50)]
        [DisplayName("Loại từ")]
        public string? WordType { get; set; }


        [Required]
        [MaxLength(500)]
        [DisplayName("Nghĩa")]
        public string? Mean { get; set; }


        [Required]
        [MaxLength(100)]
        [DisplayName("Phát âm")]
        public string? Pronounce { get; set; }

        [DisplayName("Ghi chú")]
        public string? Note { get; set; }
    }
}
