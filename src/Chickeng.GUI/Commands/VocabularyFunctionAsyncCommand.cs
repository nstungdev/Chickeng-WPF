using Chickeng.Domain.Services;
using Chickeng.GUI.ViewModels;
using Chickeng.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chickeng.GUI.Commands
{
    public class SubmitVocabularyFormAsyncCommand : AsyncCommandBase
    {
        private readonly VocabularyService _vocabularyService;
        private readonly VocabularyEditViewModel _model;
        public SubmitVocabularyFormAsyncCommand(VocabularyService vocabularyService, VocabularyEditViewModel model)
        {
            _vocabularyService = vocabularyService;
            _model = model;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                // create new vocabulary
                if (parameter == null)
                {
                    var voc = new Vocabulary
                    {
                        Word = _model.Word,
                        Mean = _model.Mean,
                        WordType = _model.WordType,
                        Pronounce = _model.Pronounce,
                        TopicId = null,
                        Note = _model.Note,
                        CreatedAt = DateTime.Now,
                        LastUpdatedAt = null
                    };
                    _model.IsLoading = true;
                    await _vocabularyService.AddOneAsync(voc);
                    MessageBox.Show("Create new vocabulary successfully", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _model.IsLoading = false;
            }
        }
    }
}
