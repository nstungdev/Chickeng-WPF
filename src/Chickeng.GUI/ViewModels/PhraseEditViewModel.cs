using Chickeng.Domain.DTOs;
using Chickeng.Domain.Services;
using Chickeng.GUI.Commands;
using Chickeng.GUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class PhraseEditViewModel : ViewModelBase
    {
        private readonly PhraseService _phraseService;

        private string? _content;
        private string? _mean;
        private string? _pronounce;
        private string? _note;
        private string? _tone;
        private bool? _isLoading;
        public PhraseEditViewModel(PhraseService phraseService)
        {
            _phraseService = phraseService;

            SubmitCommand = new AsyncCommand(SubmitForm);
            LoadTargetItemCommand = new AsyncCommand(LoadTargetItem);
            ResetCommand = new AsyncCommand(ResetForm);
        }

        #region Properties
        public string? Content 
        {
            get => _content; 
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
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
        public string? Tone
        {
            get => _tone;
            set
            {
                _tone = value;
                OnPropertyChanged(nameof(Tone));
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
        public string Title { get => ReferenceObject == null ? "CREATE NEW PHRASE" : "UPDATE PHRASE"; }
        public bool? IsLoading 
        { 
            get => _isLoading; 
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            } 
        }
        public ICommand SubmitCommand { get; }
        public ICommand LoadTargetItemCommand { get; }
        public ICommand ResetCommand { get; }
        #endregion

        #region Private methods
        private async Task SubmitForm(object? param)
        {
            try
            {
                IsLoading = true;

                if (ReferenceObject == null)
                {
                    var phraseDto = new PhraseDTO
                    {
                        Content = _content,
                        Mean = _mean,
                        Note = _note,
                        Pronounce = _pronounce,
                        Tone = _tone
                    };

                    await _phraseService.AddOneAsync(phraseDto);
                    MessageBoxFactory.ShowInfoBox("Create new phrase successfully");
                }
                else if (int.TryParse(ReferenceObject.ToString(), out var id))
                {
                    var phraseDto = new PhraseDTO
                    {
                        Mean = _mean,
                        Note = _note,
                        Pronounce = _pronounce,
                        Content = _content,
                        Tone = _tone
                    };
                    await _phraseService.UpdateOneAsync(id, phraseDto);
                    MessageBoxFactory.ShowInfoBox("Update phrase successfully");
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
        private async Task LoadTargetItem(object? param)
        {
            if (ReferenceObject != null && int.TryParse(ReferenceObject.ToString(), out var identityValue))
            {
                var phrase = await _phraseService.GetOneByIdAsync(identityValue) ?? throw new NullReferenceException("Phrase not found");
                Content = phrase.Content;
                Mean = phrase.Mean;
                Pronounce = phrase.Pronounce;
                Tone = phrase.Tone;
                Note = phrase.Note;
            }
        }
        private Task ResetForm(object? param)
        {
            Content = null;
            Mean = null;
            Pronounce = null;
            Tone = null;
            Note = null;
            return Task.CompletedTask;
        }
        #endregion
    }
}
