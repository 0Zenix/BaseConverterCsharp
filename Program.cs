using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace BaseConverter
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();

            bool exit = false;

            while(!exit)
            {
                Console.Write("\nInforme o número: ");
                var input = Console.ReadLine();
                Console.Write("\n");

                Console.Write("Informe a base: ");
                var original_base = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                Console.Write("Informe a base alvo: ");
                var target_base = Convert.ToInt32(Console.ReadLine());


                while (!CheckInput(input, original_base)) 
                {
                    Console.Clear();

                    Console.Write($"Informe uma base válida para o número {input}");
                    original_base = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                }
                
                Console.Clear();

                var result = AnyToAny(input, original_base, target_base);
                Console.WriteLine($"Número: {input} Base: {original_base} \nBase Alvo: {target_base} Número Alvo: {result} \n Pressione qualquer tecla para continuar ↵");

                Console.ReadKey();
                Console.Clear();

                Console.Write("Entre sair pra 'sair' da aplição, digite 'cont' para continuar ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "sair")
                {
                    exit = true;
                }
            }

            Console.Clear();
            Console.WriteLine("Saindo do programa. Presiona qualquer tecla.");
            Console.ReadKey();
        }

        static bool CheckInput(string? input, int original_base)
        {
            string pattern = @"^(0?[0-9]|10|[A-Z])$";
        
            if(Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
            {
                return GetBase(input) <= original_base;
            } else {
                return false;
            }
        }

        static string AnyToDec(string? input, int original_base)
        {
            String number = ReverseString(input.ToUpper());

            int acc = 0;
            for (int i = 0; i < number.Length; i++)
            {
                acc += Convert.ToInt32(Math.Pow(original_base, i)) * CharToNumber(number[i]);
            }

            return Convert.ToString(acc);
        }

        static string DecToAny(string? input, int target_base)
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

        static string AnyToAny(string? input, int original_base, int target_base)
        {
            string inDecimal = AnyToDec(input, original_base);

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

        static int GetBase(String? input_string)
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