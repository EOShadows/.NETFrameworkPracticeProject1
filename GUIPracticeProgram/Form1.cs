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
        List<NPC> charactersOnScreen;
        List<Obstacle> obstaclesOnScreen;

        Character player;

        public Form1()
        {
            InitializeComponent();
            InitializeCharacters();

            panel1.Paint += new PaintEventHandler(UpdatePaint);

            Timer myTimer = new Timer();
            myTimer.Interval = 20;
            myTimer.Start();
            myTimer.Tick += reactToTimer;
        }

        private void InitializeCharacters()
        {
            charactersOnScreen = new List<NPC>();
            obstaclesOnScreen = new List<Obstacle>();

            Sprite playerSprite = new Sprite(
                global::GUIPracticeProgram.Properties.Resources.creepyplushtoy,
                new Rectangle(new Point(0, 0), new Size(60, 60)));
            Sprite obstacleSprite = new Sprite(
               global::GUIPracticeProgram.Properties.Resources.tileTexture1,
               new Rectangle(new Point(80, 80), new Size(60, 60)));

            Sprite grass = new Sprite(
               Color.GreenYellow,
               new Rectangle(new Point(0, 0), new Size(panel1.Width, panel1.Height)));

            new NonObstacle(grass, "grass");

            player = (Character)Entity.CreateWithModifiedRect(
                new Character(playerSprite, "player", 10), 
                new Vector2(100,20), 
                new Vector2(0,1)); //new Character(playerPicture, "player", 10);

            obstaclesOnScreen.Add(/*new Obstacle(pictureBox1, "obstacle1")*/(Obstacle)Entity.CreateWithModifiedRect(
                new Obstacle(obstacleSprite, "obstacle1"),
                new Vector2(100, 50),
                new Vector2(0,1)));

            Entity.DrawWithEntitiesOn(panel1);
        }

        private void reactToTimer(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("The Tick has happened!");
            foreach (var npc in charactersOnScreen)
            {
                npc.Move();
            }

            Draw();
        }

        private void Draw()
        {
            panel1.Invalidate();
        }

        private void UpdatePaint(object sender, PaintEventArgs e)
        {
            foreach (Entity entity in Entity.all)
            {
                entity.DrawSprite(e.Graphics);
            }
        }

        private void CheckInput(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Key down: " + e.KeyCode.ToString());

            if (e.KeyCode == Keys.W)        { player.Move(Character.UP); }
            else if (e.KeyCode == Keys.S)   { player.Move(Character.DOWN); }
            else if (e.KeyCode == Keys.D)   { player.Move(Character.RIGHT); }
            else if (e.KeyCode == Keys.A)   { player.Move(Character.LEFT); }
        }

        private void playerPicture_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
