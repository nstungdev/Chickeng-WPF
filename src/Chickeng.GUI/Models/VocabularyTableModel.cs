﻿using Chickeng.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.Models
{
    public class VocabularyTableModel
    {
        public int Position { get; set; }
        public int Id { get; set; }
        public string? Word { get; set; }
        public string? Type { get; set; }
        public string? Pronounce { get; set; }
        public string? Mean { get; set; }
        public ICommand? EditCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }
    }
}
