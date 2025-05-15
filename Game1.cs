using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Emit;

namespace Cat_Animation_Meme
{

    enum Screen
    {
        Intro,
        End,
        Galaxy
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D background;
        Rectangle window;

        Texture2D catTexture;
        Rectangle catRect;

        Texture2D catHeadTexture;
        Rectangle catHeadRect;
        Vector2 catHeadSpeed;

        Texture2D catBodyTexture;
        Rectangle catBodyRect;

        Texture2D catIntroTexture;
        Rectangle catIntroRect;
        Vector2 catIntroSpeed;

        MouseState mouseState;

        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            screen = Screen.Intro;

            catHeadRect = new Rectangle(125, 50, 550, 550);
            catHeadSpeed = new Vector2(2, 2);

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            background = Content.Load<Texture2D>("cat_galaxy_background");

            catTexture = Content.Load<Texture2D>("cat_base");
            catBodyTexture = Content.Load<Texture2D>("cat_body");
            catHeadTexture = Content.Load<Texture2D>("cat_head");
            catIntroTexture = Content.Load<Texture2D>("cat_intro");

        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            this.Window.Title = "x =" + mouseState.X + ", y = " + mouseState.Y;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Galaxy;
            }

            if (screen == Screen.Galaxy)
            {
                catHeadRect.X += (int)catHeadSpeed.X;
                if (catHeadRect.Right >= window.Width || catHeadRect.Left <= 0)
                    catHeadSpeed.X *= -1;
                catHeadRect.Y += (int)catHeadSpeed.Y;
                if (catHeadRect.Top >= 150)
                    catHeadRect.Y = - catHeadRect.Height;
            }

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.DarkGray);

                _spriteBatch.Draw(catBodyTexture, new Rectangle(125, 50, 550, 550), Color.DarkGray);
                _spriteBatch.Draw(catHeadTexture, new Rectangle(125, 50, 550, 550), Color.DarkGray);
            }

            else if (screen == Screen.Galaxy)
            {
                _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);

                _spriteBatch.Draw(catBodyTexture, new Rectangle(125, 50, 550, 550), Color.White);
                _spriteBatch.Draw(catHeadTexture, new Rectangle(125, 50, 550, 550), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
