using System;
using System.CodeDom;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using static Connect_Four.GameEngine;

namespace Connect_Four
{
    // MoFalSha's Project Connect Four (I'm Still Learning)
    public enum enGrid { empty = 0, green = 1, red = 2 };

    public class GameController
    {
        private GameEngine Game;
        private BoardRenderer Renderer;
        private Label PlayerTurn;

        private void UpdateLabelPlayerTurn()
        {
            if (enPlayerTurn.greenTurn == Game.getPlayerTurn())
            {
                PlayerTurn.Text = "Green Turn";
                PlayerTurn.BackColor = Color.Green;
                PlayerTurn.ForeColor = Color.Black;
               
            }
            else
            {
                PlayerTurn.Text = "Red Turn";
                PlayerTurn.BackColor = Color.Red;
                PlayerTurn.ForeColor = Color.Black;
            }
        }

        public GameController(Panel GamePanel,Label PlayerTurn)
        {
            Game = new GameEngine();
            Renderer = new BoardRenderer(GamePanel,Game.getGameGridClone());
            this.PlayerTurn = PlayerTurn;
            UpdateLabelPlayerTurn();
        }

        public bool HandleAMove(int column)
        {
            if (Game.makeAMove(column))
            {
                UpdateLabelPlayerTurn();
                Renderer.DrawGrid(Game.getGameGridClone());
                return true;
            }
            return false;
        }

        public bool CheckGameEnd()
        {
            switch (Game.gameStatus.CheckGameStatus())
            {
                case GameEngine.enGameResult.GreenWin:
                    MessageBox.Show("Green Win", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                case GameEngine.enGameResult.RedWin:
                    MessageBox.Show("Red Win", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true; ;
                case GameEngine.enGameResult.Draw:
                    MessageBox.Show("Game Is Draw", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true; ;
                default:
                    return false;

            }
        }


    }

    public class BoardRenderer
    {
        private const short columns = 7;
        private const short rows = 6;

        private Pen _emptyPen = new Pen(Color.LightGray);
        private Brush _emptyBrush = new SolidBrush(Color.LightGray);

        private Pen _greenPen = new Pen(Color.Green);
        private Pen _redPen = new Pen(Color.Red);

        private Brush _greenBrush = new SolidBrush(Color.Green);
        private Brush _redBrush = new SolidBrush(Color.Red);

        private Panel _gamePanel;
        private Graphics _graphics;
        private enGrid[,] _LastDrawGrid;
        
        public BoardRenderer(Panel gamePanel,enGrid[,] gameGrid) 
        {
           _gamePanel = gamePanel;
           _graphics = gamePanel.CreateGraphics();
           _LastDrawGrid = gameGrid;
           _gamePanel.Paint += DrawGrid;

            DrawGrid(this, null);
        }

        private void DrawGridLogic(enGrid[,] GameGrid)
        {
            int spacing = 10;
            float circleDiameterX = (_gamePanel.Size.Width - spacing * columns) / columns;
            float circleDiameterY = (_gamePanel.Size.Height - spacing * rows) / rows;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    float x = spacing + col * (circleDiameterX + spacing);
                    float y = _gamePanel.Height - spacing - circleDiameterY
                        - (row) * (circleDiameterY + spacing);

                    switch (GameGrid[row, col])
                    {
                        case enGrid.empty:
                            DrawFilledCircle(_emptyBrush, _emptyPen, x, y, circleDiameterX, circleDiameterY);
                            break;
                        case enGrid.green:
                            DrawFilledCircle(_greenBrush, _greenPen, x, y, circleDiameterX, circleDiameterY);
                            break;
                        case enGrid.red:
                            DrawFilledCircle(_redBrush, _redPen, x, y, circleDiameterX, circleDiameterY);
                            break;
                    }
                }
            }
        }

        public void DrawGrid(object sender,PaintEventArgs e)
        {
            DrawGridLogic(_LastDrawGrid);
        }

        public void DrawGrid(enGrid[,] GameGrid)
        {
            DrawGridLogic(GameGrid);
            _LastDrawGrid = GameGrid;

        }

        private void DrawFilledCircle(Brush brush,Pen pen,float x,float y,float width,float height)
        {
            _graphics.FillEllipse(brush, x, y, width, height);
            _graphics.DrawEllipse(pen, x, y, width, height);
        }

    }

    public class GameEngine
    {
        public enum enGameResult
        {
            InProgress,
            GreenWin,
            RedWin,
            Draw
        }
        
        public class GameStatus
        {
            private bool _GreenWin = false;
            private bool _RedWin = false;
            private bool _Draw = false;
            public short PlayedMoves { get; private set; } = 0;

            public enGameResult gameResult;

