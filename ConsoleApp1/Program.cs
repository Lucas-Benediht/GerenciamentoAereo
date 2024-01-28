using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SistemaGerenciamento.Data;
using SistemaGerenciamento.Interface;
using SistemaGerenciamento.Service;

namespace ConsoleApp1
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            ConfigureServices();

            using (var scope = serviceProvider.CreateScope())
            {
                var passageiroService = scope.ServiceProvider.GetRequiredService<IPassageiroService>();
                var aeroportoService = scope.ServiceProvider.GetRequiredService<IAeroportoService>();
                var vooService = scope.ServiceProvider.GetRequiredService<IVooService>();

                TelaDoMenu(passageiroService, aeroportoService, vooService);
            }

            Console.ReadLine();
        }

        static void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();


            serviceCollection.AddScoped<IAeroportoService, AeroportoService>();
            serviceCollection.AddScoped<IPassageiroService, PassageiroService>();
            serviceCollection.AddScoped<IVooService, VooService>();

            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        static void TelaDoMenu(IPassageiroService passageiroService, IAeroportoService aeroportoService, IVooService vooService)
        {
            while (true)
            {
                Console.WriteLine("Bem-vindo à tela de seleção...\nSelecione uma das seguintes opções:");
                Console.WriteLine("1 - Pesquisar Passageiro");
                Console.WriteLine("2 - Pesquisar Aeroporto");
                Console.WriteLine("3 - Pesquisar Voo");
                Console.WriteLine("4 - Criar Novo Passageiro");
                Console.WriteLine("5 - Sair");

                Console.Write("\nDigite sua opção: ");
                string escolhaUsuario = Console.ReadLine();
                Console.Clear();

                switch (escolhaUsuario)
                {
                    case "1":
                        PesquisarPassageiro(passageiroService);
                        break;
                    case "2":
                        PesquisarAeroporto(aeroportoService);
                        break;
                    case "3":
                        PesquisarVoo(vooService);
                        break;
                    case "4":
                        CriarNovoPassageiro(passageiroService);
                        break;
                    case "5":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void PesquisarPassageiro(IPassageiroService passageiroService)
        {
            Console.WriteLine("Digite o nome do passageiro: ");
            string entradaUsuario = Console.ReadLine();

            try
            {
                var passageiro = passageiroService.ObterPassageiroPorNome(entradaUsuario);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Passageiro encontrado: {passageiro.NomeCompleto}");

                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        static void PesquisarAeroporto(IAeroportoService aeroportoService)
        {
            Console.WriteLine("Digite o código ou o nome do aeroporto");
            string entradaUsuario = Console.ReadLine().ToUpper();

            try
            {

                bool isCodigo = entradaUsuario.All(char.IsLetter);

                if (isCodigo)
                {
                    var aeroporto = aeroportoService.ObterCodigoAeroporto(entradaUsuario.ToUpper());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Aeroporto encontrado: {aeroporto.Nome} \nCódigo: {aeroporto.Codigo}");
                    Console.ResetColor();
                }
                else
                {
                    var aeroporto = aeroportoService.ObterNomeAeroporto(entradaUsuario);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Aeroporto encontrado: {aeroporto.Nome} \nCódigo: {aeroporto.Codigo}");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void PesquisarVoo(IVooService vooService)
        {
            Console.Write("Digite o número do seu voo: ");
            int numeroVoo = int.Parse(Console.ReadLine());

            try
            {
                var voo = vooService.ObtemPorNumeroVoo(numeroVoo);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Voo encontrado: {voo.NumeroVoo} \nPartida: {voo.Partida} \nDestino: {voo.Destino} \nHorário de partida {voo.HoraPartida}, \nHorário de chegada: {voo.HoraChegada}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void CriarNovoPassageiro(IPassageiroService passageiroService)
        {
            Console.WriteLine("Digite o nome completo do novo passageiro:");
            string nomeCompleto = Console.ReadLine();

            Console.WriteLine("Digite a idade do novo passageiro:");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Idade inválida. Abortando a criação do passageiro.");
                return;
            }
            try
            {
                passageiroService.CriarNovoPassageiro(nomeCompleto, idade);
                Console.WriteLine($"Novo passageiro '{nomeCompleto}' criado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o passageiro: {ex.Message}");
            }
        }
    }
}
