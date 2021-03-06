using System;

namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string ticketNumber = valueInput();
                string verifiedTicket = CheckNumberDigits(ticketNumber);
                LuckyTicketCheck(verifiedTicket);

                Console.WriteLine("Проверить еще один билет? Y/N");

            } while (Console.ReadLine().ToUpper() == "Y");
        }

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        static string valueInput()
        {
            Console.WriteLine("Введите номер билета:");
            string ticketNumber = Console.ReadLine();
            if (!IsDigitsOnly(ticketNumber))
            {
                Console.WriteLine("Строка должна содержать только числа!");
                ticketNumber = valueInput();
            }
            return ticketNumber;
        }

        static string CheckNumberDigits (string ticketNumber) 
        {
                if (ticketNumber.Length < 4 || ticketNumber.Length > 8)
                {
                    Console.WriteLine("Кол-во чисел должно быть от 4 до 8");
                    ticketNumber = valueInput();
                }
                 return ticketNumber;
        }

        static void LuckyTicketCheck (string verifiedTicket) 
        {
            int sum1 = 0;
            int sum2 = 0;
            int[] ticketDigits = new int[verifiedTicket.Length];

            for (int i = 0; i < ticketDigits.Length; i++)
            {
                ticketDigits[i] = Convert.ToInt32(Char.GetNumericValue(verifiedTicket[i]));
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
