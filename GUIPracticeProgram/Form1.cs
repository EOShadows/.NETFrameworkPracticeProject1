using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIPracticeProgram
{
    public partial class Form1 : Form
    {
        /* Sprites ---------------------- */
        Content sprites;
        /* ------------------------------ */

        /* Game objectes ---------------- */
        List<NPC> charactersOnScreen;
        List<Obstacle> obstaclesOnScreen;
        Character player;
        /* ------------------------------ */

        /* Viewport information --------- */
        Image viewportImage;
        Graphics graphics;
        /* ------------------------------ */

        /* Game loop ---------------- */
        Timer gameTimer;
        /* ------------------------------ */

        public Form1()
        {
            InitializeComponent();
            InitializeSprites();
            InitializeGraphics();
            InitializeCharacters();
            StartGameLoop();
        }

        private void InitializeSprites()
        {
            sprites = new Content(viewport);
        }

        private void InitializeGraphics()
        {
            viewportImage = new Bitmap(viewport.Width, viewport.Height);
            graphics = Graphics.FromImage(viewportImage);
            viewport.Paint += new PaintEventHandler(UpdatePaint);
        }

        private void InitializeCharacters()
        {
            charactersOnScreen = new List<NPC>();
            obstaclesOnScreen = new List<Obstacle>();

            new NonObstacle(sprites["grass"], "grass");

            player = (Character)Entity.CreateWithModifiedRect(
                new Character(sprites["playerSprite"], "player", 10),
                new Vector2(100, 20),
                new Vector2(0, 1));

            obstaclesOnScreen.Add((Obstacle)Entity.CreateWithModifiedRect(
                new Obstacle(sprites["obstacle1"], "obstacle1"),
                new Vector2(100, 50),
                new Vector2(0, 1)));

            Entity.DrawWithEntitiesOn(viewport);
        }

        private void StartGameLoop()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 10;
            gameTimer.Start();
            gameTimer.Tick += TimerUpdate;
        }

        private void TimerUpdate(object sender, EventArgs e)
        {
            UpdateObjects();
            Draw();
        }

        private void UpdateObjects()
        {
            foreach (var npc in charactersOnScreen)
            {
                npc.Move();
            }
        }

        private void Draw()
        {
            viewport.Invalidate();
        }

        private void UpdatePaint(object sender, PaintEventArgs e)
        {
            PrepareViewport();
            DrawViewport(e.Graphics);
        }

        private void PrepareViewport()
        {
            Entity.all.Sort();

            foreach (Entity entity in Entity.all)
            {
                entity.DrawSprite(graphics);
            }
        }

        private void DrawViewport(Graphics g)
        {
            g.Clear(Color.Black);
            g.DrawImage(viewportImage, new Point(0, 0));
        }

        private void CheckInput(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Key down: " + e.KeyCode.ToString());

            if (e.KeyCode == Keys.W)        { player.Move(Character.UP); }
            else if (e.KeyCode == Keys.S)   { player.Move(Character.DOWN); }
            else if (e.KeyCode == Keys.D)   { player.Move(Character.RIGHT); }
            else if (e.KeyCode == Keys.A)   { player.Move(Character.LEFT); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
