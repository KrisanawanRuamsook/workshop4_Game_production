using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace workshop4_02_642110252
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D cloud;

        Vector2[] scaleCloud;
        Vector2[] clodPos;
        int[] speedCloud;

        Random r = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            cloud = Content.Load<Texture2D>("Cloud_sprite");

            clodPos = new Vector2[4];
            scaleCloud = new Vector2[4];
            speedCloud = new int[4];

            for(int i = 0; i < 4; i++)
            {
                clodPos[i].Y= r.Next(0, _graphics.GraphicsDevice.Viewport.Height - cloud.Height);
                scaleCloud[i].X = r.Next(1, 3);
                scaleCloud[i].Y = scaleCloud[i].X;
                speedCloud[i] = r.Next(5, 8);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < 4; i++)
            {
                clodPos[i].X += speedCloud[i];
                if (clodPos[i].X > _graphics.GraphicsDevice.Viewport.Width)
                {
                    clodPos[i].X = 0;
                    clodPos[i].Y = r.Next(0, _graphics.GraphicsDevice.Viewport.Height - cloud.Height);
                    scaleCloud[i].X = r.Next(1, 3);
                    scaleCloud[i].Y = scaleCloud[i].X;
                }

            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            for(int i = 0; i < 4; i++)
            {
                _spriteBatch.Draw(cloud,clodPos[i],null, Color.White, 0, Vector2.Zero, scaleCloud[i], 0, 0);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
