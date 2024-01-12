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
    public class GameObjects
    {
        List<NPC> charactersOnScreen;
        List<Obstacle> obstaclesOnScreen;

        internal GameObjects(Content sprites, Control viewport)
        {
            InitializeCharacters(sprites, viewport);
            Entity.DrawWithEntitiesOn(viewport);
        }

        private void InitializeCharacters(Content sprites, Control viewport)
        {
            charactersOnScreen = new List<NPC>();
            obstaclesOnScreen = new List<Obstacle>();

            new NonObstacle(sprites["grass"], "grass");

            PlayerManagement.SetPlayer((Character)Entity.CreateWithModifiedRect(
                new Character(sprites["playerSprite"], "player", 10),
                new Vector2(100, 20),
                new Vector2(0, 1)));

            obstaclesOnScreen.Add((Obstacle)Entity.CreateWithModifiedRect(
                new Obstacle(sprites["obstacle1"], "obstacle1"),
                new Vector2(100, 50),
                new Vector2(0, 1)));
        }

        public void UpdateObjects()
        {
            foreach (var npc in charactersOnScreen)
            {
                npc.Move();
            }
        }
    }
}
