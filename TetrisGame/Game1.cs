using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TetrisLibrary;

namespace TetrisGame
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		BoardSprite boardSprite;
		ShapeSprite shapeSprite;
		ScoreSprite scoreSprite;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			Board board = new Board();
			Score score = new Score(board);

			boardSprite = new BoardSprite(this, board);
			Components.Add(boardSprite);
			shapeSprite = new ShapeSprite(this, board, score);
			Components.Add(shapeSprite);
			scoreSprite = new ScoreSprite(this, score);
			Components.Add(scoreSprite);

			graphics.PreferredBackBufferHeight = 555;
			graphics.PreferredBackBufferWidth = 450;
			graphics.ApplyChanges();

			base.Initialize();
			board.GameOver += gameOver;
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
				Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(new Color(10, 10, 10));

			base.Draw(gameTime);
		}

		//If the game is over, the shape is removed, and the appropriate message is displayed.
		private void gameOver() 
		{
			Components.Remove(shapeSprite);
            scoreSprite.HandleGameOver();
		}
	}
}
