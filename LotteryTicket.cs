using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //使用者輸入：請使用者輸入6個數，其值並介於1~49，並以逗點隔開 ( 要做防呆，如果輸入範圍錯誤，或不是六個數，則要求使用者重新輸入)
        //(done)電腦產生樂透值：產生六個不重複的亂數，並介於1 ~49
        //輸出：使用者輸入的值、電腦輸入的值、猜對的數有幾個、猜對的數字有哪些。
        static void Main(string[] args)
        {
            int[] play_list = new int[0];                        //enter 6 numbers

            bool isOK = false;
            while (!isOK)
            {
                Console.Write("Please enter six numbers:");
                isOK = GuessNum(Console.ReadLine(), ref play_list);
            }

            int[] lotto;
            Gener_lotto(out lotto);                             //generate 6 number without repeat
            int[] result = ComparerNum(play_list, lotto);       //compare each number
            PrintResult(lotto, result);                         //print the result of the lotto



            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        /// <summary>
        /// Print the result of the lotto
        /// </summary>
        /// <param name="lotto"></param>
        /// <param name="array"></param>
        private static void PrintResult(int[] lotto, int[] array)
        {
            Array.Sort(lotto);
            Console.Write("彩號為：");
            for (int i = 0; i < lotto.Length; i++)
            {
                Console.Write($"{lotto[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                int counter = 0;
                if (counter == 0)
                {
                    Console.Write("猜對的數字為:");
                }
                Console.WriteLine(array[i]);
                counter++;
            }
            Console.WriteLine($"\n總共猜對{array.Length}個");

        }

        private static int[] ComparerNum(int[] play_list, int[] lotto)
        {
            int[] com = new int[0];
            int counter = 0;
            for (int i = 0; i < play_list.Length; i++)
            {
                for (int j = 0; j < lotto.Length; j++)
                {
                    if (play_list[i] == lotto[j])
                    {
                        Array.Resize(ref com, com.Length + 1);
                        com[counter++] = play_list[i];
                    }
                }
            }
            return com;
        }

        /// <summary>
        /// enter six number
        /// </summary>
        /// <returns></returns>
        private static bool GuessNum(string str, ref int[] array)
        {
            //防呆順序：切字串、個數、TryParse、範圍
            string[] play_guess_list = str.Split(',');

            if (play_guess_list.Length != 6)
            {
                Console.Write("Enter gain!");
                return false;
            }
            array = new int[6];
            for (int i = 0; i < array.Length; i++)
            {
                play_guess_list[i] = play_guess_list[i].Trim();
                array[i] = CheckInt(play_guess_list[i]);
                if (array[i] > 49 || array[i] < 1)
                {
                    Console.Write("Enter gain!");
                    return false;
                }
            }
            return true;
        }
        public static int CheckInt(string str)
        {
            int num;
            if (int.TryParse(str, out num))
            {
                return num;
            }
            return -1;
        }

        /// <summary>
        /// check if number is repeat
        /// </summary>
        /// <param name="arr"></param>
        private static void Gener_lotto(out int[] arr)
        {
            Random rnd = new Random();
            arr = new int[6];
            arr[0] = 0;
            int counter = 0;

            while (counter < arr.Length)
            {
                int find = 0;
                int input = rnd.Next(1, 50);
                for (int i = 0; i < counter + 1; i++)
                {
                    if (arr[i] == input)
                    {
                        find++;
                    }
                }
                if (find == 0)
                {
                    arr[counter] = input;
                    counter++;
                }
            }
        }
    }
}
