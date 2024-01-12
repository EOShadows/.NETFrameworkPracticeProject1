# C# .NET Framework WinForms Project
## Initial video game code written from scratch using the system's graphics class.

#### Description of work
- Writing this code has not only allowed me to practice and gain more experience in C# and the .NET Framework, but
  also demonstrates my ability to write good clean code that can accomplish something cool.
- The project initially began with simply practicing C# and the .NET Framework with the Microsoft Visual Studio Windows Form project, but then
  grew into removing a lot of the template code and turning the windows form into the beginning of a game.
- Back in highschool this was something I really wanted to do but couldn't figure out how using this very framework.
  I eventually started using the XNA framework instead, then Monogame, then Unity.  This time I was easily able
  to accomplish what I did here, demonstrating to myself how far along I have come since then.

#### One of the features of this code that I am proud of is how easy it is to add an obstacle to the game.
- All it takes is adding two statements.
  - One to the Content class to add the Sprite to the Sprite dictionary, then
  - One to the GameObject class to add an Entity object using the new Sprite.

https://github.com/EOShadows/GUIProgramPractice/assets/82051175/3e863be1-bd80-4cd8-a3ad-15a154a51f57

#### Additionally, how organized and clean I was able to write all of the code while still maintaining the functionality.
It starts with the class that runs the whole game, in the Form1.cs file.
It's main responsability is kept to running the game loop.  It initializes instances of the classes that have the responsabilities
of the performing the details, then makes calls to update game objects and draw the graphics, which are differed to the classes
whose responsabilties are to do those things.

https://github.com/EOShadows/GUIProgramPractice/blob/6eb00bf094ccb7fcdc8f1b3cd92db65637969a9b/GUIPracticeProgram/Form1.cs#L1-L91

The most important classes for these things are the 
- Content class
https://github.com/EOShadows/GUIProgramPractice/blob/6eb00bf094ccb7fcdc8f1b3cd92db65637969a9b/GUIPracticeProgram/Content.cs#L1-L38
- Graphics class
https://github.com/EOShadows/GUIProgramPractice/blob/6eb00bf094ccb7fcdc8f1b3cd92db65637969a9b/GUIPracticeProgram/GameGraphics.cs#L1-L76
- Game objects class
https://github.com/EOShadows/GUIProgramPractice/blob/6eb00bf094ccb7fcdc8f1b3cd92db65637969a9b/GUIPracticeProgram/GameObjects.cs#L1-L59
- and the PlayerManagement
https://github.com/EOShadows/GUIProgramPractice/blob/6eb00bf094ccb7fcdc8f1b3cd92db65637969a9b/GUIPracticeProgram/PlayerManagement.cs#L1-L32
I am proud of all of the code I wrote in this short project, but as a lot of it is much larger, rather than putting them here, they can just be viewed by looking in the [source code itself](GUIPracticeProgram).
