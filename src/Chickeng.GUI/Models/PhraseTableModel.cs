using Chickeng.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.Models
{
    public class PhraseTableModel
    {
        public int Position { get; set; }
        public string? Content { get; set; }
        public string? Mean { get; set; }
        public int Id { get; set; }
        public ICommand? EditCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }
    }
}
