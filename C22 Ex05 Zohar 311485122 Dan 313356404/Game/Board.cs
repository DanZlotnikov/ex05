namespace Game
{
    public class Board
    {
        public List<Cell> Cells;

        internal Cell firstSelection;
        internal Cell secondSelection;

        bool isFirstSelection = true;

        public Board(int boardSize)
        {
            var random = new Random();
            Cells = new int[boardSize / 2].SelectMany((x, index) =>
             {
                 return new Cell[] { new Cell(index), new Cell(index)};
             })
                .OrderBy((x) => random.NextDouble() - 0.5).ToList();
        }

        public int PlayTurn(int index)
        {
            var score = 0;

            if (isFirstSelection)
            {
                if(firstSelection != null)
                {
                    firstSelection.revelad = firstSelection.resolved;
                }
                if(secondSelection != null)
                {
                    secondSelection.revelad = secondSelection.resolved;
                }
                
                firstSelection = Cells.ElementAt(index);

                firstSelection.revelad = true;
                isFirstSelection = false;
            }
            else
            {
                secondSelection = Cells.ElementAt(index);

                secondSelection.revelad = true;
                if(secondSelection.value == (firstSelection?.value ?? -1))
                {
                    secondSelection.resolved = true;
                    if(firstSelection != null)
                    {
                        firstSelection.resolved = true;
                    }
                    score = 1;

                }
                isFirstSelection = true;
            }

            return score;
        }

    }
}