using System;
using System.Collections.Generic;
using System.IO;
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

namespace MemoryHighscore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            ReadHighscore();
            WriteHighscore();
        }

        

        private void ReadHighscore()
        {
            if (!File.Exists("highscores.txt"))
            {
                TextWriter tw = new StreamWriter("highscores.txt");
                tw.Write("500");
                tw.Close();
            }

            TextReader tr = new StreamReader("highscores.txt");

            MemHSPoints.Text = tr.ReadLine();
            tr.Close();
        }

        int score = 0;

        private void WriteHighscore()
        {
            if (score >= Convert.ToInt32(MemHSPoints.Text))
            {
                TextWriter tw = new StreamWriter("highscores.txt");
                tw.WriteLine(score);
                tw.Close();
            }
        }

        

    }
}
