using System;
using System.Collections.Generic;
using System.Threading;

namespace Trabalho.Itens
{
    // enum para representar os possíveis desfechos da simulação de detecção de loop
    public enum ResultadoSimulacao
    {
        LoopDetectado,
        LimiteAtingido
    }
    public static class Aula09
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Item 4 da AV2: Detector Ingênuo de Loop e Reflexão ===\n");

            int maxPassos;
            while (true)
            {
                Console.Write("Digite o limite de passos para a simulação (ex: 30): ");
                if (int.TryParse(Console.ReadLine(), out maxPassos) && maxPassos > 0) break;
                Console.WriteLine("Valor inválido. Por favor, digite um número inteiro positivo.\n");
            }

            Console.WriteLine("\nEscolha a heurística (processo discreto) a ser testada:");
            Console.WriteLine("1) Collatz Módulo (Ciclo longo, ~28 passos para repetir)");
            Console.WriteLine("2) Quadrática Módulo (Ciclo médio, ~11 passos para repetir)");
            Console.WriteLine("3) Linear Simples (Ciclo curto, 8 passos para repetir)");

            string? escolha;
            while (true)
            {
                Console.Write("\nOpção: ");
                escolha = Console.ReadLine();
                if (escolha == "1" || escolha == "2" || escolha == "3") break;
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            ResultadoSimulacao resultado;
            switch (escolha)
            {
                case "1":
                    resultado = SimularProcesso(maxPassos, 1, HeuristicaCollatzModulo, "f(x) = (x * 3 + 1) % 29");
                    ImprimirReflexaoEspecifica(resultado, maxPassos, "Collatz Módulo", 28);
                    break;
                case "2":
                    resultado = SimularProcesso(maxPassos, 2, HeuristicaQuadratica, "f(x) = (x * x + 5) % 17");
                    ImprimirReflexaoEspecifica(resultado, maxPassos, "Quadrática Módulo", 11);
                    break;
                case "3":
                    resultado = SimularProcesso(maxPassos, 0, HeuristicaLinearSimples, "f(x) = (x + 3) % 8");
                    ImprimirReflexaoEspecifica(resultado, maxPassos, "Linear Simples", 8);
                    break;
            }

            ImprimirReflexaoGeral();

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }

        private static ResultadoSimulacao SimularProcesso(int maxPassos, int estadoInicial, Func<int, int> funcaoHeuristica, string descricaoHeuristica)
        {
            int estadoAtual = estadoInicial;
            var historicoEstados = new List<int>();

            Console.Clear();
            Console.WriteLine("--- Iniciando Simulação do Processo Discreto ---");
            Console.WriteLine($"Função de transição escolhida: {descricaoHeuristica}\n");
            Console.WriteLine($"Passo 0: Estado inicial -> {estadoAtual}");
            historicoEstados.Add(estadoAtual);

            for (int passo = 1; passo <= maxPassos; passo++)
            {
                // aplicação da heurística para determinar o próximo estado
                estadoAtual = funcaoHeuristica(estadoAtual);
                Console.WriteLine($"Passo {passo}: Novo estado -> {estadoAtual}");

                // verifica se o estado atual já existe no histórico
                if (historicoEstados.Contains(estadoAtual))
                {
                    Console.WriteLine($"\n!!! POTENCIAL LAÇO DETECTADO !!!");
                    Console.WriteLine($"O estado '{estadoAtual}' já foi visitado anteriormente.");
                    Console.WriteLine("Simulação interrompida.");
                    return ResultadoSimulacao.LoopDetectado;
                }

                historicoEstados.Add(estadoAtual);
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nSimulação concluída. Nenhum loop detectado dentro do limite de {maxPassos} passos.");
            return ResultadoSimulacao.LimiteAtingido;
        }

        private static void ImprimirReflexaoEspecifica(ResultadoSimulacao resultado, int maxPassos, string nomeHeuristica, int tamanhoCiclo)
        {
            Console.WriteLine("\n--- Reflexão Específica sobre este Teste ---");
            if (resultado == ResultadoSimulacao.LoopDetectado)
            {
                Console.WriteLine($"SUCESSO: O detector encontrou o loop da heurística '{nomeHeuristica}' porque o seu limite de passos ({maxPassos}) foi maior ou igual que o comprimento do ciclo (~{tamanhoCiclo} passos).");
                Console.WriteLine("Isso mostra que, com conhecimento prévio do sistema, o detector pode ser eficaz.");
            }
            else // Caso de LimiteAtingido
            {
                Console.WriteLine($"FALSO NEGATIVO: O detector falhou em encontrar o loop da heurística '{nomeHeuristica}'.");
                Console.WriteLine($"A razão foi que o ciclo de repetição dela (~{tamanhoCiclo} passos) é MAIS LONGO que o seu limite de passos ({maxPassos}).");
                Console.WriteLine("Este é um exemplo prático de 'falso negativo': o programa deu uma resposta ('não há loop'), mas a resposta está incorreta devido a uma limitação do método.");
            }
        }

        private static void ImprimirReflexaoGeral()
        {
            Console.WriteLine("\n\n--- Explicação ---");
            Console.WriteLine("Como vimos nos testes, a eficácia deste detector depende criticamente do limite de passos ser maior que o ciclo do processo.");

            Console.WriteLine("\n[Falsos Positivos]:");
            Console.WriteLine("Nossas heurísticas são sequências simples, onde uma repetição sempre significa um loop. Um falso positivo ocorreria em um sistema diferente (ex: busca em árvore), onde revisitar um estado pode ser uma ação válida. O detector ingênuo não consegue distinguir entre um loop problemático e uma revisitação benigna.");

            Console.WriteLine("\n[Problema da Parada]:");
            Console.WriteLine("A dificuldade fundamental é que não podemos saber o quão longo um ciclo pode ser. O 'Problema da Parada' prova que é impossível criar um algoritmo que determine para QUALQUER programa se ele vai parar ou entrar em loop, que é exatamente o desafio que enfrentamos aqui.");
        }

        // Funções que definem os processos discretos a serem simulados
        private static int HeuristicaCollatzModulo(int x) => (x * 3 + 1) % 29;
        private static int HeuristicaQuadratica(int x) => (x * x + 5) % 17;
        private static int HeuristicaLinearSimples(int x) => (x + 3) % 8;
    }
}