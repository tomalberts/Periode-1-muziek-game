using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Muziek_Game
{
    public partial class MainWindow : Window
    {
        private List<Block> blocks;
        private Canvas gameCanvas;
        private PortalManager portalManager;
        private int[] portalPositie = { 1000, 200 };
        private Stopwatch stopwatch; // Voor delta timing
        private long previousTime;

        public MainWindow()
        {
            InitializeComponent();

            gameCanvas = GameCanvas;
            portalManager = new PortalManager();

            StartGame();

            // Start stopwatch voor nauwkeurige tijdsmetingen
            stopwatch = new Stopwatch();
            stopwatch.Start();
            previousTime = stopwatch.ElapsedMilliseconds;

            // Gebruik CompositionTarget.Rendering voor betere synchronisatie met de rendering
            CompositionTarget.Rendering += GameLoop;
        }

        public int StartGame()
        {
            try
            {
                blocks = new List<Block>();

                // Bepaal de Y-posities voor de bovenste en onderste rij
                int upperRowY = 200; // Y-positie voor de bovenste rij
                int lowerRowY = 350; // Y-positie voor de onderste rij, met meer afstand (bijv. 200 pixels verschil)

                // Array die bepaalt of een blok in de bovenste rij (true) of onderste rij (false) komt
                bool[] blockRows = new bool[] { true, false, true, true, false, false, true, false }; // Pas aan op je patroon

                // Spawn blokken op basis van de array
                for (int i = 0; i < blockRows.Length; i++)
                {
                    int startX = 800 + i * 100; // Verschuif elk blok naar rechts

                    if (blockRows[i])
                    {
                        // Plaats in de bovenste rij
                        SpawnBlock(upperRowY, startX, true);
                    }
                    else
                    {
                        // Plaats in de onderste rij
                        SpawnBlock(lowerRowY, startX, false);
                    }
                }

                // Initialiseer het portaal
                portalManager.InitializePortal(gameCanvas, portalPositie);

                return 1;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return 0;
            }
        }



        private void GameLoop(object sender, EventArgs e)
        {
            // Bereken de delta time sinds de laatste frame
            long currentTime = stopwatch.ElapsedMilliseconds;
            double deltaTime = (currentTime - previousTime) / 1000.0; // Omzetten naar seconden
            previousTime = currentTime;

            UpdateBlocks(deltaTime);
        }

        public void SpawnBlock(int startY, int startX, bool firstRow)
        {
            Block block = new Block(gameCanvas, startY, startX, firstRow, 100); // Snelheid = 100
            blocks.Add(block);
        }

        public void UpdateBlocks(double deltaTime)
        {
            foreach (var block in blocks)
            {
                block.MoveLeft(deltaTime);
            }
        }
    }
}
