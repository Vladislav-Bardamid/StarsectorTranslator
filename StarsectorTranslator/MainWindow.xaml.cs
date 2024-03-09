using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using StarsectorTranslator.Models;

namespace StarsectorTranslator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        DataContext dataContext = new DataContext();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = dataContext;
        }

        public void OpenGameFolder(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                dataContext.Lines = Scanner
                    .ScanGameFolder(dialog.SelectedPath)
                    .SelectMany(x => x.Translations)
                    .ToList();
            }
        }
    }
}
