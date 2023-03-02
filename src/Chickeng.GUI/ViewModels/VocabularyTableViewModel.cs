using Chickeng.Domain.Services;
using Chickeng.GUI.Commands;
using Chickeng.GUI.Common;
using Chickeng.GUI.Helpers;
using Chickeng.GUI.Models;
using Chickeng.GUI.Stores;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class VocabularyTableViewModel : ViewModelBase
    {
        #region DI fields
        private readonly NavigationService<VocabularyEditViewModel> _navVocaEditService;
        private readonly VocabularyService _vocabularyService;
        #endregion

        #region Normal fields
        private bool _isLoading = false;
        private ObservableCollection<VocabularyTableModel>? _vocabularies;
        #endregion
        public VocabularyTableViewModel(NavigationService<VocabularyEditViewModel> navVocaEditService,
            VocabularyService vocabularyService)
        {
            _navVocaEditService = navVocaEditService;
            _vocabularyService = vocabularyService;

            // load data into listview
            LoadResourceCommand = new AsyncCommand(LoadResource);

            // navigating to Create New Vocabulary Form
            CreateNewWordCommand = new AsyncCommand(NavigateEditForm);

            // navigating to Update Vocabulary Form
            EditWordCommand = new AsyncCommand(NavigateEditForm);

            // show message
            DeleteCommand = new AsyncCommand(DeleteAction);
        }

        #region Properties
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public ObservableCollection<VocabularyTableModel>? Vocabularies {
            get => _vocabularies;
            set
            {
                _vocabularies = value;
                OnPropertyChanged(nameof(Vocabularies));
                _isLoading = false;
            }
        }
        #endregion

        #region Commands
        public ICommand CreateNewWordCommand { get; }
        public ICommand LoadResourceCommand { get; }
        public ICommand EditWordCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        #region Actions
        private async Task LoadResource(object? @param)
        {
            IsLoading = true;

            var results = await _vocabularyService.GetAllAsync();
            Vocabularies = new ObservableCollection<VocabularyTableModel>(results
                .Select((e, idx) => new VocabularyTableModel
                {
                    Position = idx + 1,
                    Word = e.Word,
                    Id = e.Id,
                    Pronounce = e.Pronounce,
                    Type = e.WordType,
                    Mean = e.Mean,
                    EditCommand = EditWordCommand,
                    DeleteCommand = DeleteCommand
                }));

            IsLoading = false;
        }

        private Task NavigateEditForm(object? id)
        {
            _navVocaEditService.Navigate(id);
            return Task.CompletedTask;
        }

        private Task DeleteAction(object? id)
        {
            MessageBoxFactory.ShowInfoBox(CommonConstants.UnavailableFeatureMsg);
            return Task.CompletedTask;
        }
        #endregion
    }
}
