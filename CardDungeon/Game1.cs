using CardDungeon.GameComponent;
using CardDungeon.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CardDungeon
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D renderTarget;
        ScreenBase currentScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Settings.WIDTH_TARGET;
            graphics.PreferredBackBufferHeight = Settings.HEIGHT_TARGET;
        }

        protected override void Initialize()
        {
            ContentLoader.init(Content);
            base.Initialize();
            this.renderTarget = new RenderTarget2D(GraphicsDevice, Settings.WIDTH_SOURCE, Settings.HEIGHT_SOURCE);
            this.IsMouseVisible = true;

            this.changeScreen(new ScreenGameMenu(this));
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.currentScreen.Update(gameTime);
            Input.Listen();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.SaddleBrown);

            spriteBatch.Begin();
            // Small drawing
            currentScreen.Draw(spriteBatch);

            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            // Scaled drawing
            spriteBatch.Draw(renderTarget, new Rectangle(0,0, Settings.WIDTH_TARGET, Settings.HEIGHT_TARGET),Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void changeScreen(ScreenBase newScreen)
        {
            currentScreen = newScreen;
            currentScreen.initialize();
        }
    }
}
