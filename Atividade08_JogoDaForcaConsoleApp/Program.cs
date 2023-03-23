
using System.Linq;

namespace Atividade07.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tracosForca;
            char[] letrasPalavraSecreta;
            string[] palavrasSecretas = { "ABACATE", "ABACAXI", "ACEROLA" };
            string palavraSecretaEscolhida;
            int posicaoLetraAcertada;
            int contadorErro = 0;

            palavraSecretaEscolhida = palavrasSecretas[0];

            tracosForca = new string[palavraSecretaEscolhida.Length];

            for (int i = 0; i < tracosForca.Length; i++)
            {
                tracosForca[i] = "_";
            }

            letrasPalavraSecreta = palavraSecretaEscolhida.ToCharArray();

            Console.WriteLine("  ╔╦═════════════════");
            Console.WriteLine("  ╠╝                │");
            Console.WriteLine("  ║                 │");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.WriteLine("  ║");
            Console.Write("  ╨");
            Console.WriteLine(string.Join(" ", tracosForca));

            while (true)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write("\nEscolha uma letra: ");
                Console.SetCursorPosition(19, 16);
                
                string letraEscolhida = Console.ReadLine();

                posicaoLetraAcertada = Array.FindIndex(letrasPalavraSecreta, letra => letra == Convert.ToChar(letraEscolhida));

                if (posicaoLetraAcertada != -1)
                {
                    tracosForca[posicaoLetraAcertada] = letraEscolhida;
                    Console.SetCursorPosition(3, 14);
                    Console.WriteLine(string.Join(" ", tracosForca));
                }
                else
                {
                    contadorErro++;

                    switch (contadorErro)
                    {
                        case 1: Console.SetCursorPosition(0, 3); Console.WriteLine("  ║                 O"); break;
                        case 2: Console.SetCursorPosition(0, 4); Console.WriteLine("  ║                 x"); break;
                        case 3: Console.SetCursorPosition(0, 4); Console.WriteLine("  ║                ╱x╲"); break;
                        case 4: Console.SetCursorPosition(0, 5); Console.WriteLine("  ║                ╱ "); break;
                        case 5: Console.SetCursorPosition(0, 5); Console.WriteLine("  ║                ╱ ╲"); break;
                    }
                }
            }
        }
    }
}