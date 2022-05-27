using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace projeto_4_online
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("Escolhaz\n1-para exibir todas as tarefas\n2-para uma tarefa em especifico");
                int escolha = int.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        ReqList();
                        break;
                    case 2:
                        ReqUnica();
                        break;
                    default:
                        Console.WriteLine("escolha 1 ou 2");
                        break;
                }
            }
            ReqUnica();
        }
        static void ReqList()
        {
            
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            requisicao.Method = "GET";
            var resposta = requisicao.GetResponse();

            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();


                List<tarefa> tarefas = JsonConvert.DeserializeObject<List<tarefa>>(dados.ToString());
                foreach (tarefa item in tarefas)
                {
                    item.Exibir();
                }
                stream.Close();
                resposta.Close();
            }
            Console.ReadLine();
        }
        static void ReqUnica()
        {
            Console.WriteLine("digite o id da tarefa");
            int id = int.Parse(Console.ReadLine());
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/" + id);
            var resposta = requisicao.GetResponse();

            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();


                tarefa tarefas = JsonConvert.DeserializeObject<tarefa>(dados.ToString());
                tarefas.Exibir();

                stream.Close();
                resposta.Close();
            }
            Console.ReadLine();
        }
    }
}
