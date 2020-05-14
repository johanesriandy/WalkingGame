using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
                using (var stream = TitleContainer.OpenStream("Content/charactersheet.png"))
                {
                    characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }

            walkDown = new Animation()
                .AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25))
                .AddFrame(new Rectangle(16, 0, 16, 16), TimeSpan.FromSeconds(.25))
                .AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25))
                .AddFrame(new Rectangle(32, 0, 16, 16), TimeSpan.FromSeconds(.25));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftOfSprite = new Vector2(X, Y);
            Color tintColor = Color.White;
            var sourceRectangle = currentAnimation.CurrentRectangle;

            spriteBatch.Draw(characterSheetTexture, topLeftOfSprite, sourceRectangle, tintColor);
        }

        public void Update(GameTime gameTime)
        {
            currentAnimation = walkDown;
            currentAnimation.Update(gameTime);
        }
    }
}
