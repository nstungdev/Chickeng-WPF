using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.GUI.Models
{
    public class Phrase
    {
        public string? Content { get; set; }
        public string? Topic { get; set; }
        public string? Note { get; set; }
        public string? Pronounce { get; set; }
        public string? Tone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
