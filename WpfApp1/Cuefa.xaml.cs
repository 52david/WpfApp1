using KrestikiNolikiIgra;
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
using System.Windows.Shapes;
using WpfApp1;
using System.Windows.Media.Imaging;




namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Cuefa.xaml
    /// </summary>
    public partial class Cuefa : Window
    {
        CuefaLogika logika = new CuefaLogika();
        public Cuefa()
        {
            InitializeComponent();
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
            logika.Igrat(player);

            SetImages(player, logika.BotChoice);

            ResultText.Text =
                "Ty: " + player +
                "\nBot: " + logika.BotChoice +
                "\n" + logika.Result;
        }

        private void SetImages(string player, string bot)
        {
            IgrokVzbor.Source = new BitmapImage(new Uri("Images/" + player + ".png", UriKind.Relative));

            BotVybor.Source = new BitmapImage(new Uri("Images/" + bot + ".png", UriKind.Relative));
        }
    }
}
