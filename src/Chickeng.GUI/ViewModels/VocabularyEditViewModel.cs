using Chickeng.Domain.Services;
using Chickeng.GUI.Commands;
using Chickeng.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class VocabularyEditViewModel : ViewModelBase
    {
        private readonly VocabularyService _vocabularyService;
        private bool _isLoading = false;
        private string? _word { get; set; }
        public VocabularyEditViewModel(VocabularyService vocabularyService)
        {
            _vocabularyService = vocabularyService;
            Submit = new SubmitVocabularyFormAsyncCommand(_vocabularyService, this);
        }
        public string? Word 
        {
            get => _word;
            set
            {
                _word = value;
                OnPropertyChanged(nameof(Word));
            }
        }
        public bool IsLoading 
        { 
            get => _isLoading; 
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public string? WordType { get; set; }
        public string? Mean { get; set; }
        public string? Pronounce { get; set; }
        public string? Note { get; set; }
        public ICommand? Submit { get; set; }
    }
}
