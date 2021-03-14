using System;
using System.Linq;

namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {

            string ticketNumber;
            int sum1 = 0;
            int sum2 = 0;

            while (true)
            {
                ticketNumber = Console.ReadLine();
                if (ticketNumber.Length < 4 || ticketNumber.Length > 8)
                {
                    Console.WriteLine("Кол-во чисел должно быть от 4 до 8");
                }
                else
                {
                    break;
                }
            }
            int[] ticketDigits = new int[ticketNumber.Length];
            for (int i = 0; i < ticketDigits.Length; i++)
            {
                ticketDigits[i] = Convert.ToInt32(Char.GetNumericValue(ticketNumber[i]));
            }

            if ((ticketDigits.Length % 2) != 0)
            {
                ticketDigits = Insert(ticketDigits);
                Console.WriteLine(ticketDigits.Length);
            }

            for (int i = 0; i < ticketDigits.Length / 2; i++)
            {
                int[] ms1 = new int[ticketDigits.Length / 2];
                int[] ms2 = new int[ticketDigits.Length / 2];
                ms1[i] = ticketDigits[i];
                ms2[i] = ticketDigits[i + ticketDigits.Length / 2];
                sum1 += ms1[i];
                sum2 += ms2[i];
            }

            if (sum1 == sum2)
            {
                Console.WriteLine("YOU ARE LUCKY!");
            }
            else
            {
                Console.WriteLine("YOU ARE NOT LUCKY!");
            }

            Console.ReadLine();
        }

        static int[] Insert(int[] array)
        {
            int[] result = new int[array.Length + 1];
            result[0] = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result[i + 1] = array[i];
            }
            return result;
        }
    }
}
