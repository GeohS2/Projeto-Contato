using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//⠄⠄⢀⡋⣡⣴⣶⣶⡀⠄⠄⠙⢿⣿⣿⣿⣿⣿⣴⣿⣿⣿⢃⣤⣄⣀⣥⣿⣿⠄
//⠄⠄⢸⣇⠻⣿⣿⣿⣧⣀⢀⣠⡌⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠿⠿⣿⣿⣿⠄
//⠄⢀⢸⣿⣷⣤⣤⣤⣬⣙⣛⢿⣿⣿⣿⣿⣿⣿⡿⣿⣿⡍⠄⠄⢀⣤⣄⠉⠋⣰
//⠄⣼⣖⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⢇⣿⣿⡷⠶⠶⢿⣿⣿⠇⢀⣤
//⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣽⣿⣿⣿⡇⣿⣿⣿⣿⣿⣿⣷⣶⣥⣴⣿⡗
//⢀⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠄
//⢸⣿⣦⣌⣛⣻⣿⣿⣧⠙⠛⠛⡭⠅⠒⠦⠭⣭⡻⣿⣿⣿⣿⣿⣿⣿⣿⡿⠃⠄
//⠘⣿⣿⣿⣿⣿⣿⣿⣿⡆⠄⠄⠄⠄⠄⠄⠄⠄⠹⠈⢋⣽⣿⣿⣿⣿⣵⣾⠃⠄
//⠄⠘⣿⣿⣿⣿⣿⣿⣿⣿⠄⣴⣿⣶⣄⠄⣴⣶⠄⢀⣾⣿⣿⣿⣿⣿⣿⠃⠄
//⠄⠄⠈⠻⣿⣿⣿⣿⣿⣿⡄⢻⣿⣿⣿⠄⣿⣿⡀⣾⣿⣿⣿⣿⣛⠛⠁⠄⠄
//⠄⠄⠄⠄⠈⠛⢿⣿⣿⣿⠁⠞⢿⣿⣿⡄⢿⣿⡇⣸⣿⣿⠿⠛⠁

namespace projeto_contato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo á sua agenda de contatos!");

            Agenda agenda = new Agenda();
            agenda.CarregarContatos();

            int opcao;
            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Adicionar um novo contato");
                Console.WriteLine("2. Listar todos os contatos");
                Console.WriteLine("3. Buscar um contato");
                Console.WriteLine("4. Editar um contato");
                Console.WriteLine("5. Excluir um contato");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                Console.Clear(); //Limpa a tela

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Adicionar um novo contato.");
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefone = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        agenda.AdicionarContato(new Contato(nome, telefone, email));
                        Console.WriteLine("Contato adicionado com sucesso!");
                        break;
                    case 2:
                        Console.WriteLine("Lista de todos os contatos \n");
                        agenda.ListarContatos();
                        break;
                    case 3:
                        Console.WriteLine("Buscar um contato \n");
                        Console.Write("Digite o nome, telefone ou email do contato: ");
                        string termoBusca = Console.ReadLine();
                        Contato contatoBuscado = agenda.BuscarContato(termoBusca);

                        if (contatoBuscado != null)
                        {
                            Console.WriteLine(contatoBuscado);
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Editar um contato.\n");
                        Console.Write("Digite o nome, telefone ou email do contato a ser editado: ");
                        string termoEdicao = Console.ReadLine();
                        Contato contatoEditar = agenda.BuscarContato(termoEdicao);

                        if (contatoEditar != null)
                        {
                            Console.Write("Novo nome: ");
                            string novoNome = Console.ReadLine();
                            Console.Write("Novo Telefone: ");
                            string novoTelefone = Console.ReadLine();
                            Console.Write("Novo email: ");
                            string novoEmail = Console.ReadLine();
                            agenda.EditarContato(termoEdicao, new Contato(novoNome, novoTelefone, novoEmail));
                            Console.WriteLine("Contato Editado com sucesso. ");
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado. ");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Excluir um contato. \n");
                        Console.Write("Digite o nome, telefone ou email a ser excluído: ");
                        string termoExclusao = Console.ReadLine();
                        agenda.ExcluirContato(termoExclusao);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        agenda.SalvarContatos();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente.");
                        break;

                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (opcao != 0);
        }
    }
}
