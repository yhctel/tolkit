using System;
using System.Linq;
using System.Threading;

namespace Trabalho.Itens
{
    public static class Aula08
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Reconhecedor que Pode Não Terminar ===\n");

            Console.WriteLine("Este reconhecedor tenta identificar a linguagem L = {w | w começa com 'a' e é seguido por pelo menos um 'b'}.");
            Console.WriteLine("Ele foi implementado de forma que entrará em loop se a cadeia chegar ao fim e não houver um 'b'.\n");

            string cadeia;

            while (true)
            {
                Console.Write("Digite uma cadeia sobre o alfabeto {a, b}: ");
                cadeia = Console.ReadLine()?.ToLower() ?? "";
                if (cadeia.All(c => c == 'a' || c == 'b'))
                {
                    break;
                }
                Console.WriteLine("\nERRO: A cadeia contém símbolos inválidos. Tente novamente.\n");
            }

            int maxPassos;
            while (true)
            {
                Console.Write("\nDigite o número máximo de passos para a execução (ex: 1000): ");
                if (int.TryParse(Console.ReadLine(), out maxPassos) && maxPassos > 0)
                {
                    break;
                }
                Console.WriteLine("Valor inválido. Por favor, digite um número inteiro positivo.");
            }

            Reconhecer(cadeia, maxPassos);

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }
        private static void Reconhecer(string cadeia, int maxPassos)
        {
            Console.Clear();
            Console.WriteLine("Sua cadeia é: (" + cadeia + ")");
            Console.WriteLine("\n--- Iniciando reconhecimento ---");
            Thread.Sleep(1500);

            // condição inicial da linguagem: a cadeia deve começar com a
            if (string.IsNullOrEmpty(cadeia) || cadeia[0] != 'a')
            {
                Console.WriteLine("REJEITA (a cadeia não começa com 'a').");
                return;
            }

            int passos = 0;
            int indice = 0;
            bool pularAnimacao = false;

            while (passos < maxPassos)
            {
                passos++;

                Console.WriteLine($"Passo {passos}: Verificando índice {indice}...");

                if (indice < cadeia.Length)
                {
                    // Condição de aceitação: encontrou o símbolo b
                    if (cadeia[indice] == 'b')
                    {
                        Console.WriteLine($"\nSucesso! Símbolo 'b' encontrado na posição {indice}.");
                        Console.WriteLine("ACEITA");
                        return; // Encerra a execução com sucesso
                    }
                    else
                    {
                        indice++;
                    }
                }
                else
                {
                    // Condição de rejeição: chegou ao fim da cadeia sem encontrar b
                    Console.WriteLine("\nTodos os símbolos da cadeia foram verificados.");
                    Console.WriteLine("Nenhum 'b' foi encontrado após o 'a' inicial.");
                    Console.WriteLine("REJEITA");
                    return;
                }

                // permite pular a animação para ver o resultado final
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    pularAnimacao = true;
                    Console.WriteLine("\n[Animação pulada! Finalizando rapidamente...]\n");
                }
                if (!pularAnimacao)
                {
                    Thread.Sleep(100);
                }
            }

            Console.WriteLine($"\n!!! EXECUÇÃO INTERROMPIDA !!!");
            Console.WriteLine($"O limite de {maxPassos} passos foi atingido antes de uma conclusão.");
            Console.WriteLine("Isso pode indicar um laço infinito no reconhecedor.");
        }
    }
}