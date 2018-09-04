using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SuperFancyPants.Generics
{
    public class LinkedList
    {
        public class Node
        {
            public string Data { get; set; }
        }
    }

    public class CustomList<T>
    {
        private IList<T> _listOfItems = new List<T>();

        public void Add(T stringToAdd)
        {
            _listOfItems.Add(stringToAdd);
        }

        public int CustomCount()
        {
            return _listOfItems.Count;
        }
    }

    public class Todo
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    class Program
    {
        public static IList<Todo> Todos { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int a = 0;
            Int32 b = 0;

            long l = 0;
            Int64 l1 = 0;

            string s = "";
            String s1 = "";

            var i = 10;
            ParseInt(ref i);

            object o = i;

            var todo = new Todo { Name = "hiueht", Description = "ilryuthertilyegrt eruy " };

            var listTodos = new List<Todo> { todo, todo, todo, todo, todo };
            List<Todo> allHansItems = listTodos.Where(x => x.Name.Equals("Hans")).ToList();

            var anon = listTodos.Where(x => x.Name.Equals("Hans")).Select(x => new { Description = x.Description });
            var anon2 = (from t in listTodos
                         where t.Name.Equals("Hans")
                         select new { Description = t.Description });

            ParseTodo(todo);

            ArrayList list = new ArrayList();
            list.Add("Hoi");
            list.Add("Haai");
            list.Add(todo);
            list.Add(1);

            var list2 = new List<string>();

            var customList = new CustomList<string>();

            customList.Add("Hoi");
            customList.Add("Hello");


            var count = customList.CustomCount();

            // stackoverflow
            Recursive();

            Console.ReadKey();
        }

        private static void ParseInt(ref int i)
        {
            // iets 
            i = 20;
        }

        private static void ParseTodo(Todo todo)
        {
            // iets 
            todo.Name = "Hans";
        }

        private static void Recursive()
        {
            Recursive();
        }
    }
}
