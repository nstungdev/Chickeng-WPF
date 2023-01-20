using Chickeng.Domain.Services;
using Chickeng.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Chickeng.WpfApplication.Helpers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chickeng.WpfApplication.Modals
{
    /// <summary>
    /// Interaction logic for VocabularyEditModal.xaml
    /// </summary>
    public partial class VocabularyEditModal : Window
    {
        private readonly VocabularyService _vocabularyService = new VocabularyService();
        private readonly int? _id = null;
        public VocabularyEditModal()
        {
            InitializeComponent();
        }

        public VocabularyEditModal(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var model = new Vocabulary
            {
                Mean = inp_Mean.Text,
                Note = inp_Note.Text,
                Pronounce = inp_Pronounce.Text,
                WordType = inp_WordType.Text,
                Word = inp_Word.Text
            };

            try
            {
                // start process
                pcb_Loading.Visibility = Visibility.Visible;
                TriggerControlWhenLoading(true);

                if (_id != null)
                {
                    await _vocabularyService.UpdateOne(_id.Value, model);
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    await _vocabularyService.CreateOneAsync(model);
                    MessageBox.Show("Tạo mới thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo mới thất bại " + ex.Message);
            }
            finally
            {
                TriggerControlWhenLoading(false);
                pcb_Loading.Visibility = Visibility.Hidden;
            }
        }
        private void TriggerControlWhenLoading(bool isLoading)
        {
            var textBoxControls = WpfControlHelper.FindVisualChilds<TextBox>(this)
                .Where(e => e.Name.StartsWith("inp_"))
                .ToList();

            var buttonControls = WpfControlHelper.FindVisualChilds<Button>(this)
                .Where(e => e.Name.StartsWith("btn_"))
                .ToList();

            textBoxControls.ForEach(e => e.IsEnabled = !isLoading);
            buttonControls.ForEach(e => e.IsEnabled = !isLoading);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_id != null)
            {
                var voc = await _vocabularyService.GetOne(_id.Value);
                inp_Mean.Text      = voc?.Mean;
                inp_Note.Text      = voc?.Note;
                inp_Pronounce.Text = voc?.Pronounce;
                inp_WordType.Text  = voc?.WordType;
                inp_Word.Text      = voc?.Word;
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            var textBoxControls = WpfControlHelper.FindVisualChilds<TextBox>(this)
                .Where(e => e.Name.StartsWith("inp_"))
                .ToList();

            textBoxControls.ForEach(e => e.Text = null);
        }
    }
}
