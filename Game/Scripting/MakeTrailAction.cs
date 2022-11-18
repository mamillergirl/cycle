using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
     public class MakeTrailAction : Action
    {
       
        
        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public MakeTrailAction()
        {
         
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake p1 = (Snake)cast.GetFirstActor("playerOne");
            Snake p2 = (Snake)cast.GetFirstActor("playerTwo");
            p1.GrowTail(1);
            p2.GrowTail(1);
           
        }
    }
}

