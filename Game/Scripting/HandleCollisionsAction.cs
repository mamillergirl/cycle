using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
            
                //HandleSegmentCollisions1(cast);
                //HandleSegmentCollisions2(cast);
                HandleSnakeCollisions1(cast);
                HandleSnakeCollisions2(cast);

                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
       // private void HandleFoodCollisions(Cast cast)
       // {
       //     Snake snake1 = (Snake)cast.GetFirstActor("playerOne");
       //     Snake snake2 = (Snake)cast.GetFirstActor("playerTwo");
       //     Score score = (Score)cast.GetFirstActor("score");
       //    
       //     
       //     if (snake1.GetHead().GetPosition().Equals(food.GetPosition()))
       //     {
       //         int points = food.GetPoints();
       //         snake.GrowTail(points);
       //         score.AddPoints(points);
       //         food.Reset();
       //     }
       // }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions1(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("playerOne");
            Actor head = snake1.GetHead();
            List<Actor> body = snake1.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }
        private void HandleSegmentCollisions2(Cast cast)
        {
            Snake snake2 = (Snake)cast.GetFirstActor("playerTwo");
            Actor head = snake2.GetHead();
            List<Actor> body = snake2.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        } //deez nuts ha gotdeem
        private void HandleSnakeCollisions1(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("playerOne");
            Snake snake2 = (Snake)cast.GetFirstActor("playerTwo");
            Actor head1 = snake1.GetHead();
            List<Actor> body2 = snake2.GetBody();

            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }
         private void HandleSnakeCollisions2(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("playerOne");
            Snake snake2 = (Snake)cast.GetFirstActor("playerTwo");
            Actor head2 = snake2.GetHead();
            List<Actor> body1 = snake1.GetBody();

            foreach (Actor segment in body1)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }
        
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake1 = (Snake)cast.GetFirstActor("playerOne");
                List<Actor> segments1 = snake1.GetSegments();
                Snake snake2 = (Snake)cast.GetFirstActor("playerTwo");
                List<Actor> segments2 = snake2.GetSegments();
                snake1.SetColor(Constants.WHITE);
                snake2.SetColor(Constants.WHITE);

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment1 in segments1)
                {
                    segment1.SetColor(Constants.WHITE);
                }
                foreach (Actor segment2 in segments2)
                {
                    segment2.SetColor(Constants.WHITE);
                }
            }
        }

    }

    }
