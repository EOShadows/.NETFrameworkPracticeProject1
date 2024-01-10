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
            player = new Character(playerPicture, "player", 10);
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
        }

        private void CheckInput(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Key down: " + e.KeyCode.ToString());

            if (e.KeyCode == Keys.W)        { player.Move(UP); }
            else if (e.KeyCode == Keys.S)   { player.Move(DOWN); }
            else if (e.KeyCode == Keys.D)   { player.Move(RIGHT); }
            else if (e.KeyCode == Keys.A)   { player.Move(LEFT); }
        }

        private void playerPicture_Click(object sender, EventArgs e)
        {

        }
    }

    public static class ExtensionMethods
    {
        public static Point Plus(this Point point, Point otherPoint)
        {
            int x = point.X + otherPoint.X;
            int y = point.Y + otherPoint.Y;

            return new Point(x, y);
        }
    }

    public class Entity
    {
        public string name { get; set; }
        public Control self { get; set; }

        public Entity(Control self, string name)
        {
            this.self = self;
            this.name = name;
        }

        public bool Intersects(Point point)
        {
            bool condition1 = point.X >= self.Left && point.X <= self.Right;
            bool condition2 = point.Y <= self.Bottom && point.Y >= self.Top;

            return (condition1 && condition2);
        }
    }

    public class Character : Entity
    {
        public int speed { get; set; }

        public enum MoveDirection
        {
            UP = 0,
            DOWN = 1,
            RIGHT = 2,
            LEFT = 3
        }

        public Character(Control self, string name, int speed) : base (self, name)
        {
            this.self = self;
            this.speed = speed;
            this.name = name;
        }

        public void Move(MoveDirection direction)
        {
            Point movement = new Point(0, 0);

            switch (direction)
            {
                case MoveDirection.UP:
                    movement = new Point(0, -speed);
                    break;
                case MoveDirection.DOWN:
                    movement = new Point(0, speed);
                    break;
                case MoveDirection.RIGHT:
                    movement = new Point(speed, 0);
                    break;
                case MoveDirection.LEFT:
                    movement = new Point(-speed, 0);
                    break;
            }

            self.Location = self.Location.Plus(movement);
        }
    }

    public class NPC : Character
    {
        private MoveDirection moveDirection;

        public NPC(Control self, string name, int speed) : base(self, name, speed) { }

        public void Move() { Move(moveDirection); }
    }

    public class Obstacle : Entity
    {
        public Obstacle(Control self, string name) : base (self, name) { }
    }
}
