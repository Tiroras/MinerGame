using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGame
{
    static class AppData
    {
        static GameDifficulty easyDifficulty = new GameDifficulty { difficulty = Difficulty.easy, label = "Легкая", fieldSize = 10 };
        static GameDifficulty mediumDifficulty = new GameDifficulty { difficulty = Difficulty.medium, label = "Средняя", fieldSize = 18 };
        static GameDifficulty hardDifficulty = new GameDifficulty { difficulty = Difficulty.hard, label="Сложная", fieldSize=24 };

        public static GameDifficulty currentDifficulty = easyDifficulty;

        public static GameDifficulty[] gameDifficulties = new GameDifficulty[3] { easyDifficulty, mediumDifficulty, hardDifficulty };
    }
}
