using Chickeng.Domain.Services;
using Chickeng.GUI.Commands;
using Chickeng.GUI.Helpers;
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
        #region DI fields
        private readonly NavigationService<VocabularyTableViewModel> _navVocaTable;
        private readonly NavigationService<PhraseTableViewModel> _navPhraseTable;
        private readonly VocabularyService _vocabularyService;
        private readonly PhraseService _phraseService;
        #endregion

        #region Normal fields
        private int _wordTotal;
        private int _wordNewCount;
        private int _phraseTotal;
        private int _phraseNewCount;
        private string? _wordTitle;
        private string? _phraseTitle;
        private bool _isLoading;
        #endregion
        public HomeViewModel(NavigationService<VocabularyTableViewModel> navVocaTable,
            NavigationService<PhraseTableViewModel> navPhraseTable,
            VocabularyService vocabularyService,
            PhraseService phraseService)
        {
            // DI
            _navVocaTable = navVocaTable;
            _navPhraseTable = navPhraseTable;
            _vocabularyService = vocabularyService;
            _phraseService = phraseService;

            // load resource
            LoadResourceCommand = new AsyncCommand(GetResourceAsync);

            // command
            NavToVocTableCommand = new AsyncCommand(NavToVocTableAsync);
            NavToPhraseTableCommand = new AsyncCommand(NavToPhraseTableAsync);


            QuitCommand = new QuitApplicationAsyncCommand();
        }

        #region Properties
        public string? WordTitle
        {
            get => _wordTitle;
            set
            {
                _wordTitle = value;
                OnPropertyChanged(nameof(WordTitle));
            }
        }
        public string? PhraseTitle
        {
            get => _phraseTitle;
            set
            {
                _phraseTitle = value;
                OnPropertyChanged(nameof(PhraseTitle));
            }
        }
        public int WordTotal 
        { 
            get => _wordTotal; 
            set
            {
                _wordTotal = value;
                OnPropertyChanged(nameof(WordTotal));
            } 
        }
        public int WordNewCount 
        {
            get => _wordNewCount;
            set
            {
                _wordNewCount = value;
                OnPropertyChanged(nameof(WordNewCount));
            } 
        }
        public int PhraseTotal 
        {
            get => _phraseTotal;
            set
            {
                _phraseTotal = value;
                OnPropertyChanged(nameof(PhraseTotal));
            } 
        }
        public int PhraseNewCount 
        { 
            get => _phraseNewCount;
            set
            {
                _phraseNewCount = value;
                OnPropertyChanged(nameof(PhraseNewCount));
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
        public ICommand QuitCommand { get; set; }
        #endregion

        #region Commands
        public ICommand LoadResourceCommand { get; }
        private async Task GetResourceAsync(object? @param)
        {
            try
            {
                IsLoading = true;

                var phraseCardInfo = await _phraseService.GetCardInfoAsync();
                var vocCardInfo = await _vocabularyService.GetCardInfoAsync();

                WordTotal = vocCardInfo.Total;
                WordNewCount = vocCardInfo.NewItemsCount;
                WordTitle = vocCardInfo.Name;

                PhraseTotal = phraseCardInfo.Total;
                PhraseNewCount = phraseCardInfo.NewItemsCount;
                PhraseTitle = phraseCardInfo.Name;
            }
            catch(Exception ex)
            {
                MessageBoxFactory.ShowErrorBox(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }

        // nav to vocabulary command
        public ICommand NavToVocTableCommand { get; }
        private Task NavToVocTableAsync(object? @param)
        {
            _navVocaTable.Navigate(@param);
            return Task.CompletedTask;
        }

        // nav to phrase command
        public ICommand NavToPhraseTableCommand { get; }
        private Task NavToPhraseTableAsync(object? @param)
        {
            _navPhraseTable.Navigate(@param);
            return Task.CompletedTask;
        }

        #endregion

    }
}
