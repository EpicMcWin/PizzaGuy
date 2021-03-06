﻿using System;
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
    class PizzaGuy : MazeGuy
    {
        public PizzaGuy(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity,
            xTile.Layers.Layer map)
            : base(location, texture, initialFrame, velocity, map)
        {
            
        }

         

        public override void Update(GameTime gameTime)
        {
            //HandleKeyboardInput(Keyboard.GetState());
            //pacman.Update(gameTime);
            base.Update(gameTime);
            KeyboardState keyState = Keyboard.GetState();
        
            if (keyState.IsKeyDown(Keys.Up))
            {
                // direction
                direction = Direction.UP;
            }

            else if(keyState.IsKeyDown(Keys.Down))
            {
                direction = Direction.DOWN;
            }

            else if (keyState.IsKeyDown(Keys.Left))
            {
                direction = Direction.LEFT;
            }

            else if (keyState.IsKeyDown(Keys.Right))
            {
                direction = Direction.RIGHT;
            }

            if (Velocity.X > 0 && Location.X >= destination.X ||
                Velocity.X < 0 && Location.X <= destination.X ||
                Velocity.Y > 0 && Location.Y >= destination.Y ||
                Velocity.Y < 0 && Location.Y <= destination.Y ||
                Velocity.X > 0 && direction == Direction.LEFT ||
                Velocity.X < 0 && direction == Direction.RIGHT ||
                Velocity.Y > 0 && direction == Direction.UP ||
                Velocity.Y < 0 && direction == Direction.DOWN)
            {
                {
                    if (CanMove(direction))
                    {
                        UpdateDirection();
                    }
                    else
                    {
                        velocity = new Vector2(0, 0);
                        
                    }

                }
            }

        }
        }
    }

