using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Painter 
{
    public class PaintCan : ThreeColorGameObject
    {
        protected Color targetcolor;
        protected float minVelocity;
        protected float positionOffset;
        protected SoundEffect collectPoints;
        

        public PaintCan(ContentManager Content, float positionOffset, Color targetcol) 
                     : base(Content.Load<Texture2D>("spr_can_red"),
                    Content.Load<Texture2D>("spr_can_green"),
                    Content.Load<Texture2D>("spr_can_blue"))
        {
            this.positionOffset = positionOffset;
            collectPoints = Content.Load<SoundEffect>("snd_collect_points");
            targetcolor = targetcol;
            minVelocity = 30;
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            if (velocity.Y == 0.0f && Painter.Random.NextDouble() < 0.01)
            {
                velocity = CalculateRandomVelocity();
                Color = CalculateRandomColor();
            }

            Vector2 distanceVector = ((Painter.GameWorld.Ball.Position + Painter.GameWorld.Ball.Center)
                                        - (position + Center));
            if (Math.Abs(distanceVector.X) < Center.X && Math.Abs(distanceVector.Y) < Center.Y)
            {
                Color = Painter.GameWorld.Ball.Color;
                Painter.GameWorld.Ball.Reset();
            }

            if (Painter.GameWorld.IsOutsideWorld(position))
            {
                if (color == targetcolor)
                {
                    collectPoints.Play();
                }
                Reset();
            }

            minVelocity += 0.001f;
            base.Update(gameTime);
        }

        public override void Reset()
        {
            base.Reset();
            position = new Vector2(positionOffset, -currentColor.Height);
            velocity = Vector2.Zero;
            minVelocity = 30;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public Vector2 CalculateRandomVelocity()
        {
            return new Vector2(0.0f, (float)Painter.Random.NextDouble() * 30 + minVelocity);
        }

        public Color CalculateRandomColor()
        {
            int randomval = Painter.Random.Next(3);
            if (randomval == 0)
                return Color.Red;
            else if (randomval == 1)
                return Color.Green;
            else
                return Color.Blue;
        }
    }

}
