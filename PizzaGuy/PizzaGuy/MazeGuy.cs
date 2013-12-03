using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using xTile;
using xTile.Display;
using xTile.Tiles;

namespace PizzaGuy
{
   public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
     
    class MazeGuy : Sprite
    {
        public Direction direction;
        public Vector2 destination;
        public Vector2 otherDestination;
        public xTile.Layers.Layer map;
        public MazeGuy(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity) : base(location, texture, initialFrame, velocity)
        {
            
        }

        public void UpdateDirection()
        {
            switch (direction)
            {
                case Direction.UP:
                    Velocity = new Vector2(0, -100);
                    Rotation = MathHelper.PiOver2;
                    destination = Location - new Vector2(0, 32);
                    break;

                case Direction.DOWN:
                    Velocity = new Vector2(0, 100);
                    Rotation = -MathHelper.PiOver2;
                    destination = Location + new Vector2(0, 32);
                    break;

                case Direction.LEFT:
                    Velocity = new Vector2(-100, 0);
                    Rotation = 0f;
                    destination = Location - new Vector2(32, 0);
                    break;

                case Direction.RIGHT:
                    Velocity = new Vector2(100, 0);
                    Rotation = MathHelper.Pi;
                    destination = Location + new Vector2(32, 0);
                    break;
            }
        }

        public bool CanMove(Direction dir)
        {
            switch (dir)
            {
                case Direction.LEFT:

                    otherDestination += new Vector2(-32, 0);

                    break;

                case Direction.RIGHT:

                    otherDestination += new Vector2(32, 0);


                    break;

                case Direction.UP:

                    otherDestination += new Vector2(0, -32);


                    break;

                case Direction.DOWN:

                    otherDestination += new Vector2(0, 32);


                    break;
            }
           
            if (map.Tiles[(int)otherDestination.X / 32, (int)otherDestination.Y / 32] == null)
            {
                return true;
            }

            return false;
        }



        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        
        
    }
    
}
