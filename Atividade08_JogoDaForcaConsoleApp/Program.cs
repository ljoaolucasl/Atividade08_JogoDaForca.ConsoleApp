
using System.Globalization;
using System.Linq;
using System.Security.Authentication;

namespace Atividade07.ConsoleApp
{
    internal class Program
    {
        static string palavraSecretaEscolhida;

        static void Main(string[] args)
        {
            char[] letrasPalavraSecreta;

            int contadorErro;

            bool continuaJogo, acerto, jogarNovamente;

            char[] historicoLetrasEscolhidas = new char[6];

            do
            {
                continuaJogo = true;
                contadorErro = 0;
                Array.Clear(historicoLetrasEscolhidas, 0, 6);

                GerarBemVindoDescricao();

                palavraSecretaEscolhida = GerarPalavraSecretaAleatoria();

                GerarForca();

                letrasPalavraSecreta = GerarTracosPalavraSecreta();

                while (continuaJogo)
                {
                    char letraEscolhida = CapturarLetraEscolhida();

                    acerto = AnalisarLetraAcertoOuErro(ref letrasPalavraSecreta, letraEscolhida);

                    CasoLetraAcertada(letrasPalavraSecreta, acerto, ref continuaJogo);

                    MostradorDeErros(contadorErro, acerto, historicoLetrasEscolhidas, letraEscolhida);

                    CasoLetraErrada(ref contadorErro, acerto, ref continuaJogo);
                }

                jogarNovamente = JogarNovamente();

            } while (jogarNovamente);
        }

        private static void GerarBemVindoDescricao()
        {
            Console.Clear();
            Console.WriteLine(" ╔══════════════════════════════════════╗");
            Console.WriteLine(" ║  * Bem-Vindo(a) ao Jogo Da Forca! *  ║");
            Console.WriteLine(" ╠══════════════════════════════════════╣");
            Console.WriteLine(" ║          * Nome de Frutas *          ║");
            Console.WriteLine(" ╚══════════════════════════════════════╝");
        }

        private static string GerarPalavraSecretaAleatoria()
        {
            Console.WriteLine();

            int numeroAleatorio;
            string[] palavrasSecretas = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA", "BACURI", "BANANA", "CAJÁ",
                "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA",
                "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };

            Random GerarNumeroAleatorio = new();

            numeroAleatorio = GerarNumeroAleatorio.Next(0, 29);

            return palavrasSecretas[numeroAleatorio];
        }

        private static void GerarForca()
        {
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
            Console.Write("  ╨ ");
        }

        private static char[] GerarTracosPalavraSecreta()
        {
            char[] letrasPalavraSecreta = new char[palavraSecretaEscolhida.Length];
            for (int i = 0; i < letrasPalavraSecreta.Length; i++)
            {
                letrasPalavraSecreta[i] = '_';
            }

            Console.WriteLine(string.Join(" ", letrasPalavraSecreta));
            return letrasPalavraSecreta;
        }

        private static char CapturarLetraEscolhida()
        {
            bool verificaLetras;
            bool verificaChar;
            bool verificaNumero;
            char letra;
            do
            {
                Console.SetCursorPosition(0, 21);
                Console.Write("\nEscolha uma letra: ");
                Console.SetCursorPosition(19, 22);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(19, 22);

                string entrada = Console.ReadLine().ToUpper();

                verificaChar = char.TryParse(entrada, out letra);

                verificaNumero = int.TryParse(entrada, out int numero);

                verificaLetras = entrada.All(char.IsLetter);

            } while (!verificaChar || verificaNumero || !verificaLetras);

            return letra;
        }

        private static bool AnalisarLetraAcertoOuErro(ref char[] letrasPalavraSecreta, char letraEscolhida)
        {
            bool acerto = false;
            for (int i = 0; i < palavraSecretaEscolhida.Length; i++)
            {
                if (String.Compare(Convert.ToString(palavraSecretaEscolhida[i]), Convert.ToString(letraEscolhida),
                    CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0)
                {
                    letrasPalavraSecreta[i] = palavraSecretaEscolhida[i];
                    acerto = true;
                }
            }

            return acerto;
        }

        private static void CasoLetraAcertada(char[] letrasPalavraSecreta, bool acerto, ref bool continuaJogo)
        {
            if (acerto)
            {
                Console.SetCursorPosition(4, 20);
                Console.WriteLine(string.Join(" ", letrasPalavraSecreta));

                string validarPalavra = new(letrasPalavraSecreta);

                if (validarPalavra == palavraSecretaEscolhida)
                {
                    Console.SetCursorPosition(0, 23);
                    MudarCorTexto(ConsoleColor.Green, "Parabéns! Você acertou!\n");
                    continuaJogo = false;
                    acerto = false;
                }
            }
        }

        private static void MostradorDeErros(int contadorErro, bool acerto, char[] historicoLetrasEscolhidas, char letraEscolhida)
        {
            if (!acerto)
            {
                historicoLetrasEscolhidas[contadorErro] = letraEscolhida;
                Console.SetCursorPosition(25, 6);
                Console.WriteLine(string.Join(" ", historicoLetrasEscolhidas));
                Console.SetCursorPosition(25, 8);
                Console.WriteLine($"{contadorErro + 1}/5");
            }
        }

        private static void CasoLetraErrada(ref int contadorErro, bool acerto, ref bool continuaJogo)
        {
            if (!acerto)
            {
                contadorErro++;

                switch (contadorErro)
                {
                    case 1: Console.SetCursorPosition(0, 9); Console.WriteLine("  ║                 O"); break;
                    case 2: Console.SetCursorPosition(0, 10); Console.WriteLine("  ║                 x"); break;
                    case 3: Console.SetCursorPosition(0, 10); Console.WriteLine("  ║                 x\\"); break;
                    case 4: Console.SetCursorPosition(0, 10); Console.WriteLine("  ║                /x\\"); break;
                    case 5:
                        Console.SetCursorPosition(0, 11); Console.WriteLine("  ║                / \\");
                        continuaJogo = false;
                        Console.SetCursorPosition(0, 23);
                        MudarCorTexto(ConsoleColor.Red, "Você perdeu, a palavra secreta era ");
                        Console.WriteLine($"\"{palavraSecretaEscolhida}\"");
                        break;
                }
            }
        }

        private static bool JogarNovamente()
        {
            string resposta;
            bool jogarNovamente;

            Console.WriteLine("Quer Jogar Novamente? (S/N)");

            do
            {
                Console.SetCursorPosition(0, 25);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, 25);
                resposta = Console.ReadLine().ToUpper();

            } while (resposta != "S" && resposta != "N");

            if (resposta == "S") { jogarNovamente = true; }
            else { jogarNovamente = false; Console.WriteLine("\nFinalizando Aplicação . . ."); }

            return jogarNovamente;
        }

        private static void MudarCorTexto(ConsoleColor cor, string mensagem)
        {
            Console.ForegroundColor = cor;
            Console.Write(mensagem);
            Console.ResetColor();
        }
    }
}