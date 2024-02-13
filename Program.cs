
using System.Reflection.Metadata;

List<string> listaBandas = new List<string>();

Dictionary<string, List<int>> bandaNotas = new Dictionary<string, List<int>>();

bandaNotas.Add("banda", [10,7,6]);

void ExibeMensagemBoasVindas()
{
    string msgBoasVindas = @"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀";
    Console.WriteLine(msgBoasVindas);
}

void ExibirTituloOperacoes(string titulo) 
{
    int qtdLetra = titulo.Length;
    string asterisco = string.Empty.PadLeft(qtdLetra, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

void RegistraBanda()
{
    Console.Clear();
    ExibirTituloOperacoes("Registro de Bandas");
    Console.Write("Digite a banda a ser registrada: ");
    string nomeBanda = Console.ReadLine()!;
    Console.WriteLine($" {nomeBanda} registrada!");
    bandaNotas.Add(nomeBanda, new List<int>());
    Console.Clear();
    ExibirOpcoesMenu();
}

void AvaliaBanda()
{
    Console.Clear();
    ExibirTituloOperacoes("Avaliação de Notas");
    Console.WriteLine("Qual banda deseja avaliar?");
    string banda = Console.ReadLine()!;
    if (bandaNotas.ContainsKey(banda))
    {
        Console.WriteLine($"Qual nota deseja atribuir à {banda}?");
        int nota = Console.Read();
        bandaNotas[banda].Add(nota);
        Console.WriteLine("feito");
        Thread.Sleep(2000);
        Console.Clear();
    }
    else
    {
        Console.WriteLine("\nn existe");
        Console.Clear();
        ExibirOpcoesMenu();
    }
    ExibirOpcoesMenu();
}
void MostraBanda() 
{
    Console.Clear();
    ExibirTituloOperacoes("Bandas: ");
    //for (int i = 0; i < listaBandas.Count; i++) 
    //{
    //    Console.WriteLine($"Banda: {listaBandas[i]}");   
    //}
    foreach (string banda in bandaNotas.Keys) 
    {
    Console.WriteLine(banda);
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}
void ExibirOpcoesMenu() 
{
    ExibeMensagemBoasVindas();
    Console.WriteLine("\n1 - Registrar Banda");
    Console.WriteLine("2 - Mostrar todas as Bandas");
    Console.WriteLine("3 - Avaliar Bandas");
    Console.WriteLine("4 - Exibir média de avaliação de banda");
    Console.WriteLine("5 - Sair");

    Console.Write("\ndigite sua opção: ");
    string opcao = Console.ReadLine()!;
    int opcaoEscolhida = int.Parse(opcao);

    switch (opcaoEscolhida)
    {
        case 1: RegistraBanda();
            break;
        case 2: MostraBanda();
            break;
        case 3: AvaliaBanda();
            break; 
        case 4: exibeMedia();
            break;
        case 5: Console.WriteLine("saiu");
            break;
        default: Console.WriteLine("opçao inválida");
            break;
    }

}


void exibeMedia() 
{
    Console.Clear();
    ExibirTituloOperacoes("Exibir a média de avaliação das bandas");
    Console.WriteLine("Média de qual banda?");
    string banda = Console.ReadLine()!;
    if (bandaNotas.ContainsKey (banda)) 
    {
        List<int> notas = bandaNotas[banda];
        Console.WriteLine(notas.Average());
    }
}

ExibirOpcoesMenu();

