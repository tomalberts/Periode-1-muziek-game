using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Muziek_Game
{
    internal class Block
    {
        private Rectangle block_obj;
        private double Speed = 1;
        private Canvas GameCanvas;

        public Block(Canvas canvas, int starty, int startx, bool firstrow)
        {
            int width = 50;
            int height = 50;

            GameCanvas = canvas;

            block_obj = new Rectangle()
            {
                Width = width,
                Height = height,
                Fill = System.Windows.Media.Brushes.Red
            };

            Canvas.SetLeft(block_obj, startx);
            if (firstrow)
                Canvas.SetTop(block_obj, starty);
            else
            Canvas.SetTop(block_obj, starty - 50);

            GameCanvas.Children.Add(block_obj);
        }


    }
}
