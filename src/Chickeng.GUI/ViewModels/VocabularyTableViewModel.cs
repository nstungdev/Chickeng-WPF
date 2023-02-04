﻿using Chickeng.GUI.Commands;
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
        private readonly NavigationService<HomeViewModel> _navigationHomeViewService;
        private readonly NavigationService<VocabularyEditViewModel> _navigationVocabularyEditViewService;
        public VocabularyTableViewModel(NavigationService<HomeViewModel> navigationHomeViewService,
            NavigationService<VocabularyEditViewModel> navigationVocabularyEditViewService)
        {
            _navigationHomeViewService = navigationHomeViewService;
            _navigationVocabularyEditViewService = navigationVocabularyEditViewService;
            
            Vocabularies = new ObservableCollection<Vocabulary>()
            {
                new Vocabulary() { Word = "name1", WordType = "verb", Mean = "tên1", CreatedAt = DateTime.Now },
                new Vocabulary() { Word = "name2", WordType = "verb", Mean = "tên2", CreatedAt = DateTime.Now },
                new Vocabulary() { Word = "name3", WordType = "verb", Mean = "tên3", CreatedAt = DateTime.Now },
                new Vocabulary() { Word = "name4", WordType = "verb", Mean = "tên4", CreatedAt = DateTime.Now },
            };

            HomeCommand = new HomeAsyncCommands(_navigationHomeViewService);
            CreateNewWordCommand = new VocabularyEditAsyncCommand(_navigationVocabularyEditViewService);
        }

        public ObservableCollection<Vocabulary>? Vocabularies { get; set; }
        public ICommand HomeCommand { get; }
        public ICommand CreateNewWordCommand { get; }
    }
}
