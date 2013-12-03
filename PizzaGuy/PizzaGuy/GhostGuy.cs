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
    class GhostGuy : MazeGuy
    {
        Random rand = new Random();
        public float timer = 0f;
        public PizzaGuy pacman;
        public GhostGuy ghost;

        public GhostGuy(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity,
            xTile.Layers.Layer map,
            PizzaGuy pacman)
            : base(location, texture, initialFrame, velocity)
        {
            this.pacman = pacman;
        }

        //public override void UpdateDirection()
        //{
        //    base.UpdateDirection();
        //}

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer >= 0)
            {
                timer = 0;

                direction = (Direction)rand.Next(0, 5);

                while (!CanMove(direction))
                    direction = (Direction)rand.Next(0, 5);
            }
        }
    }
}
