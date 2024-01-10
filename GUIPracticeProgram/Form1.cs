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
    public static class ExtensionMethods
    {
        public static void Add(this Point point, Point otherPoint)
        {
            point.X += otherPoint.X;
            point.Y += otherPoint.Y;
        }
    }

    public class Character
    {
        public int speed { get; set; }
        public string name { get; set; }
        public Control self { get; set; }

        public enum MoveDirection
        {
            UP = 0,
            DOWN = 1,
            RIGHT = 2,
            LEFT = 3
        }

        public Character(Control self, string name, int speed)
        {
            this.self = self;
            this.speed = speed;
            this.name = name;
        }

        public void Move(MoveDirection direction)
        {
            Point movement = new Point(0,0);

            switch (direction)
            {
                case MoveDirection.UP:
                    movement = new Point(0, speed);
                    break;
                case MoveDirection.DOWN:
                    movement = new Point(0, -speed);
                    break;
                case MoveDirection.RIGHT:
                    movement = new Point(speed, 0);
                    break;
                case MoveDirection.LEFT:
                    movement = new Point(-speed, 0);
                    break;
            }

            self.Location.Add(movement);
        }
    }

    public class NPC : Character
    {
        private MoveDirection moveDirection;

        public NPC(Control self, string name, int speed) : base(self, name, speed) { }

        public void Move() { Move(moveDirection); }
    }

    public partial class Form1 : Form
    {
        List<NPC> charactersOnScreen;
        Character player;
        const Character.MoveDirection UP = Character.MoveDirection.UP;
        const Character.MoveDirection DOWN = Character.MoveDirection.DOWN;
        const Character.MoveDirection RIGHT = Character.MoveDirection.RIGHT;
        const Character.MoveDirection LEFT = Character.MoveDirection.LEFT;

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
            player = new Character(button1, "player", 10);
        }

        private void MyUpdate()
        {
            Timer myTimer = new Timer();
            myTimer.Interval = 1000;
            myTimer.Start();
            myTimer.Tick += reactToTimer;
        }

        private void reactToTimer(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("The Tick has happened!");
            foreach (var npc in charactersOnScreen)
            {
                npc.Move();
            }

            CheckInput();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void CheckInput()
        {
            
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Key press:" + e.KeyCode.ToString());

            switch (e.KeyCode)
            {
                case Keys.W:
                    player.Move(UP);
                    break;

                case Keys.S:
                    player.Move(DOWN);
                    break;

                case Keys.D:
                    player.Move(RIGHT);
                    break;

                case Keys.A:
                    player.Move(LEFT);
                    break;
            }
        }
    }
}
