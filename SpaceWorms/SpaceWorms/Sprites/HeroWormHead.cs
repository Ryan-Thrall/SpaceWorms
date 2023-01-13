using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWorms.Sprites
{
    public class HeroWormHead : Sprite
    {
        //Control Variables
        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;
        public Vector2 Direction;

        public HeroWormHead(Texture2D texture) : base(texture)
        {
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
            Scale = 1f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (_currentKey.IsKeyDown(Keys.A))
            {
                _rotation -= MathHelper.ToRadians(RotationVelocity);

            }
            if (_currentKey.IsKeyDown(Keys.D))
            {
                _rotation += MathHelper.ToRadians(RotationVelocity);
            }

            Direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - _rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - _rotation));

            Position += Direction * LinearVelocity;

        }
    }
}
