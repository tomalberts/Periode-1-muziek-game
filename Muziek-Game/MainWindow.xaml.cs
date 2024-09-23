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

namespace Muziek_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //pubieke variablen
        public int[] portaalpositie = { 1000, 200 };


        public MainWindow()
        {
            InitializeComponent();
            Canvas GameCanvas = new Canvas();
            StartGame();
        }

        public int StartGame()
        {
            try
            {
                // Start de game zo mogelijk

                initializePlayer("Player-1", "Default", 250);
                initializePortal();

                return 1;

            }
            catch (Exception)
            {
                // Catch Error als er een is

                //hier de rest van de codebase!

                return 0;
            }
        }

        public int initializePlayer(string name, string skin, int Health)
        {
            try
            {
                // Creeer een nieuwe speler

                //hier de rest van de codebase!

                return 1;

            }
            catch (Exception)
            {
                // Catch Error als er een is

                //hier de rest van de codebase!

                return 0;
            }
        }

        private Rectangle portal;

        public int initializePortal()
        {

            try
            {
                portal = new Rectangle
                {
                    Width = 250,
                    Height = 300,
                    Stroke = Brushes.Black,
                    StrokeThickness = 4

                };

                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/NetherPortal.png", UriKind.Absolute));
                portal.Fill = imageBrush;

                Canvas.SetLeft(portal, portaalpositie[0]); // Horizontaal (offset vanaf links)
                Canvas.SetTop(portal, portaalpositie[1]);  // Verticaal (offset vanaf boven)

                GameCanvas.Children.Add(portal);

                return 1;

            }
            catch (Exception error)
            {
                // Catch Error als er een is

                Console.WriteLine(error);

                return 0;
            }

        }
    }
}
