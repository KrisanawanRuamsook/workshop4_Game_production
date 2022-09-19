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
        Texture2D myTexture;
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
            //DOne
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            cloud = Content.Load<Texture2D>("Cloud_sprite");
            myTexture = Content.Load<Texture2D>("NatureSprite 1");
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
            GraphicsDevice.Clear(new Color(85, 133, 50));
            spriteBatch.Begin();
            spriteBatch.Draw(myTexture, new Vector2(1, 1), new Rectangle(64 * 4, 64 * 2, 64 * 4, 64 * 4), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(320, 64), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(320, 128), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(320, 192), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(320, 250), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(256, 250), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(512, 160), new Rectangle(64 * 2, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(416, 282), new Rectangle(64 * 2, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(128, 320), new Rectangle(0, 64 * 3, 64 * 2, 64 * 2), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(384, 64), new Rectangle(0, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(608, 266), new Rectangle(0, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(512, 330), new Rectangle(0, 64, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(608, 96), new Rectangle(64 * 2, 64 * 4, 64 * 2, 64 * 2), Color.White);
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
