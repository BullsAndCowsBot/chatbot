using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCows_1
{
	public class Player
    {
        private string number;

        public Player()
        {
            this.number = makeRandom();
        }

        public Player(string number)
        {
            this.number = number;
        }

        public string makeRandom()
        {
            Random r = new Random();

            string input = "";

            while (true)
            {
                input = $"{r.Next(0, 10)}{r.Next(0, 10)}{r.Next(0, 10)}";
                if (CheckDuplicate(input))
                {
                    break;
                }
            }

            return input;
        }

        public string getNumber()
        {
            return number;
        }

        public bool CheckDuplicate(string input)
        {
            // 중복이 있는지 검사, input은 3자리는 조건
            bool condition1 = input.IndexOf(input.Substring(0, 1), 1) == -1; // 0번째 문자와 1 ~ 2 검사
            bool condition2 = input.IndexOf(input.Substring(2, 1), 0, 2) == -1; // 2번째 문자와 0 ~ 1 검사

            return condition1 && condition2;
        }

        public bool CheckIntegrity(string answer)
        {
            // 3자리 검사
            if (answer.Length != 3)
            {
                return false;
            }

            // 숫자인지 검사
            try
            {
                int result = Int32.Parse(answer);
            }
            catch (FormatException)
            {
                return false;
            }

            return CheckDuplicate(answer);
        }

        public string CheckNumber(string answer)
        {
            int s_count = 0;
            int b_count = 0;
            int o_count = 0;

            bool out_flag = true;

            string result = "";

            for (int i = 0; i < 3; i++)
            {
                string temp = answer.Substring(i, 1);
                for (int j = 0; j < 3; j++)
                {
                    if (this.number.Substring(j, 1) == temp)
                    {
                        if (i == j) { s_count += 1; }
                        else { b_count += 1; }
                        out_flag = false;
                    }
                }
                if (out_flag) { o_count += 1; }
                out_flag = true;
            }

            if (s_count == 3) { result = "YOU WIN"; }
            else { result = $"[{s_count} S] [{b_count} B]  [{o_count} O]"; }

            return result;
        }
    }
}
