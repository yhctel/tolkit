using System;

namespace Trabalho.Itens
{
    public static class Aula03
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Decisor: Termina com 'b'? ===\n");

            Console.Write("Digite uma palavra: ");
            string palavra = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(palavra))
            {
                Console.WriteLine("\nA palavra está vazia. Não é possível verificar.");
            }
            else if (palavra.EndsWith('b'))
            {
                Console.WriteLine("\nSIM, a palavra termina com 'b'.");
            }
            else
            {
                Console.WriteLine("\nNÃO, a palavra não termina com 'b'.");
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
