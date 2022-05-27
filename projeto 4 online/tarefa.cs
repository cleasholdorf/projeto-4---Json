using System;
using System.Collections.Generic;
using System.Text;

namespace projeto_4_online
{
    class tarefa
    {

        public int userId;
        public int id;
        public string title;
        public bool completed;
        public void Exibir()
        {
            Console.WriteLine("objeto Tarefa");
            Console.WriteLine($"user id: {userId}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Finalizou: {completed}");
            Console.WriteLine("");
            Console.WriteLine("===========================================");
        }
    }
   
}
