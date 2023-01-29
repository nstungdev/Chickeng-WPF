using Chickeng.GUI.Commands;
using Chickeng.GUI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly NavigationService<VocabularyTableViewModel> _navigationVocabularyTableViewService;
        private readonly NavigationService<PhraseTableViewModel> _navigationPhraseTableViewService;
        public HomeViewModel(NavigationService<VocabularyTableViewModel> navigationVocabularyTableViewService,
            NavigationService<PhraseTableViewModel> navigationPhraseTableViewService)
        {
            _navigationVocabularyTableViewService = navigationVocabularyTableViewService;
            _navigationPhraseTableViewService = navigationPhraseTableViewService;

            NavigateVocabularyTableCommand = new VocabularyTableViewAsyncCommand(_navigationVocabularyTableViewService);
            NavigatePhraseTableCommand = new PhraseTableViewAsyncCommands(_navigationPhraseTableViewService);

            VocabularyItemCount = 100;
            VocabularyNewItemCount = 42;
            PhraseItemCount = 230;
            PhraseNewItemCount = 12;
        }

        public int VocabularyItemCount { get; set; }
        public int VocabularyNewItemCount { get; set; }
        public int PhraseItemCount { get; set; }
        public int PhraseNewItemCount { get; set; }

        public ICommand NavigateVocabularyTableCommand { get; }
        public ICommand NavigatePhraseTableCommand { get; }

    }
}
