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
using xTile.Layers;
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
            Vector2 velocity,
            xTile.Layers.Layer map)
            : base(location, texture, initialFrame, velocity)
        {
            direction = Direction.UP;
            destination = location;
            this.map = map;
            UpdateDirection();
        }
        

        private void imposeMovementLimits()
        {
            Vector2 location = Location;
            //Vector2 center = pacman.Center;

            if (location.X < 0)
                location.X = 0;

            if (location.X >
                (800 - Source.Width))
                location.X =
                    (800 - Source.Width);

            if (location.Y < 0)
                location.Y = 0;

            if (location.Y >
                (480 - Source.Height))
                location.Y =
                    (480 - Source.Height);

            if (location.Y == 218 && location.X == 0)
                location.X = 736;

            if (location.Y == 218 && location.X == 736)
                location.X = 0;


            Location = location;
        }

        public virtual void UpdateDirection()
        {
            switch (direction)
            {
                case Direction.UP:
                    Velocity = new Vector2(0, -32);
                    Rotation = MathHelper.PiOver2;
                    destination = Location - new Vector2(0, 32);
                    break;

                case Direction.DOWN:
                    Velocity = new Vector2(0, 32);
                    Rotation = -MathHelper.PiOver2;
                    destination = Location + new Vector2(0, 32);
                    break;

                case Direction.LEFT:
                    Velocity = new Vector2(-32, 0);
                    Rotation = 0f;
                    destination = Location - new Vector2(32, 0);
                    break;

                case Direction.RIGHT:
                    Velocity = new Vector2(32, 0);
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
                    otherDestination = destination + new Vector2(-32, 0);
                    destination = Location - new Vector2(32, 0);
                    break;

                case Direction.RIGHT:
                    otherDestination = destination + new Vector2(32, 0);
                    destination = Location + new Vector2(32, 0);
                    break;

                case Direction.UP:
                    otherDestination = destination + new Vector2(0, -32);
                    destination = Location - new Vector2(0, 32);
                    break;

                case Direction.DOWN:
                    otherDestination = destination + new Vector2(0, 32);
                    destination = Location + new Vector2(0, 32);
                    break;
            }

            if (map.Tiles[(int)otherDestination.X / 32, (int)otherDestination.Y / 32].TileIndex != 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public override void Update(GameTime gameTime)
        {
            imposeMovementLimits();
            base.Update(gameTime);
        }
        
        
    }
    
}
