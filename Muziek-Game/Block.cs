using System.Windows.Controls;
using System.Windows.Shapes;

namespace Muziek_Game
{
    internal class Block
    {
        private Rectangle block_obj;
        private double speed; // Snelheid in pixels per seconde
        private Canvas gameCanvas;

        public Block(Canvas canvas, int startY, int startX, bool firstRow, double speed)
        {
            this.speed = speed; // Stel de snelheid in

            gameCanvas = canvas;

            block_obj = new Rectangle()
            {
                Width = 50,
                Height = 50,
                Fill = System.Windows.Media.Brushes.Red
            };

            Canvas.SetLeft(block_obj, startX);
            if (firstRow)
                Canvas.SetTop(block_obj, startY);
            else
                Canvas.SetTop(block_obj, startY - 50);

            gameCanvas.Children.Add(block_obj);
        }

        // Verplaats het blok naar links, rekening houdend met deltaTime
        public void MoveLeft(double deltaTime)
        {
            // Bereken de nieuwe positie
            double left = Canvas.GetLeft(block_obj);
            double newLeft = left - speed * deltaTime; // Snelheid wordt vermenigvuldigd met deltaTime

            // Verplaats het blok naar de nieuwe positie
            Canvas.SetLeft(block_obj, newLeft);
        }
    }
}
