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


            Timer myTimer = new Timer();
            myTimer.Interval = 1000;
            myTimer.Start();
            myTimer.Tick += reactToTimer;
        }

        private void InitializeCharacters()
        {
            charactersOnScreen = new List<NPC>();
            obstaclesOnScreen = new List<Obstacle>();

            player = (Character)Entity.CreateWithModifiedRect(
                new Character(playerPicture, "player", 10), 
                new Vector2(100,50), 
                new Vector2(0,1));

            obstaclesOnScreen.Add(new Obstacle(pictureBox1, "obstacle1")/*(Obstacle)Entity.CreateWithModifiedRect(
                new Obstacle(pictureBox1, "obstacle1"),
                new Vector2(100, 50),
                new Vector2(0,1))*/);
        }

        private void reactToTimer(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("The Tick has happened!");
            foreach (var npc in charactersOnScreen)
            {
                npc.Move();
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
    }
}
