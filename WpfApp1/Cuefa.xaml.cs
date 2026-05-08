using KrestikiNolikiIgra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp1;




namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Cuefa.xaml
    /// </summary>
    public partial class Cuefa : Window
    {
        CuefaLogika logika = new CuefaLogika();

        int playerScore = 0;
        int botScore = 0;

        string filePath = "rpsscore.txt";


        public bool PlayerWin;
        public bool BotWin;
        public Cuefa()
        {
            InitializeComponent();
            Zagruzka();
        }

        private void Kamen_Click(object sender, RoutedEventArgs e)
        {
            Igrat("rock");
        }

        private void Bumaga_Click(object sender, RoutedEventArgs e)
        {
            Igrat("paper");
        

        }

        private void Nozhnicy_Click(object sender, RoutedEventArgs e)
        {
            Igrat("scissors");
        }

        private void Igrat(string player)
        {
            PlayerWin = false;
            BotWin = false;

            logika.Igrat(player);

            SetImages(player, logika.BotChoice);

            if (logika.PlayerWin)
            {
                playerScore++;
            }

            if (logika.BotWin)
            {
                botScore++;
            }

            Sochranit();
            Obnova();

            ResultText.Text =
                "Ty: " + player +
                "\nBot: " + logika.BotChoice +
                "\n" + logika.Result;
        }

        private void SetImages(string player, string bot)
        {
            BitmapImage playerBitmap = new BitmapImage();
            playerBitmap.BeginInit();
            playerBitmap.UriSource = new Uri("Images/" + player + ".png", UriKind.Relative);
            playerBitmap.EndInit();

            PlayerImage.Source = playerBitmap;

            BitmapImage botBitmap = new BitmapImage();
            botBitmap.BeginInit();
            botBitmap.UriSource = new Uri("Images/" + bot + ".png", UriKind.Relative);
            botBitmap.EndInit();

            BotImage.Source = botBitmap;
        }

        private void Zagruzka()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length >= 2)
                {
                    playerScore = int.Parse(lines[0]);
                    botScore = int.Parse(lines[1]);
                }
            }

            Obnova();
        }
        private void Sochranit()
        {
            File.WriteAllLines(filePath, new string[]
            {
        playerScore.ToString(),
        botScore.ToString()
            });
            Obnova();
        }
       
        private void Obnova()
        {
            schet.Text =
                "Ty: " + playerScore +
                " | Bot: " + botScore;
        }
    }
}
