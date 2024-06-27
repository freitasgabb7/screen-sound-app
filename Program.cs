// Screen Sound app
string msgBoasVindas = "Seja bem-vindo ao...";

Dictionary<string, List<int>> bandasReg = new Dictionary<string, List<int>>
{
    { "Sleep Token", new List <int> { 10, 8 } },
    { "Bad Omens", new List <int>() }
};
//bandasReg.Add("Sleep Token", new List<int> { 10, 8 });
//bandasReg.Add("Bad Omens", new List<int> { 7, 8, 10 });
//bandasReg.Add("Bring Me The Horizon", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(msgBoasVindas);
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
}

void ExibirOptMenu()
{
    ExibirLogo();
    Console.WriteLine("Digite 1 para registar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string optEscolhida = Console.ReadLine()!;
    int optEscolhidaNum = int.Parse(optEscolhida);
    switch (optEscolhidaNum)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            Console.WriteLine("\nVocê digitou a opção " + optEscolhida);
            break;
        case 0:
            Console.WriteLine("\nTchau tchau :)");
            break;
        default:
            Console.WriteLine("\nOpção inválida!");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpt("REGISTRO DE BANDAS");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasReg.Add(nomeDaBanda, new List<int>());
    Console.Write($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(1500);
    Console.Clear();
    ExibirOptMenu();
}

void MostrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpt("BANDAS REGISTRADAS");
    int contador = 1;
    foreach (string banda in bandasReg.Keys)
    {
        Console.WriteLine($"{contador}. {banda}");
        contador++;
    }
    Console.Write("\nDigite qualquer tecla para voltar ao menu principal: ");
    Console.ReadKey();
    Console.Clear();
    ExibirOptMenu();
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDaOpt("AVALIAR BANDA");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasReg.ContainsKey(nomeDaBanda))
    {
        Console.Write($"\nDe 1 a 10, avalie a banda {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasReg[nomeDaBanda].Add(nota); // colchete indexa o dicionario usando a chave e acessa os valores (lista int)
        Console.Write($"\nA nota {nota} para a banda {nomeDaBanda} foi registrada com sucesso.");
        //foreach (int notaAux in bandasReg[nomeDaBanda]) //imprime todas notas apos registrar a nota
        //{
        //    Console.WriteLine(notaAux);
        //}
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOptMenu();
    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.Write("\nDigite qualquer tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOptMenu();
    }
} 

void ExibirTituloDaOpt(string titulo)
{
    int qtdLetras = titulo.Length;
    string iguais = string.Empty.PadLeft(qtdLetras, '=');
    Console.WriteLine(iguais);
    Console.WriteLine(titulo);
    Console.WriteLine(iguais + "\n");
}

ExibirOptMenu();