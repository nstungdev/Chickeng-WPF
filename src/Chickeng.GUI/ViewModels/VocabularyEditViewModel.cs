using Chickeng.Domain.DTOs;
using Chickeng.Domain.Services;
using Chickeng.GUI.Commands;
using Chickeng.GUI.Helpers;
using Chickeng.Infrastructure.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class VocabularyEditViewModel : ViewModelBase
    {
        #region DI fields
        private readonly VocabularyService _vocabularyService;
        #endregion

        #region Normal fields
        private bool _isLoading = false;
        private string? _word;
        private string? _wordType;
        private string? _mean;
        private string? _pronounce;
        private string? _note;
        #endregion
        public VocabularyEditViewModel(VocabularyService vocabularyService)
        {
            _vocabularyService = vocabularyService;

            LoadTargetItemCommand = new AsyncCommand(LoadTargetItem);
            SubmitCommand = new AsyncCommand(SubmitForm);
        }

        #region Properties
        public string? Word 
        {
            get => _word;
            set
            {
                _word = value;
                OnPropertyChanged(nameof(Word));
            }
        }
        public string? WordType 
        { 
            get => _wordType; 
            set 
            {
                _wordType = value; 
                OnPropertyChanged(nameof(WordType)); 
            } 
        }
        public string? Mean 
        { 
            get => _mean;
            set
            {
                _mean = value;
                OnPropertyChanged(nameof(Mean));
            }
        }
        public string? Pronounce 
        { 
            get => _pronounce; 
            set
            {
                _pronounce = value;
                OnPropertyChanged(nameof(Pronounce));
            } 
        }
        public string? Note 
        { 
            get => _note; 
            set
            {
                _note = value;
                OnPropertyChanged(nameof(Note));
            }
        }
        public string Title { get => ReferenceObject == null ? "CREATE NEW VOCABULARY" : "UPDATE VOCABULARY"; }
        public bool IsLoading 
        { 
            get => _isLoading; 
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        #endregion

        #region Commands
        public ICommand SubmitCommand { get; set; }
        public ICommand LoadTargetItemCommand { get; set; }
        #endregion

        #region Actions
        private async Task LoadTargetItem(object? param)
        {
            if (ReferenceObject != null && int.TryParse(ReferenceObject.ToString(), out var identityValue))
            {
                var voc = await _vocabularyService.GetOneByIdAsync(identityValue) ?? throw new NullReferenceException("Word not found");
                WordType = voc.WordType;
                Word = voc.Word;
                Mean = voc.Mean;
                Pronounce = voc.Pronounce;
                Note = voc.Note;
            }
        }
        private async Task SubmitForm(object? param)
        {
            try
            {
                IsLoading = true;
                // create new vocabulary
                if (ReferenceObject == null)
                {
                    var voc = new Vocabulary
                    {
                        Word = _word,
                        Mean = _mean,
                        WordType = _wordType,
                        Pronounce = _pronounce,
                        TopicId = null,
                        Note = _note,
                        CreatedAt = DateTime.Now,
                        LastUpdatedAt = null
                    };
                    await _vocabularyService.AddOneAsync(voc);
                    MessageBoxFactory.ShowInfoBox("Create new vocabulary successfully");
                }
                else if (int.TryParse(ReferenceObject.ToString(), out var id))
                {
                    var vocDto = new VocabularyDTO
                    {
                        Mean = _mean,
                        Note = _note,
                        Pronounce = _pronounce,
                        Word = _word,
                        WordType = _wordType
                    };
                    await _vocabularyService.UpdateOneAsync(id, vocDto);
                    MessageBoxFactory.ShowInfoBox("Update vocabulary successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBoxFactory.ShowErrorBox(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
        #endregion
    }
}
