using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGerenciadorDeTarefas
{
    internal class Tarefas
    {
        private List<String> tarefas = new List<String>();

        public String CadastrarTarefa(String nome, string descricao, String status)
        {
            Console.Write("Digite o nome da tarefa: ");
            nome = Console.ReadLine();
            Console.Write("Digite a descrição da tarefa: ");
            descricao = Console.ReadLine();
            Console.Write("Digite a data de vencimento (dd/mm/aaaa): ");
            DateTime dataVencimento = DateTime.Parse(Console.ReadLine());
            status = "Pendente";
            String tarefa = $"Nome: {nome}, Descrição: {descricao}, Data de Vencimento: {dataVencimento.ToShortDateString()}, Status: {status}";
            tarefas.Add(tarefa);
            return "Nova tarefa cadastrada com sucesso!";
        }
    }
}
