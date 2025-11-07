using System;
using System.Linq;

namespace Trabalho.Itens
{
    public static class Aula05
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Reconhecedor de Linguagens Simples ===");

            Console.WriteLine("\nEscolha a linguagem para reconhecer:");
            Console.WriteLine("1 - L_par_a (palavras com número par de 'a')");
            Console.WriteLine("2 - L = { w | w = a b* }");

            int opcao = LerOpcao(1, 2);

            Console.Write("\nDigite uma palavra sobre o alfabeto {a,b}: ");
            string palavra = Console.ReadLine() ?? "";

            if (!palavra.All(c => c == 'a' || c == 'b'))
            {
                Console.WriteLine("\nPalavra inválida: contém símbolos fora do alfabeto {a,b}.");
            }
            else
            {
                bool aceita = false;

                switch (opcao)
                {
                    case 1: // L_par_a
                        int qtdA = palavra.Count(c => c == 'a');
                        aceita = qtdA % 2 == 0;
                        break;

                    case 2: // a b*
                        aceita = palavra.Length > 0 && palavra[0] == 'a' && palavra.Skip(1).All(c => c == 'b');
                        break;
                }

                Console.WriteLine(aceita ? "\nACEITA" : "\nREJEITA");
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }

        private static int LerOpcao(int min, int max)
        {
            while (true)
            {
                Console.Write("\nOpção: ");
                string? entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int valor) && valor >= min && valor <= max)
                    return valor;
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}
