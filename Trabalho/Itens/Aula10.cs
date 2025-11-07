using System;
using System.Linq;
using System.Threading;

namespace Trabalho.Itens
{
    public static class Aula10
    {
        // --- Definição do Autômato Finito Determinístico (AFD) ---
        //
        // Objetivo: Reconhecer a linguagem L = {w | w contém a substring "ab"}
        //
        // 1. Alfabeto (Σ): {a, b}
        //
        // 2. Estados (Q): {q0, q1, q2}
        //    - q0: Estado inicial. Nenhum 'a' promissor foi visto ainda.
        //    - q1: Um 'a' foi visto. Se o próximo símbolo for 'b', a cadeia será aceita.
        //    - q2: A substring "ab" foi encontrada. É um estado final e "sem saída" (aceita para sempre).
        //
        // 3. Estado Inicial: q0
        //
        // 4. Estados Finais (F): {q2}
        //
        // 5. Função de Transição (δ):
        //    - δ(q0, a) -> q1
        //    - δ(q0, b) -> q0
        //    - δ(q1, a) -> q1
        //    - δ(q1, b) -> q2
        //    - δ(q2, a) -> q2
        //    - δ(q2, b) -> q2
        //
        // --- Fim da Definição ---

        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Simulador de AFD de Casos Fixos ===\n");

            Console.WriteLine("Este simulador executa um AFD pré-definido que reconhece");
            Console.WriteLine("qualquer cadeia sobre {a,b} que contenha a substring 'ab'.\n");
            Console.WriteLine("Definição do AFD:");
            Console.WriteLine("  Estados: {q0, q1, q2} | Inicial: q0 | Finais: {q2}\n");

            string cadeia;
            while (true)
            {
                Console.Write("Digite a cadeia de entrada: ");
                cadeia = Console.ReadLine()?.ToLower() ?? "";
                if (CadeiaEhValida(cadeia))
                {
                    break;
                }
                Console.WriteLine("\nERRO: A cadeia contém símbolos que não pertencem ao alfabeto {a, b}. Tente novamente.\n");
            }

            SimularAFD(cadeia);

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void SimularAFD(string cadeia)
        {
            // O estado inicial do AFD é sempre q0.
            string estadoAtual = "q0";
            Console.Clear();
            Console.WriteLine("\n--- Iniciando Simulação ---");
            Console.WriteLine($"Cadeia de entrada: '{cadeia}'");
            Console.WriteLine($"Estado inicial: {estadoAtual}");
            Thread.Sleep(1000);

            // Se a cadeia for vazia, a simulação termina aqui.
            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("\nCadeia vazia, nenhuma transição a ser feita.");
            }

            foreach (char simbolo in cadeia)
            {
                string estadoAnterior = estadoAtual;
                // calcula o próximo estado usando a função de transição.
                estadoAtual = FuncaoTransicao(estadoAtual, simbolo);

                // estado atual a cada símbolo consumido.
                Console.WriteLine($"Leu '{simbolo}', transição de {estadoAnterior} -> {estadoAtual}");
                Thread.Sleep(300);
            }

            Console.WriteLine("\n--- Fim da Cadeia ---");
            Console.WriteLine($"O processo terminou no estado: {estadoAtual}");

            // Ao final, verifica se o estado atual é um dos estados de aceitação.
            if (estadoAtual == "q2")
            {
                Console.WriteLine("Resultado: ACEITA");
            }
            else
            {
                Console.WriteLine("Resultado: REJEITA");
            }
        }

        /// <summary>
        /// implementa a função de transição do AFD.
        /// dado um estado e um símbolo, retorna o próximo estado.
        /// </summary>
        private static string FuncaoTransicao(string estado, char simbolo)
        {
            // switch para uma implementação limpa.
            return (estado, simbolo) switch
            {
                ("q0", 'a') => "q1",
                ("q0", 'b') => "q0",
                ("q1", 'a') => "q1",
                ("q1", 'b') => "q2",
                ("q2", 'a') => "q2",
                ("q2", 'b') => "q2",
                _ => "estado_de_erro" // não deve ser atingido com a validação de entrada
            };
        }

        /// <summary>
        /// valida se a cadeia contém apenas símbolos do alfabeto {a, b}.
        /// </summary>
        private static bool CadeiaEhValida(string cadeia)
        {
            return cadeia.All(c => c == 'a' || c == 'b');
        }
    }
}