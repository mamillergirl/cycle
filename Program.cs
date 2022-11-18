using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;
using System.Numerics;
using Unit05.Game;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            

           
            cast.AddActor("playerOne", new Snake(Constants.RED, new System.Numerics.Vector2(Constants.CELL_SIZE * 30,Constants.CELL_SIZE* 30)));
            cast.AddActor("playerTwo", new Snake(Constants.GREEN, new System.Numerics.Vector2(Constants.CELL_SIZE * 10 ,Constants.CELL_SIZE * 10)));
    

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction1(keyboardService));
            script.AddAction("input", new ControlActorsAction2(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new MakeTrailAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}