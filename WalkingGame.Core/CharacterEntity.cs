using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace WalkingGame.Core
{
    public class CharacterEntity
    {
        static Texture2D characterSheetTexture;

        public float X { get; set; }
        public float Y { get; set; }

        Animation walkDown;
        Animation currentAnimation;

        public CharacterEntity(GraphicsDevice graphicsDevice)
        {
            if (characterSheetTexture == null)
            {
                using var stream = TitleContainer.OpenStream("Content/charactersheet.png");
                characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
            }

            walkDown = new Animation()
                .AddFrame(new Rectangle(0, 0, 32, 32), TimeSpan.FromSeconds(.25))
                .AddFrame(new Rectangle(32, 0, 32, 32), TimeSpan.FromSeconds(.25))
                .AddFrame(new Rectangle(0, 0, 32, 32), TimeSpan.FromSeconds(.25))
                .AddFrame(new Rectangle(64, 0, 32, 32), TimeSpan.FromSeconds(.25));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftOfSprite = new Vector2(X, Y);
            Color tintColor = Color.Yellow;
            var sourceRectangle = currentAnimation.CurrentRectangle;

            spriteBatch.Draw(characterSheetTexture, topLeftOfSprite, sourceRectangle, tintColor);
        }

        public void Update(GameTime gameTime)
        {
            var velocity = GetDesireVelocityFromInput();

            X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentAnimation = walkDown;
            currentAnimation.Update(gameTime);
        }

        Vector2 GetDesireVelocityFromInput()
        {
            Vector2 desireVelocity = new Vector2();

            TouchCollection touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                desireVelocity.X = touchCollection.First().Position.X - X;
                desireVelocity.Y = touchCollection.First().Position.Y - Y;

                if (desireVelocity.X != 0 || desireVelocity.Y != 0)
                {
                    desireVelocity.Normalize();
                    const float desiredSpeed = 200;
                    desireVelocity *= desiredSpeed;
                }
            }

            return desireVelocity;
        }
    }
}
