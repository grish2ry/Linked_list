using System;
using System.Runtime.CompilerServices;

namespace Program
{
    /// <summary>
    /// Односвязный список с элементами обобщённого типа.
    /// 
    /// Параметр <typeparamref name="T"/> обозначает тип значений,
    /// которые будут храниться в списке.
    /// Например:
    /// - LinkedList<int>  — список целых чисел
    /// - LinkedList<string> — список строк
    /// - LinkedList<MyClass> — список объектов пользовательского класса
    /// </summary>
    public class LinkedList<T>
    {
        // Внутренний узел списка
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? head;

        /// <summary>
        /// Добавить элемент в конец списка.
        /// Если список пустой – новый узел становится head.
        /// Если не пустой – в цикле (или рекурсией) пройти по Next до конца и добавить там новый узел.
        /// </summary>
        public void Add(T item)
        {
            if (head != null)
            {
                Node node = head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = new Node(item);
            }
            else
            {
                head = new Node(item);
                return;
            }
            
            
        }

        /// <summary>
        /// Удалить первый найденный элемент по значению.
        /// Если элемент найден – удалить и вернуть true.
        /// Если элемента нет – вернуть false.
        /// </summary>
        public bool Remove(T item)
        {
            if (head == null)
                return false;

            Node? node = head;
            if(Equals(node.Value, item))
            {
                head = node.Next;
                return true;
            }
            while (node.Next != null)
            {
                if (Equals(node.Next.Value, item))
                {
                    node.Next = node.Next.Next;
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Вернуть элемент по индексу (0-based).
        /// Пройти по цепочке Next, пока не дойдём до нужного индекса.
        /// Если индекс за пределами списка – выбросить ArgumentOutOfRangeException.
        /// </summary>
        public T Get(int index)
        {
            if (head == null || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }
            Node node = head;
            for (int i = 0; i < index; i++)
            {
                if (node.Next == null && i < index)
                    throw new ArgumentOutOfRangeException("Index out of range");

                else if (node.Next != null)
                    node = node.Next;
            }
            return node.Value;
            
        }

        /// <summary>
        /// Подсчитать количество элементов в списке.
        /// Пройти по цепочке Next от head до конца, увеличивая счётчик.
        /// Вернуть количество.
        /// </summary>
        public int Count()
        {
            if(head == null)
                return 0;
            int count = 1;
            Node? node = head;
            while(node.Next != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }

        /// <summary>
        /// Очистить список.
        /// Достаточно обнулить head, тогда вся цепочка узлов будет недоступна и сборщик мусора освободит память.
        /// </summary>
        public void Clear()
        {
            head = null;
        }
    }
}
