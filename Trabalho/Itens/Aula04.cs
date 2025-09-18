using System;

namespace Trabalho.Itens
{
    public static class Aula04
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Avaliador de Proposição (P, Q, R) ===\n");

            bool p = LerBooleano("Valor de P (true/false): ");
            bool q = LerBooleano("Valor de Q (true/false): ");
            bool r = LerBooleano("Valor de R (true/false): ");

            //menu de fórmulas
            Console.WriteLine("\nEscolha a fórmula para avaliar:");
            Console.WriteLine("1 - (P /\\ Q) V ¬R");
            Console.WriteLine("2 - P → (Q V R)");

            int opcao = LerOpcao(1, 2);
            bool resultado = false;
            string formulaEscolhida = "";

            switch (opcao)
            {
                case 1:
                    formulaEscolhida = "(P /\\ Q) V ¬R";
                    resultado = (p && q) || !r;
                    break;
                case 2:
                    formulaEscolhida = "P -> (Q V R)";
                    resultado = !p || (q || r);
                    break;
            }

            Console.WriteLine($"\nResultado da fórmula {formulaEscolhida}: {resultado}");

            //tabela-verdade
            Console.Write("\nDeseja imprimir a tabela-verdade completa? (S/N): ");
            string imprimir = Console.ReadLine()?.Trim().ToUpper() ?? "N";

            if (imprimir == "S")
            {
                Console.WriteLine($"\nTabela-verdade da fórmula {formulaEscolhida}:\n");
                Console.WriteLine("P\tQ\tR\tResultado");
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        for (int k = 0; k <= 1; k++)
                        {
                            bool pi = i == 1;
                            bool qj = j == 1;
                            bool rk = k == 1;
                            bool res = opcao == 1 ? (pi && qj) || !rk : !pi || (qj || rk);
                            Console.WriteLine($"{pi}\t{qj}\t{rk}\t{res}");
                        }
                    }
                }
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }

        private static bool LerBooleano(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? entrada = Console.ReadLine()?.Trim().ToLower();
                if (entrada == "true") return true;
                if (entrada == "false") return false;
                Console.WriteLine("\nEntrada inválida. Digite 'true' ou 'false'.\n");
            }
        }

        private static int LerOpcao(int min, int max)
        {
            while (true)
            {
                Console.Write("Opção: ");
                string? entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int valor) && valor >= min && valor <= max)
                    return valor;
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}
