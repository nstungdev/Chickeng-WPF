using Chickeng.GUI.Commands;
using Chickeng.GUI.Models;
using Chickeng.GUI.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class PhraseTableViewModel : ViewModelBase
    {
        private readonly NavigationService<PhraseEditViewModel> _navigationPhraseEditViewService;
        public PhraseTableViewModel(NavigationService<PhraseEditViewModel> navigationPhraseEditViewService)
        {
            _navigationPhraseEditViewService = navigationPhraseEditViewService;

            Phrases = new ObservableCollection<Phrase>()
            {
                new Phrase { Topic = "GoodBye", Content = "lorem", CreatedAt = DateTime.Now },
                new Phrase { Topic = "GoodBye", Content = "lorem", CreatedAt = DateTime.Now },
                new Phrase { Topic = "GoodBye", Content = "lorem", CreatedAt = DateTime.Now },
            };

            CreateNewPhraseCommand = new PhraseEditAsyncCommand(_navigationPhraseEditViewService);
        }
        public ObservableCollection<Phrase> Phrases { get; set; }
        public ICommand CreateNewPhraseCommand { get; set; }
    }
}
