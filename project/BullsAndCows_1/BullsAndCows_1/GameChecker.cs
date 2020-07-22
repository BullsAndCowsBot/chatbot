using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows_1
{
	public class GameChecker
    {
        public int GameMode { get; set; } = 0; // 1: 일반 모드, 2: 무한 모드

        public string ComputerNumber { get; set; } = "";

        public int LeftTurn { get; set; } = 0; // 일반 모드인 경우만 9
    }
}
