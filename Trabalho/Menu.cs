using Trabalho.Itens;

class Menu
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Projeto Toolkit");
            Console.WriteLine("---- AV1 ----");
            Console.WriteLine("1) Verificar alfabeto e cadeia (Σ={a,b})");
            Console.WriteLine("2) Classificador T/I/N por JSON");
            Console.WriteLine("3) Decisor: termina com 'b'?");
            Console.WriteLine("4) Avaliador de Proposição (P,Q,R)");
            Console.WriteLine("5) Reconhecedor: L_par_a e a b*");
            Console.WriteLine("0) Sair");

            int opcao = LerOpcaoDoMenu(0, 5);
            Console.WriteLine();

            if (opcao == 0) return;
            if (opcao == 1) Aula01.Executar();
            if (opcao == 2) Aula02.Executar();
            if (opcao == 3) Aula03.Executar();
            if (opcao == 4) Aula04.Executar();
            if (opcao == 5) Aula05.Executar();

            Console.WriteLine();
        }
    }

    private static int LerOpcaoDoMenu(int valorMinimo, int valorMaximo)
    {
        while (true)
        {
            Console.Write("\nOpção: ");
            string? textoDigitado = Console.ReadLine();
            if (int.TryParse(textoDigitado, out int valorLido))
            {
                if (valorLido >= valorMinimo && valorLido <= valorMaximo)
                {
                    return valorLido;
                }
            }
            Console.WriteLine("\nOpção invalida.");
        }
    }
}
