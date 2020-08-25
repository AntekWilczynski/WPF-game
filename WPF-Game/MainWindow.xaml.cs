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

namespace WPF_Game
{
    public partial class MainWindow : Window
    {


        // create new Rect class instance called player hit box and enemy hit box
        Rect graczHitBox;
        Rect przeciwnikHitBox;
        Rect przeszkodaHitBox;


        ImageBrush playerSprite = new ImageBrush();
        ImageBrush backgroundSprite = new ImageBrush();
        ImageBrush monsterSprite = new ImageBrush();
        ImageBrush przeszkodaSprite = new ImageBrush();

        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            //set the focus on my canvas from the WPF
            myCanvas.Focus();
            // first set the background sprite image
            playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/H_nekro.png"));
            monsterSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/angel.png"));
            backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/background.jpg"));
            // add the background sprite to all rectangles
            background.Fill = backgroundSprite;
            player.Fill = playerSprite;
            monster_angel.Fill = monsterSprite;
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
            if (e.Key == Key.Up && Canvas.GetTop(background) < 460 )
            {
                Canvas.SetTop(background, Canvas.GetTop(background) + 10);
                Canvas.SetTop(monster_angel, Canvas.GetTop(monster_angel) + 10);
                //if (graczHitBox.IntersectsWith(przeciwnikHitBox))
                //   { Window win2 = new Window();
                //    win2.Show(); }
                // this.Close();
                
            }
            else if (e.Key == Key.Down && Canvas.GetTop(background) + background.Height > 700)
            {
                Canvas.SetTop(background, Canvas.GetTop(background) - 10);
                Canvas.SetTop(monster_angel, Canvas.GetTop(monster_angel) - 10);
            }
            else if (e.Key == Key.Right && Canvas.GetLeft(background) + background.Width > 1000)
            {
                Canvas.SetLeft(background, Canvas.GetLeft(background) - 10);
                Canvas.SetLeft(monster_angel, Canvas.GetLeft(monster_angel) - 10);
            }
            else if (e.Key == Key.Left && Canvas.GetLeft(background) <750)
            {
                Canvas.SetLeft(background, Canvas.GetLeft(background) + 10);
                Canvas.SetLeft(monster_angel, Canvas.GetLeft(monster_angel) + 10);
            }
        }
    }
}
