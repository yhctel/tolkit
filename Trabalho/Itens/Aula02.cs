using System;
using System.Collections.Generic;
using System.Text.Json;

public class Problema
{
    public string descricao { get; set; } = "";
    public string respostaCorreta { get; set; } = "";
}

public static class Aula02
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("=== Classificação de Problemas T/I/N ===\n");
        Console.WriteLine("Classifique os problemas como:\nT = Tratável\nI = Intratável\nN = Não computável\n");

        string json = @"
        [
            { ""descricao"": ""Problema do caminho mínimo em grafos"", ""respostaCorreta"": ""T"" },
            { ""descricao"": ""Problema da parada de um programa"", ""respostaCorreta"": ""N"" },
            { ""descricao"": ""Problema do caixeiro viajante (geral)"", ""respostaCorreta"": ""I"" }
        ]";

        var problemas = JsonSerializer.Deserialize<List<Problema>>(json)!;

        int acertos = 0;
        int erros = 0;

        foreach (var problema in problemas)
        {
            Console.WriteLine($"Classifique o problema: {problema.descricao}");
            Console.Write("Digite T (tratável), I (intratável) ou N (não computável): ");
            string resposta = Console.ReadLine()?.Trim().ToUpper() ?? "";

            if (resposta == problema.respostaCorreta)
            {
                Console.WriteLine("Acertou!");
                acertos++;
            }
            else
            {
                Console.WriteLine($"Errou! Resposta correta: {problema.respostaCorreta}");
                erros++;
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Resumo: {acertos} acertos, {erros} erros.");
        Console.WriteLine("\nPressione ENTER para voltar ao menu...");
        Console.ReadLine();
        Console.Clear();
    }
}
