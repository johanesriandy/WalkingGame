using System;
using Microsoft.Xna.Framework;

namespace WalkingGame.Core
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
