using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        public Board Board { get; set; }

        public Player player1 { get; set; }
        public Player player2 { get; set; }

        private int steps = 0;

        public Action OnComputerDidTurn;
        public Action<Player> OnWinning;

        public bool IsGameOver => Board.Cells.All(x => x.resolved);

        public Game(int boardHeight, int boardWidth, string? player1, string? player2)
        {
            Board = new Board(boardHeight * boardWidth);

            this.player1 = player1 != null ? new Player(player1) : new CompuerPlayer("Computer", this);
            this.player2 = player2 != null ? new Player(player2) : new CompuerPlayer("Computer2", this);
        }

        public Cell GetCell(int index)
        {
            return this.Board.Cells.ElementAt(index);
        }

        public int BoardSize()
        {
            return Board.Cells.Count();
        }

        public void PlayTurn(int index)
        {
            var currentPlayer = GetCurrentPlayer();

            var score = Board.PlayTurn(index);
            if(score == 1)
            {
                currentPlayer.Score++;
                this.Board.firstSelection.owner = currentPlayer;
                this.Board.secondSelection.owner = currentPlayer;
            }
            steps++;

            OnComputerDidTurn?.Invoke();
            
            
            if(IsGameOver)
            {
                OnWinning(player1.Score > player2.Score ? player1 : player2);
            }
        }

        public Player GetCurrentPlayer()
        {
            return ((((steps + this.player1.Score * 2 + this.player2.Score * 2) / 2) % 2) == 0) ? player1: player2;
        }

        public Player GetLastPlayingPlayer()
        {
            return ((((steps - (steps % 2 == 1 ? 0 : 1) + this.player1.Score * 2 + this.player2.Score * 2) / 2) % 2) == 0) ? player1 : player2;
        }
    }
}
