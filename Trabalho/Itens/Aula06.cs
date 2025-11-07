using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Trabalho.Itens;

// define a estrutura de dados para uma única pergunta, contendo a frase e a resposta correta.
public class Pergunta
{
    public string Frase { get; set; } = "";
    public string Resposta { get; set; } = "";
}
public static class Aula06
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("=== Problema (P) vs. Instância (I) ===");

        List<Pergunta>? perguntas = CarregarPerguntas();

        // validação para garantir que as perguntas foram carregadas corretamente
        if (perguntas == null || perguntas.Count == 0)
        {
            Console.WriteLine("Não foi possível carregar as perguntas do arquivo JSON.");
            return;
        }

        int acertos = 0;
        foreach (var pergunta in perguntas)
        {
            Console.WriteLine($"\nFrase: \"{pergunta.Frase}\"");
            string? respostaUsuario;

            // loop para validar a entrada do usuário, aceitando apenas p ou i
            do
            {
                Console.Write("Classifique como Problema (P) ou Instância (I): ");
                respostaUsuario = Console.ReadLine()?.ToUpper();
            } while (respostaUsuario != "P" && respostaUsuario != "I");

            if (respostaUsuario == pergunta.Resposta.ToUpper())
            {
                Console.WriteLine("Resposta correta!");
                acertos++;
            }
            else
            {
                Console.WriteLine($"Resposta incorreta. O correto era: {pergunta.Resposta}");
            }
        }

        Console.WriteLine("\n--- Resumo Final ---");
        Console.WriteLine($"Você acertou {acertos} de {perguntas.Count} perguntas.");
    }

    // lê o arquivo 'perguntas.json' e o deserializa em uma lista de objetos Pergunta
    private static List<Pergunta>? CarregarPerguntas()
    {
        string caminhoArquivo = "perguntas.json";
        try
        {
            string jsonString = File.ReadAllText(caminhoArquivo);

            var options = new JsonSerializerOptions
            {
                
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            return JsonSerializer.Deserialize<List<Pergunta>>(jsonString, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo JSON: {ex.Message}");
            return null;
        }
    }
}