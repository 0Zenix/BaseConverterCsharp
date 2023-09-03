using System.Linq;
using System.Runtime.CompilerServices;

namespace BaseConverter
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Entrar Número: ");
            string input = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Entrar Número: ");
            int target_base = int.Parse(Console.ReadLine());
        }

        static string AnyToDec(String input)
        {
            String number = ReverseString(input.ToUpper());

            int original_base = GetBase(number);

            int acc = 0;
            for (int i = 0; i < number.Length; i++)
            {
                acc += Convert.ToInt32(Math.Pow(original_base, i)) * CharToNumber(number[i]);
            }

            return Convert.ToString(acc);
        }

        static string DecToAny(String input, int target_base)
        {
            int num = int.Parse(input);

            int resto;
            string results = string.Empty;
            while (num > 0)
            {
                resto = num % target_base;
                num /= target_base;
                results = NumberToChar(resto) + results;
            }

            return new string((results).ToArray());
        }

        static string AnyToAny(string input, int target_base)
        {
            string inDecimal = AnyToDec(input);

            if ( GetBase(input) == 10 )
            {
                return inDecimal;
            } else 
            {
                return DecToAny(inDecimal, target_base);
            }

        }

        static int CharToNumber(char input)
        {
            int result = (int)input-55;

            if ((int)input < 65)
            {
                result += 7;
            }

            return result;
        }

        static char NumberToChar(int input)
        {
            int result = input+48;

            if (input >= 10)
            {
                result += 7;
            }

            return Convert.ToChar(result);
        }

        static int GetBase(String input_string)
        {
            int largest_yet = 0;

            for (int i = 0; i < input_string.Length; i++)
            {
                int num = CharToNumber(input_string[i]);

                if ( num > largest_yet )
                {
                    largest_yet = num;
                }
            }

            return largest_yet+1;
        }

        static string ReverseString(string text)
        {
            return new string(text.Reverse().ToArray());
        }
    }
}