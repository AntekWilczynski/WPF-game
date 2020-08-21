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
using System.Windows.Threading;

namespace WPF_Game
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // create a new instance of the dispatcher timer class called gametimer
        DispatcherTimer gameTimer = new DispatcherTimer();

        // create new Rect class instance called player hit box and enemy hit box
        Rect playerHitBox;
        Rect enemyHitBox;

        // game over boolean
        bool gameover = false;
        // make a sprite int double variable, this will be used to swap the sprites for player
        double spriteInt = 0;

        // make three image brush instances called player sprite, background sprite and enemy sprite
        ImageBrush playerSprite = new ImageBrush();
        ImageBrush backgroundSprite = new ImageBrush();
        ImageBrush enemySprite = new ImageBrush();

        //integer array which we will use to change the enemy position on screen
        int[] enemyPosition = {1 ,2 ,3  };
        // empty integer called score
        int score = 0;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void StartGame()
        {

        }

        private void runSprite(double i)
        {

        }

        private void gameEngine(object sender, EventArgs e)
        {

        }
    }
}
