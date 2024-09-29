using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGame
{
    internal struct GameDifficulty
    {
        public Difficulty difficulty { set; get; }
        public string label { set; get; }
        public int fieldSize { set; get; }
        public bool Equals(GameDifficulty gd) => difficulty == gd.difficulty;
        public static bool operator ==(GameDifficulty first, GameDifficulty second) => first.difficulty == second.difficulty;
        public static bool operator !=(GameDifficulty first, GameDifficulty second) => first.difficulty != second.difficulty;
    }

    enum Difficulty
    {
        easy,
        medium,
        hard
    }
}
