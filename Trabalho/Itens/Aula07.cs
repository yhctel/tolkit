using System;
using System.Linq;

namespace Trabalho.Itens
{
    public static class Aula07
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Item 2 da AV2: Decisores Adicionais sobre Σ={a,b} ===\n");

            Console.WriteLine("1) Decisor para L = {w | w termina com 'b'}");
            Console.WriteLine("2) Decisor para L = {w | w possui um número de 'b's múltiplo de 3}");
            Console.Write("\nEscolha uma opção: ");

            string? escolha = Console.ReadLine();
            Console.Clear();

            switch (escolha)
            {
                case "1":
                    DecisorTerminaComB();
                    break;
                case "2":
                    DecisorMultiploDe3B();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }
        private static void DecisorTerminaComB()
        {
            Console.WriteLine("--- Decisor: A cadeia termina com 'b'? ---\n");
            string cadeia;

            // Loop de validação: continua pedindo a entrada até que a cadeia seja válida
            while (true)
            {
                Console.Write("Digite uma cadeia sobre o alfabeto {a, b}: ");
                cadeia = Console.ReadLine()?.ToLower() ?? "";

                if (CadeiaEhValida(cadeia))
                {
                    break; // Sai do loop se a entrada for válida
                }
                else
                {
                    Console.WriteLine("\nERRO: A cadeia contém símbolos que não pertencem ao alfabeto {a, b}. Tente novamente.\n");
                }
            }

            if (!string.IsNullOrEmpty(cadeia) && cadeia.EndsWith('b'))
            {
                Console.WriteLine("\nReposta: SIM, termina com b!");
            }
            else
            {
                Console.WriteLine("\nResposta: NÃO termina com b!");
            }
        }
        private static void DecisorMultiploDe3B()
        {
            Console.WriteLine("--- Decisor: O número de 'b's é múltiplo de 3? ---\n");
            string cadeia;

            while (true)
            {
                Console.Write("Digite uma cadeia sobre o alfabeto {a, b}: ");
                cadeia = Console.ReadLine()?.ToLower() ?? "";

                if (CadeiaEhValida(cadeia))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nERRO: A cadeia contém símbolos que não pertencem ao alfabeto {a, b}. Tente novamente.\n");
                }
            }

            // Conta as ocorrências do caractere 'b' na cadeia
            int contagemB = cadeia.Count(c => c == 'b');

            // Verifica se a contagem é maior que zero e se o resto da divisão por 3 é 0
            if (contagemB > 0 && contagemB % 3 == 0)
            {
                Console.WriteLine("\nResposta: SIM, a quantidade de b nessa cadeia é múltipla de 3!");
            }
            else
            {
                Console.WriteLine("\nResposta: NÃO, a quantidade de b nessa cadeia não é múltipla de 3!");
            }
        }

        // Verifica se todos os caracteres da cadeia pertencem ao alfabeto {a, b}
        private static bool CadeiaEhValida(string cadeia)
        {
            return cadeia.All(c => c == 'a' || c == 'b');
        }
    }
}