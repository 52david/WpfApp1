using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO; 
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for KrestikiNoliki.xaml
    /// </summary>


    public partial class KrestikiNoliki : Window
    {
        Game game = new Game();
        Player player1;
        Player player2;

        bool Bot = false;
        Random r = new Random();
        Game game1 = new Game();

        Button[,] buttons = new Button[3, 3];
        public KrestikiNoliki()
        {
            InitializeComponent();
            player1 = player1;
            player2 = player2;

            buttons[0, 0] = b00;
            buttons[0, 1] = b01;
            buttons[0, 2] = b02;

            buttons[1, 0]=b10;
            buttons[1, 1] = b11;
            buttons[1, 2]=b12;

            buttons[2,0]=b20;
            buttons[2,1] = b21;
            buttons[2,2] = b22;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int rad = Grid.GetRow(btn);
            int kol = Grid.GetColumn(btn);

            if (game.Chod(rad, kol))
            {
                btn.Content = game.TekushijPlayer;

                if (game.CheckWin())
                {
                    MessageBox.Show("Win " + game.TekushijPlayer);
                    return;
                }

                game.SwitchPlayer();

                if (Bot == true)
                {
                    ChodBota();

                    if (game.CheckWin())
                    {
                        MessageBox.Show("Win " + game.TekushijPlayer);
                        return;
                    }
                    game.SwitchPlayer();
                }
                
            }
        }
        private void Friend_Click(object sender, RoutedEventArgs e)
        {
            Bot = false;
            VyborPanel.Visibility = Visibility.Hidden;
        }
        private void Bot_click(object sender, RoutedEventArgs e)
        {
            Bot = true;
            VyborPanel.Visibility = Visibility.Hidden;
        }

        private void ChodBota()
        {
            while (true)
            {
                int rad = r.Next(0, 3);
                int kol = r.Next(0, 3);

                if (game.Chod(rad, kol))
                {
                    buttons[rad, kol].Content = game.TekushijPlayer;
                    
                    break;                }
                 }
        }




    }
}
