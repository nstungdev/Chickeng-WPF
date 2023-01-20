using Chickeng.WpfApplication.Modals;
using Chickeng.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chickeng.Infrastructure.Entities;
using System.ComponentModel;

namespace Chickeng.WpfApplication.Pages
{
    /// <summary>
    /// Interaction logic for VocabularyOverviewPage.xaml
    /// </summary>
    public partial class VocabularyOverviewPage : Page
    {
        private readonly VocabularyService _vocabularyService;
        private int? _selectedVocabularyId = null;
        public VocabularyOverviewPage()
        {
            InitializeComponent();

            _vocabularyService = new VocabularyService();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var resources = await _vocabularyService.GetAll();
            dtg_vocabularies.ItemsSource = resources;
            btn_updateVocabulary.IsEnabled = false;
            dtg_vocabularies.Columns[0].Visibility = Visibility.Hidden;
        }

        private void btn_createVocabulary_Click(object sender, RoutedEventArgs e)
        {
            var vocabularyEditModal = new VocabularyEditModal();
            vocabularyEditModal.ShowDialog();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var voc = row?.DataContext as Vocabulary;
            _selectedVocabularyId = voc?.Id;
            btn_updateVocabulary.IsEnabled = true;

            var editModal = _selectedVocabularyId == null
                ? new VocabularyEditModal()
                : new VocabularyEditModal(_selectedVocabularyId.Value);

            editModal.ShowDialog();
        }

        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {
            var row = sender as DataGridRow;
            var voc = row?.DataContext as Vocabulary;
            _selectedVocabularyId = voc?.Id;
            btn_updateVocabulary.IsEnabled = true;
        }

        private void btn_updateVocabulary_Click(object sender, RoutedEventArgs e)
        {
            var editModal = _selectedVocabularyId == null
                ? new VocabularyEditModal()
                : new VocabularyEditModal(_selectedVocabularyId.Value);

            editModal.ShowDialog();
        }

        private async void btn_refreshVocabulary_Click(object sender, RoutedEventArgs e)
        {
            var resources = await _vocabularyService.GetAll();
            dtg_vocabularies.ItemsSource = resources;
            dtg_vocabularies.Columns[0].Visibility = Visibility.Hidden;
            MessageBox.Show("Làm mới thành công");
        }

        private void dtg_vocabularies_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }
        }
    }
}
