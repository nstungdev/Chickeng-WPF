using Chickeng.Infrastructure.Entities;
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
        public Vocabulary? Vocabulary { get; set; }
        public ICommand? EditCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }
    }
}
