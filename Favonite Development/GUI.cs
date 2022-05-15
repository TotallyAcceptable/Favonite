using System;
using System.Collections.Generic;
using System.Text;

namespace Favonite_Development
{
    public class GUI
    {
        private int score;
        private int playerhp;
        private int lives;
        private int gameLevel;
        private int levelUpgrade;

        public void Initialize(int Score, int HP, int Lives, int Level)
        {
            score = Score;
            playerhp = HP;
            lives = Lives;
            gameLevel = Level;
            levelUpgrade = 100;

        }

        public int SCORE
        {
            get { return score; }
            set { this.score = value; }
        }
            
        public int PLAYERHP
        {
            get { return playerhp; }
            set { this.playerhp = value; }
        }

        public int LIVES
        {
            get { return lives; }
            set { this.lives = value; }
        }

        public int LEVEL
        {
            get { return gameLevel; }
            set { this.gameLevel = value; }
        }

        public int LEVELUPGRADE
        {
            get { return levelUpgrade; }
            set { this.levelUpgrade = value; }
        }

    }
}
