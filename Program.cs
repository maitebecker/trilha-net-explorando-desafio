using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("==============================================");
Console.WriteLine("             BEM-VINDO AO HOTEL C#            ");
Console.WriteLine("==============================================");
Console.WriteLine("Por favor, escolha uma das nossas acomodações:");
Console.WriteLine("1- Suíte Padrão        | Capacidade: 1 hóspede  | Valor da diária: R$ 90,00");
Console.WriteLine("2- Suíte Conforto      | Capacidade: 2 hóspedes | Valor da diária: R$ 150,00");
Console.WriteLine("3- Suíte Luxo          | Capacidade: 4 hóspedes | Valor da diária: R$ 300,00");
Console.WriteLine("4- Suíte Master Royal  | Capacidade: 6 hóspedes | Valor da diária: R$ 600,00");
Console.WriteLine("Digite o número da suíte desejada para continuar:");
int opcao = Int32.Parse(Console.ReadLine());

Suite suite = new Suite();
switch(opcao)
{
    case 1:
        suite = new Suite(tipoSuite: "Padrão", capacidade: 1, valorDiaria: 90);
        break;
    case 2:
        suite = new Suite(tipoSuite: "Conforto", capacidade: 2, valorDiaria: 150);
        break;
    case 3:
        suite = new Suite(tipoSuite: "Luxo", capacidade: 4, valorDiaria: 300);
        break;
    case 4:
        suite = new Suite(tipoSuite: "Master Royal", capacidade: 6, valorDiaria: 600);
        break;
    default:
        throw new Exception("Opção inválida");
}

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
Console.Clear();
Console.WriteLine($"A capacidade da suíte é de {suite.Capacidade} hospedes");
Console.WriteLine("Por favor, digite o número de hóspedes:");
int numeroHospedes = Int32.Parse(Console.ReadLine());

if(numeroHospedes <= suite.Capacidade)
{
    for(int i = 0; i < numeroHospedes; i++)
    {
        Console.WriteLine("Cadastre o nome do hóspedes:");
        string nomeHospede = Console.ReadLine();
        hospedes.Add(new Pessoa(nome: nomeHospede));
    }
}
else
{
    throw new Exception("A quantidade de hóspedes não pode exceder a capacidade da suíte");
}



// Cria uma nova reserva, passando a suíte e os hóspedes
Console.Clear();
Console.WriteLine("Por favor, digite o número de dias reservados:");
int numeroDias = Int32.Parse(Console.ReadLine());
Reserva reserva = new Reserva(diasReservados: numeroDias);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.Clear();
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");