            public void setRedWin()
            {
                _RedWin = true;
                gameResult = enGameResult.RedWin;
            }

            public void setGreenWin()
            {
                _GreenWin = true;
                gameResult = enGameResult.GreenWin;
            }

            public void setDraw()
            {
                _Draw = true;
                gameResult = enGameResult.Draw;
            }

            public void incrementMoves()
            {
                PlayedMoves++;
            }

            public enGameResult CheckGameStatus()
            {
                return gameResult;
            }

        }

        public GameStatus gameStatus;
        
        public enum enPlayerTurn { greenTurn = 1, redTurn = 2 };

        private enPlayerTurn playerTurn = enPlayerTurn.greenTurn;

        public enPlayerTurn getPlayerTurn()
        {
            return playerTurn;
        }

        private const byte columns = 7;
        private const byte rows = 6;
        

        private enGrid[,] _gameGrid; 

        public enGrid[,] getGameGridClone()
        {
            
            return (enGrid[,])_gameGrid.Clone();
        }

        public GameEngine()
        {
            _gameGrid = new enGrid[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    _gameGrid[row, col] = enGrid.empty;
                }
            }
            gameStatus = new GameStatus();

        }

        private int CountCirclesAround(int startRow, int startColumn, int stepRow, int stepColumn,enGrid player)
        {
           int count = 0;
           int currentRow = startRow + stepRow;
           int currentColumn = startColumn + stepColumn;

           while((currentRow >=0 && currentColumn >= 0)
                && (currentRow <= 5 && currentColumn<= 6))
            {
                if(_gameGrid[currentRow, currentColumn] == player)
                    { count++; }
                else { break; }
                currentRow = currentRow + stepRow;
                currentColumn = currentColumn + stepColumn;
            }
            return count;
        }

        private bool CheckVertically(int lastRow, int lastColumn,enGrid Player)
        {
            if (lastRow <= 2)
                return false;
            int verticalCircles = 1 + CountCirclesAround(lastRow, lastColumn, -1, 0, Player);

            if(verticalCircles < 4)
                return false;

            return true;
        }

        private bool CheckHorizantilly(int lastRow, int lastColumn, enGrid Player)
        {
            int horizanlCircles = 1 +
                CountCirclesAround(lastRow, lastColumn, 0, 1,Player) +
                CountCirclesAround(lastRow, lastColumn, 0, -1, Player);
            if (horizanlCircles < 4)
                return false;

            return true;
            
        }
        private bool CheckDiameter(int lastRow, int lastColumn, enGrid Player)
        {
            int LRDiameterCircles = 1 +
                CountCirclesAround(lastRow, lastColumn, 1, 1, Player) +
                CountCirclesAround(lastRow, lastColumn, -1, -1, Player);
            int RLDiameterCircles = 1 +
                CountCirclesAround(lastRow, lastColumn, -1, 1, Player)+
                CountCirclesAround(lastRow, lastColumn, 1, -1, Player);
            if (LRDiameterCircles < 4 && RLDiameterCircles < 4)
                return false;

            return true;

        }

        private void setPlayerWin(enGrid Player)
        {
            if (Player == enGrid.red)
                gameStatus.setRedWin();
            else if (Player == enGrid.green)
               gameStatus.setGreenWin();
        }

        private bool CheckForAWinnerOrDraw(int lastRow,int lastColumn)
        {
            enGrid currentPlayer = _gameGrid[lastRow,lastColumn];
            if (CheckVertically(lastRow, lastColumn, currentPlayer))
            {
                setPlayerWin(currentPlayer);
                return true;
            }

            if (CheckHorizantilly(lastRow, lastColumn, currentPlayer))
            {
                setPlayerWin(currentPlayer);
                return true;
            }

            if (CheckDiameter(lastRow, lastColumn, currentPlayer))
            {
                setPlayerWin(currentPlayer);
                return true;
            }


            if (gameStatus.PlayedMoves >= 42)
            {
                gameStatus.setDraw();
                return true;
            }

            return false;
        }

        public bool makeAMove(int column)
        {
            if(column < 0 || column >= columns) return false;

            for (int row =0; row< rows; row++)
            {
                if (_gameGrid[row,column] == enGrid.empty)
                {
                    _gameGrid[row, column] = (enGrid)playerTurn;

                    gameStatus.incrementMoves();

                    if (CheckForAWinnerOrDraw(row, column))
                        return true;

                    _ChangePlayerTurn();

                    return true;
                }
            }
            return false;
        }
  
        private void _ChangePlayerTurn()
        {
            if (playerTurn == enPlayerTurn.greenTurn)
                playerTurn = enPlayerTurn.redTurn;
            else
                playerTurn = enPlayerTurn.greenTurn;
        }
     
    }


}
