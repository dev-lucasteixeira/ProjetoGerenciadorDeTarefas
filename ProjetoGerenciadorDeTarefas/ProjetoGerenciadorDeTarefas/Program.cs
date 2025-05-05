using System.Data;

namespace ProjetoGerenciadorDeTarefas
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int opcao = 0;
                List<String> tarefas = new List<String>();
                do
                {

                    Menu(ref opcao);
                    

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Cadastrar Tarefas");
                            CadastrarTarefa(tarefas);
                            break;
                        case 2:
                            Console.WriteLine("Consultar Tarefas");
                            ConsultarTarefas(tarefas);
                            break;
                        case 3:
                            Console.WriteLine("Atualizar Status");
                            AtualizarStatus(tarefas);
                            break;
                        case 4:
                            Console.WriteLine("Sair");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                } while (opcao != 4);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Obrigado por usar o nosso site!");
            }
        }

        private static void Menu(ref int opcao)
        {
            Console.WriteLine("Gerenciador de Tarefas");
            Console.WriteLine("1. Cadastrar Tarefa");
            Console.WriteLine("2. Consultar Tarefas");
            Console.WriteLine("3. Atualizar Status");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            String entrada = Console.ReadLine();
            opcao = int.Parse(entrada);
        }

        private static void CadastrarTarefa(List<String> tarefas)
        {
            Console.Write("Digite o nome da tarefa: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a descrição da tarefa: ");
            string descricao = Console.ReadLine();
            Console.Write("Digite a data de vencimento (dd/mm/aaaa): ");
            DateTime dataDeCadastro = DateTime.Now;
            DateTime dataVencimento = DateTime.Parse(Console.ReadLine());
            if (dataVencimento < DateTime.Now)
            {
                Console.WriteLine("Data de vencimento inválida!");
                return;
            }
            string status = "Pendente";
            String tarefa = $"Nome: {nome}, Descrição: {descricao}, Data de Cadastro: {dataDeCadastro.ToShortDateString()}, Data de Vencimento: {dataVencimento.ToShortDateString()}, Status: {status}";
            tarefas.Add(tarefa);
            Console.WriteLine("Nova tarefa cadastrada com sucesso!");
        }

        private static void ConsultarTarefas(List<String> tarefas)

        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada.");
            }
            else
            {
                Console.WriteLine("Tarefas cadastradas:");
                foreach (var tarefa in tarefas)
                {
                    Console.WriteLine(tarefa);
                }
            }
        }

        private static void AtualizarStatus(List<String> tarefas)

        {
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine(tarefa);
            }
            Console.Write("Digite o nome da tarefa que deseja atualizar: ");
            string nome = Console.ReadLine();

            
            int indice = tarefas.FindIndex(t => t.Contains(nome));

            if (indice != -1)
            {
                Console.Write("Digite o novo status (Pendente/Concluída): ");
                string novoStatus = Console.ReadLine();

                
                string tarefaAtualizada = tarefas[indice].Replace("Pendente", novoStatus);
                tarefas[indice] = tarefaAtualizada;

                Console.WriteLine("Status atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }


    }
}
