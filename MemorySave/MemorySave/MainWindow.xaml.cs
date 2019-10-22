using Microsoft.Win32;
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
using System.IO;

namespace MemorySave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        //informate van huidige gamestate: Huidige Positie kaartjes in list, huidige puntenaantal, huidige username

        private string chosenFileName;
        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            //display the dialog the first time the Save button is clicked only:
            if (string.IsNullOrEmpty(chosenFileName))
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "SAV Files (*.sav)|*.sav|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
                if (saveFile.ShowDialog() != true)
                    return;

                chosenFileName = saveFile.FileName;
            }


            // Create a TextRange around the entire document.
            TextRange documentTextRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);

            // If this file exists, it's overwritten.
            using (FileStream fs = File.Create(chosenFileName))
            {
                if (System.IO.Path.GetExtension(chosenFileName).ToLower() == ".rtf")
                {
                    documentTextRange.Save(fs, DataFormats.Rtf);
                }
                else
                {
                    documentTextRange.Save(fs, DataFormats.Xaml);
                }
                this.Title = "Hyfler Writer: " + chosenFileName;
            }
        }



    }

}
