namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private readonly ScoreRuleChain _scoreRuleChain;
        private readonly GameState _gameState;

        public TennisGame1(string player1Name, string player2Name)
        {
            _gameState = new GameState(player1Name, player2Name);

            _scoreRuleChain = new ScoreRuleChain(new IScoreRule[]
            {
                new ScoreRuleEven(),
                new ScoreRuleAdvantage(),
                new ScoreRuleWin(),
                new ScoreRuleNormal()
            });
        }

        public void WonPoint(string playerName)
        {
            var currentPlayer = _gameState.FindPlayerByName(playerName);

            currentPlayer.WonPoint();
        }


        public string GetScore()
        {
            return _scoreRuleChain.Evaluate(_gameState.Player1, _gameState.Player2);
        }
    }
}

