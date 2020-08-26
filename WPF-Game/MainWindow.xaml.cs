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
    public partial class MainWindow : Window
    {


        // create new Rect class instance called player hit box and enemy hit box
        Rect graczHitBox;
        Rect przeciwnikHitBox;
        Rect przeszkodaHitBox;


        DispatcherTimer gameTimer = new DispatcherTimer();
        Random rand = new Random();
        ImageBrush graczSprite = new ImageBrush();
        ImageBrush tloSprite = new ImageBrush();
        ImageBrush przeciwnikSprite = new ImageBrush();
        ImageBrush przeszkodaSprite = new ImageBrush();

        double playerAnimationSpriteCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
            myCanvas.Focus();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            gameTimer.Tick += gameEngine;                                      // assign the game engine event to the game timer tick
            gameTimer.Interval = TimeSpan.FromMilliseconds(30);                // set the game timer interval to 20 milliseconds
            tloSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/background.jpg"));
            background.Fill = tloSprite;

            StartGame();

            graczHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
            przeciwnikHitBox = new Rect(Canvas.GetLeft(monster_angel), Canvas.GetTop(monster_angel), monster_angel.Width, monster_angel.Height);
            przeszkodaHitBox = new Rect(Canvas.GetLeft(przeszkoda), Canvas.GetTop(przeszkoda), przeszkoda.Width, przeszkoda.Height);
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && Canvas.GetTop(background) < 460)
            {
                Canvas.SetTop(background, Canvas.GetTop(background) + 10);
                Canvas.SetTop(monster_angel, Canvas.GetTop(monster_angel) + 10);
                //graczHitBox.Location = new Point(Canvas.GetTop(monster_angel), Canvas.GetLeft(monster_angel));
                //przeciwnikHitBox.Location = new Point(Canvas.GetTop(player), Canvas.GetLeft(player));

                if (graczHitBox.IntersectsWith(przeciwnikHitBox))
                {
                    Window win2 = new Window();
                    win2.Show();
                }
            }
            else if (e.Key == Key.Down && Canvas.GetTop(background) + background.Height > 700)
            {
                Canvas.SetTop(background, Canvas.GetTop(background) - 10);
                Canvas.SetTop(monster_angel, Canvas.GetTop(monster_angel) - 10);
                if (graczHitBox.IntersectsWith(przeciwnikHitBox))
                {
                    Window win2 = new Window();
                    win2.Show();
                }
            }

            else if (e.Key == Key.Right && Canvas.GetLeft(background) + background.Width > 1000)
            {
                Canvas.SetLeft(background, Canvas.GetLeft(background) - 10);
                Canvas.SetLeft(monster_angel, Canvas.GetLeft(monster_angel) - 10);
                if (graczHitBox.IntersectsWith(przeciwnikHitBox))
                {
                    Window win2 = new Window();
                    win2.Show();
                }

            }
            else if (e.Key == Key.Left && Canvas.GetLeft(background) < 750)
            {
                Canvas.SetLeft(background, Canvas.GetLeft(background) + 10);
                Canvas.SetLeft(monster_angel, Canvas.GetLeft(monster_angel) + 10);
                if (graczHitBox.IntersectsWith(przeciwnikHitBox))
                {
                    Window win2 = new Window();
                    win2.Show();
                }
            }
        }
        private void StartGame()
        {
            runSprite(1);
            graczSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/H_nekro.png"));
            przeciwnikSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/angel.png"));
            player.Fill = graczSprite;
            monster_angel.Fill = przeciwnikSprite;
            gameTimer.Start();
        }


        private void runSprite(double i)
        {
            switch (i)
            {
                case 1:
                    graczSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/H_nekro3.png"));
                    break;
                case 2:
                    graczSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/H_nekro2.png"));
                    break;
                case 3:
                    graczSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/H_nekro1.png"));
                    break;
                case 4:
                    graczSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/H_nekro3.png"));
                    break;
                case 5:
                    graczSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/H_nekro4.png"));
                    break;
            }
            player.Fill = graczSprite;
        }

        private void gameEngine(object sender, EventArgs e)
        {
            graczHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
            przeszkodaHitBox = new Rect(Canvas.GetLeft(przeszkoda), Canvas.GetTop(przeszkoda), przeszkoda.Width, przeszkoda.Height);
            playerAnimationSpriteCounter += .5;
            runSprite(playerAnimationSpriteCounter);
            if (playerAnimationSpriteCounter > 5)
                playerAnimationSpriteCounter = 1;
           
        }
    }
}

