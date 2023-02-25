using Chickeng.Domain.Services;
using Chickeng.GUI.Commands;
using Chickeng.GUI.Common;
using Chickeng.GUI.Helpers;
using Chickeng.GUI.Models;
using Chickeng.GUI.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chickeng.GUI.ViewModels
{
    public class PhraseTableViewModel : ViewModelBase
    {
        private readonly NavigationService<PhraseEditViewModel> _navPhraseEditViewService;
        private readonly PhraseService _phraseService;
        private ObservableCollection<PhraseTableModel>? _phrases;
        private bool _isLoading;
        public PhraseTableViewModel(NavigationService<PhraseEditViewModel> navigationPhraseEditViewService,
            PhraseService phraseService)
        {
            _navPhraseEditViewService = navigationPhraseEditViewService;
            _phraseService = phraseService;

            LoadResourceCommand = new AsyncCommand(LoadResource);

            CreateNewPhraseCommand = new AsyncCommand(NavigateEditForm);

            EditPhraseCommand = new AsyncCommand(NavigateEditForm);

            DeletePhraseCommand = new AsyncCommand(DeleteAction);
        }
        public ICommand LoadResourceCommand { get; }
        public ICommand EditPhraseCommand { get; }
        public ICommand DeletePhraseCommand { get; }
        public ICommand CreateNewPhraseCommand { get; }
        public ObservableCollection<PhraseTableModel>? Phrases 
        { 
            get => _phrases;
            set
            {
                _phrases = value;
                OnPropertyChanged(nameof(Phrases));
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

        private async Task LoadResource(object? @param)
        {
            IsLoading = true;

            var results = await _phraseService.GetAllAsync();
            Phrases = new ObservableCollection<PhraseTableModel>(results
                .Select(e => new PhraseTableModel
                {
                    Phrase = e,
                    EditCommand = EditPhraseCommand,
                    DeleteCommand = DeletePhraseCommand
                }));

            IsLoading = false;
        }
        private Task NavigateEditForm(object? id)
        {
            _navPhraseEditViewService.Navigate(id);
            return Task.CompletedTask;
        }

        private Task DeleteAction(object? id)
        {
            MessageBoxFactory.ShowInfoBox(CommonConstants.UnavailableFeatureMsg);
            return Task.CompletedTask;
        }
    }
}
