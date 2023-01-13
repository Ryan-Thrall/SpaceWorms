using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWorms.Sprites
{
    public class HeroShip : Sprite
    {
        //Control Variables
        public Vector2 Velocity;
        public float MaxSpeed = 10f;
        public float Accel = 1f;
        public HeroShip(Texture2D texture) : base(texture)
        {
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
            Velocity = new Vector2(0, 0);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            MouseState mouseState = FaceMouse();

            this.Position += this.Velocity;
            this._rotation = MathHelper.WrapAngle(this._rotation);
            if (this.Velocity.LengthSquared() > this.MaxSpeed * MaxSpeed)
            {
                this.Velocity.Normalize();
                this.Velocity *= this.MaxSpeed;
            }

            if (mouseState.LeftButton == ButtonState.Pressed)
            {

                this.Velocity += Vector2.Transform(-Vector2.UnitY * this.Accel, Matrix.CreateRotationZ(this._rotation));

            }

        }

        private MouseState FaceMouse()
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

            _rotation = (float)Math.Atan2(mousePosition.X - Position.X, Position.Y - mousePosition.Y);
            return mouseState;
        }
    }
}
