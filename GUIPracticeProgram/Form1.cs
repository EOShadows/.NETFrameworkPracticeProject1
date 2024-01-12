using System;
using System.Windows.Forms;

namespace GUIPracticeProgram
{
    public partial class Form1 : Form
    {
        // Sprites
        Content sprites;

        // Game object management
        GameObjects objects;

        // Graphics handler
        // suppressed as the object is necessary even if its value is never accessed.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality","IDE0052")]
        GameGraphics graphics;

        // Game loop
        Timer gameTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeSprites();
            InitializeGraphics();
            InitializeObjects();
            StartGameLoop();
        }

        private void InitializeSprites()
        {
            StartNoteForDebug("Initializing sprite content...", DateTime.Now.TimeOfDay);
            sprites = new Content(viewport);
            EndNoteForDebug("Sprite content initialized:", DateTime.Now.TimeOfDay);
        }

        private void InitializeGraphics()
        {
            StartNoteForDebug("Initializing graphics manager...",DateTime.Now.TimeOfDay);
            graphics = new GameGraphics(viewport);
            EndNoteForDebug("Graphics manager initialized:", DateTime.Now.TimeOfDay);
        }

        private void InitializeObjects()
        {
            StartNoteForDebug("Initializing game objects...", DateTime.Now.TimeOfDay);
            objects = new GameObjects(sprites, viewport);
            EndNoteForDebug("Game objects initialized:", DateTime.Now.TimeOfDay);
        }

        private void StartGameLoop()
        {
            StartNoteForDebug("Starting game loop...", DateTime.Now.TimeOfDay);
            gameTimer = new Timer();
            gameTimer.Interval = 10;
            gameTimer.Start();
            gameTimer.Tick += TimerUpdate;
            EndNoteForDebug("Game loop started:", DateTime.Now.TimeOfDay);
        }

        private void TimerUpdate(object sender, EventArgs e)
        {
            objects.UpdateObjects();
            Draw();
        }

        private void Draw()
        {
            viewport.Invalidate();
        }

        // DEBUGGING //////////////////////////////////////////////////
        private void StartNoteForDebug(string msg, TimeSpan now)
        {
            System.Diagnostics.Debug.WriteLine("");
            NoteForDebug(msg, now, '.');
        }
        private void EndNoteForDebug(string msg, TimeSpan now)
        {
            NoteForDebug(msg, now, ':');
            System.Diagnostics.Debug.WriteLine("");
        }
        private void NoteForDebug(string msg, TimeSpan now, char c)
        {
            string line = String.Format("{0}", msg).PadRight(40, c);
            line += now.ToString();
            System.Diagnostics.Debug.WriteLine(line);
        }
    }
}
