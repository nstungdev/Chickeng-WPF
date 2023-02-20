using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chickeng.Domain.DTOs
{
    public class PhraseDTO
    {
        public string? Content { get; set; }
        public string? Mean { get; set; }
        public string? Pronounce { get; set; }
        public string? Tone { get; set; }
        public string? Note { get; set; }
    }
}
