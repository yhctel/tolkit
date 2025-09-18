using System;
using System.Linq;

namespace Trabalho.Itens
{
    public static class Aula01
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Verificação de Símbolo e Cadeia ===\n");

            Console.Write("Digite o seu alfabeto: ");
            string alfabeto = Console.ReadLine()?.ToLower() ?? "";

            Console.Write("\nDigite um símbolo para verificar: ");
            string inputSimbolo = Console.ReadLine()?.ToLower() ?? "";

            if (inputSimbolo.Length != 1)
            {
                Console.WriteLine("Entrada inválida! Digite apenas um símbolo.");
            }
            else
            {
                char simbolo = inputSimbolo[0];
                if (alfabeto.Contains(simbolo))
                    Console.WriteLine($"\nO símbolo '{simbolo}' é válido no alfabeto.");
                else
                    Console.WriteLine($"\nO símbolo '{simbolo}' NÃO faz parte do alfabeto.");
            }

            Console.Write("\nDigite uma cadeia para verificar: ");
            string cadeia = Console.ReadLine()?.ToLower() ?? "";

            var letrasInvalidas = cadeia.Where(c => !alfabeto.Contains(c)).Distinct().ToArray();

            if (letrasInvalidas.Length > 0)
            {
                Console.WriteLine("\nA cadeia contém símbolos que NÃO fazem parte do alfabeto:");
                Console.WriteLine(string.Join(", ", letrasInvalidas));
            }
            else
            {
                Console.WriteLine("\nTodos os símbolos da cadeia são válidos no alfabeto.");
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
