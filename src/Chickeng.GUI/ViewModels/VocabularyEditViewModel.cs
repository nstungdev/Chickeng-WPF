using Chickeng.Domain.DTOs;
using Chickeng.Domain.Services;
using Chickeng.GUI.Commands;
using Chickeng.GUI.Helpers;
using Chickeng.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class VocabularyEditViewModel : ViewModelBase
    {
        private readonly VocabularyService _vocabularyService;
        #region Fields
        private bool _isLoading = false;
        private string? _word { get; set; }
        private string? _wordType { get; set; }
        private string? _mean { get; set; }
        private string? _pronounce { get; set; }
        private string? _note { get; set; }
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
        public ICommand SubmitCommand { get; set; }
        public ICommand LoadTargetItemCommand { get; set; }
        #endregion

        #region Private Methods
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
