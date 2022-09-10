using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CompuerPlayer : Player
    {
        public Game Game;
        public CompuerPlayer(string name, Game game) : base(name)
        {
            Game = game;
        }

        public async Task DoTurn()
        {
            var random = new Random();
            await Task.Delay(1000);
            var index = Game.Board.Cells.IndexOf(
                Game.Board.Cells.Where(x => !x.revelad).OrderBy(x => random.NextDouble() - 0.5).First());
            Game.PlayTurn(index);
        }
    }
}
