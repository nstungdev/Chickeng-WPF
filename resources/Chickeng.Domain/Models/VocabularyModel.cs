﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Domain.Models
{
    public class VocabularyModel
    {
        public int Id { get; set; }
        public string? Word { get; set; }
        public string? WordType { get; set; }
        public string? Mean { get; set; }
        public string? Pronounce { get; set; }
        public string? Note { get; set; }
    }
}