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
        }

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
        public bool? IsLoading 
        { 
            get => _isLoading; 
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            } 
        }
        public ICommand? SubmitCommand { get; set; }
        public ICommand? Reset { get; set; }
        private async Task SubmitForm(object? param)
        {
            IsLoading = true;

            try
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
            catch (Exception ex)
            {
                MessageBoxFactory.ShowErrorBox(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
