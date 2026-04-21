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
        public KrestikiNoliki()
        {
            InitializeComponent();
            player1 = player1;
            player2 = player2;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);

            if (game.Chod(row, col)) 
            {
                btn.Content = game.TekushijPlayer; 

                if (game.CheckWin())
                {
                    MessageBox.Show("Win " + game.TekushijPlayer);
                    return;
                }

                game.SwitchPlayer();
            }
        }

        
        
    }
}
