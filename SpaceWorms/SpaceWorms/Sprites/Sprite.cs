using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceWorms.Sprites
{
    public class Sprite : ICloneable
    {
        // Rendering Variables
        protected Texture2D _texture;
        protected float _rotation;
        public float Scale = 1f;
        public Vector2 Position;
        public Vector2 Origin;

        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;
        public Sprite Parent;
        public float lifeSpan = 0f;
        public bool isRemoved = false;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, Scale, SpriteEffects.None, 0f);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
