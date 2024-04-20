using System;
using System.Collections.Generic;

namespace GerenciamentoDeTarefas
{
    class Tarefa
    {
        public string Nome { get; set; }
        public bool Concluida { get; set; }

        public Tarefa(string nome)
        {
            Nome = nome;
            Concluida = false;
        }
    }

    class Program
    {
        static List<Tarefa> tarefas = new List<Tarefa>();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("=== Gerenciador de Tarefas ===");
                Console.WriteLine("1. Adicionar Tarefa");
                Console.WriteLine("2. Visualizar Tarefas");
                Console.WriteLine("3. Marcar Tarefa como Concluída");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        AdicionarTarefa();
                        break;
                    case "2":
                        VisualizarTarefas();
                        break;
                    case "3":
                        MarcarComoConcluida();
                        break;
                    case "4":
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void AdicionarTarefa()
        {
            Console.Write("Digite o nome da tarefa: ");
            string nome = Console.ReadLine();
            tarefas.Add(new Tarefa(nome));
            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        static void VisualizarTarefas()
        {
            Console.WriteLine("=== Tarefas ===");
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada.");
            }
            else
            {
                for (int i = 0; i < tarefas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. [{(tarefas[i].Concluida ? "X" : " ")}] {tarefas[i].Nome}");
                }
            }
        }

        static void MarcarComoConcluida()
        {
            VisualizarTarefas();
            Console.Write("Digite o número da tarefa que deseja marcar como concluída: ");
            int indice;
            if (int.TryParse(Console.ReadLine(), out indice) && indice > 0 && indice <= tarefas.Count)
            {
                tarefas[indice - 1].Concluida = true;
                Console.WriteLine("Tarefa marcada como concluída.");
            }
            else
            {
                Console.WriteLine("Índice inválido. Tente novamente.");
            }
        }
    }
}