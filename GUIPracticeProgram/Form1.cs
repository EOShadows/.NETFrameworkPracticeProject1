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

        /* Graphics handler ------------- */
        // suppressed as the object is necessary even if its value is never accessed.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality","IDE0052")]
        GameGraphics graphics;
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
            graphics = new GameGraphics(viewport);
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
