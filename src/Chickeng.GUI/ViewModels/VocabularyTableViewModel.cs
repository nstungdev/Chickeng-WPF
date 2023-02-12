using Chickeng.Domain.Services;
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
    public class VocabularyTableViewModel : ViewModelBase
    {
        private readonly NavigationService<VocabularyEditViewModel> _navigationVocabularyEditViewService;
        private readonly VocabularyService _vocabularyService;
        public VocabularyTableViewModel(NavigationService<VocabularyEditViewModel> navigationVocabularyEditViewService,
            VocabularyService vocabularyService)
        {
            _navigationVocabularyEditViewService = navigationVocabularyEditViewService;
            _vocabularyService = vocabularyService;

            var v = new Infrastructure.Entities.Vocabulary
            {
                Word = "A",
                Mean = "B",
                CreatedAt = DateTime.Now,
                WordType = "C"
            };

            Vocabularies = new ObservableCollection<VocabularyDto>()
            {
                new VocabularyDto() { Word = "name1", WordType = "verb", Mean = "tên1", CreatedAt = DateTime.Now },
                new VocabularyDto() { Word = "name2", WordType = "verb", Mean = "tên2", CreatedAt = DateTime.Now },
                new VocabularyDto() { Word = "name3", WordType = "verb", Mean = "tên3", CreatedAt = DateTime.Now },
                new VocabularyDto() { Word = "name4", WordType = "verb", Mean = "tên4", CreatedAt = DateTime.Now },
            };
            CreateNewWordCommand = new VocabularyEditAsyncCommand(_navigationVocabularyEditViewService);
        }

        public ObservableCollection<VocabularyDto>? Vocabularies { get; set; }
        public ICommand CreateNewWordCommand { get; }
    }
}
