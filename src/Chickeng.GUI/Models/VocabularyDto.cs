using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.GUI.Models
{
    public class VocabularyDto
    {
        public string? Word { get; set; }
        public string? Mean { get; set; }
        public string? WordType { get; set; }
        public string? Pronounce { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
