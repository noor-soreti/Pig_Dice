using System;
namespace Pig.Models
{
	public class Game
	{
        public Game()
        {
            _NewGame();
        }

        public void _NewGame()
        {
            Player player1 = new Player { Name = "Player1" };
            Player player2 = new Player { Name = "Player2" };
            LastRoll = 0;
            CurrentPlayerName = player1.Name;
            CurrentTurnScore = player1.Score;
        }

        public const int WinningNumber = 20;

        public Player player1 { get; set; }

        public Player player2 { get; set; }

        public int LastRoll { get; set; }

        public string CurrentPlayerName { get; set; }

        public int CurrentTurnScore { get; set; }

        public bool IsGameOver { get; set; }

        public void Roll()
        {
            Random random = new Random();
            LastRoll = random.Next(1, 7);

            if (LastRoll == 1)
            {
                CurrentTurnScore = 0;
                ChangePlayer(); 
            } else
            {
                CurrentTurnScore += LastRoll;
            }
        }

        public void Hold()
        {
            Player current = (CurrentPlayerName == player1.Name) ? player2 : player1;
            current.Score = CurrentTurnScore;

            if (CurrentTurnScore >= WinningNumber)
            {
                IsGameOver = true;
            } else
            {
                CurrentTurnScore = LastRoll = 0;
                ChangePlayer();
            }
            
        }

        public void ChangePlayer()
        {
            CurrentPlayerName = (CurrentPlayerName == player1.Name) ? player2.Name : player1.Name;
        }

    }
}

