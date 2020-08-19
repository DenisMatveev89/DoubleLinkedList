using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList
{
    public class DoubleLinkedList
    {
        public DNode Head { get; set; }
        public DNode Tail { get; set; }
        private int _count = 0;
        private int _firstFound;
        private int _indexMax;
        private int _indexMin;
        private int _length = 0;
        public DoubleLinkedList() { }
        public DoubleLinkedList(int value) { }
        public void AddLast(int value)
        {
            DNode newNode = new DNode(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
            }
            Tail = newNode;
            _count++;
            _length++;
        }
        public void AddLast(int[] values)
        {
            DNode node = new DNode();
            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i]);
            }
            _length += values.Length;
        }
        public void AddFirst(int value)
        {
            DNode newNode = new DNode(value);
            if (Head == null)
            {
                Head = newNode;
            }
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
            _count++;
            _length += _count;
        }
        public void AddFirst(int[] values)
        {
            DNode node = new DNode();
            for (int i = values.Length - 1; i >= 0; i--)
            {
                AddFirst(values[i]);
            }
            _length += values.Length;
        }
        // Вставка элемента по указанному индексу.
        public void AddAt(int index, int item)
        {
            if (index < 0)
            {
                throw new Exception("Error");
            }
            else if (index == 0)
            {
                AddFirst(item);
                return;
            }
            DNode currentNode = Head;
            int idx = 0;
            while (currentNode != null)
            {
                if (idx == index - 1)
                {
                    DNode newNode = new DNode(item);
                    newNode.Next = currentNode.Next;
                    newNode.Prev = currentNode;
                    currentNode.Next = newNode;
                    _count++;
                    return;
                }
                currentNode = currentNode.Next;
                idx++;
            }
        }
        // Вставка массива по указанному индексу.
        public void AddAt(int index, int[] values)
        {
            if (index < 0 || index > _count)
            {
                throw new Exception("Error");
            }
            else if (index == 0)
            {
                AddFirst(values);
                return;
            }
            for (int i = 0; i < values.Length; i++)
            {
                AddAt(index + i, values[i]);
            }
            _length += values.Length;
        }
        // Узнать кол-во элементов в списке.
        public int GetSize() 
        {
            return _length;
        }
        // Поменять значение элемента с указанным индексом.
        public void Set(int index, int value) 
        {
            if (index < 0 || index > _count)
            {
                throw new Exception("Error");
            }
            if (index <= _count / 2)
            {
                DNode currentNode = Head;
                for (int i = 0; i < _count / 2; i++)
                {
                    if (index == i)
                    {
                        currentNode.Value = value;
                    }
                    currentNode = currentNode.Next;
                }
            }
            else if (index > _count / 2)
            {
                DNode currentNode = Tail;
                for (int i = _count - 1; i > _count / 2 - 1; i--)
                {
                    if (index == i)
                    {
                        currentNode.Value = value;
                    }
                    currentNode = currentNode.Prev;
                }
            }
        }
        // Удаление первого элемента.
        public void RemoveFirst() 
        {
            if (Head == null || _count < 1)
            {
                throw new Exception("Error");
            }
            Head = Head.Next;
            _count--;
        }
        // Удаление последнего элемента.
        public void RemoveLast() 
        {
            if (Tail == null || _count <= 1)
            {
                throw new Exception("Error");
            }
            Tail = Tail.Prev;
            Tail.Next = null;
            _count--;
        }
        // Удаление по индексу.
        public void RemoveAt(int index) 
        {
            if (index < 0 || index > _length)
            {
                throw new Exception("Error");
            }
            else if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == _length)
            {
                RemoveLast();
            }
            else
            {
                if (index < _length / 2)
                {
                    DNode currentNode = Head;
                    for (int i = 0; i < _length / 2; i++)
                    {
                        if (index == i)
                        {
                            currentNode = currentNode.Prev;
                            currentNode.Next = currentNode.Next.Next;
                        }
                        currentNode = currentNode.Next;
                    }
                    _count--;
                    _length--;
                }
                else if (index >= _length / 2)
                {
                    DNode currentNode = Tail;
                    for (int i = _length - 1; i > _length / 2 + 1; i--)
                    {
                        if (index == i)
                        {
                            currentNode = currentNode.Prev;
                            currentNode.Next = currentNode.Next.Next;
                            _count--;
                            _length--;
                        }
                        currentNode = currentNode.Prev;
                    }
                }
            }

        }
        // Удалить все элементы, равные val.
        public void RemoveAll(int value) 
        {
            if (Head == null)
            {
                throw new Exception("Error");
            }
            DNode currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    if (currentNode != null)
                    {
                        if (currentNode.Next != null)
                        {
                            currentNode.Next.Prev = currentNode.Prev;
                        }
                        else
                        {
                            Tail = currentNode.Prev;
                        }

                        if (currentNode.Prev != null)
                        {
                            currentNode.Prev.Next = currentNode.Next;
                        }
                        else
                        {
                            Head = currentNode.Next;
                        }
                        _count--;
                    }
                }
                currentNode = currentNode.Next;
            }
        }
        // Проверка, есть ли элемент в списке.
        public bool Contains(int value) 
        {
            DNode currentNode = Head;
            if (_count < 100000)
            {
                for (int i = 0; i <= _count - 1; i++)
                {
                    if (currentNode.Value == value) { _firstFound = i; return true; }
                    currentNode = currentNode.Next;
                }
                return false;
            }
            for (int i = 0; i <= _count / 2; i++)
            {
                if (currentNode.Value == value) { _firstFound = i; return true; }
                currentNode = currentNode.Next;
            }
            for (int i = _count / 2; i < _count - 1; i++)
            {
                if (currentNode.Value == value) { _firstFound = i; return true; }
                currentNode = currentNode.Next;
            }
            return false;
        }
        // Вернёт индекс первого найденного элемента, равного val(или -1, если элементов с таким значением в списке.
        public int IndexOf(int value) 
        {
            _firstFound = 0;
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            else if (Contains(value) == true)
            {
                return _firstFound;
            }
            return -1;
        }
        // Вернёт значение первого элемента списка.
        public int GetFirst() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            return Head.Value;
        }
        // Вернёт значение последнего элемента списка.
        public int GetLast() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            return Tail.Value;
        }
        // Вернёт значение элемента списка c указанным индексом.
        public int Get(int index) 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            else if (index > _count || index < 0) throw new Exception("Error - ошибка индекса");

            if (index <= _count / 2)
            {
                int idx = 0;
                DNode currentNode = Head;
                while (currentNode != null)
                {
                    if (idx == index)
                    {
                        return currentNode.Value;
                    }
                    currentNode = currentNode.Next;
                    idx++;
                }
            }
            else
            {
                DNode currentNode = Tail;
                int idx = _count - 1;
                while (currentNode != null)
                {
                    if (idx == index)
                    {
                        return currentNode.Value;
                    }
                    currentNode = currentNode.Prev;
                    idx--;
                }
            }
            return 0;
        }
        // Реверс.
        public void Reverse()
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            DNode temp = null;
            DNode currentNode = Head;
            while (currentNode != null)
            {
                temp = currentNode.Prev;
                currentNode.Prev = currentNode.Next;
                currentNode.Next = temp;
                currentNode = currentNode.Prev;
            }
            if (temp != null)
            {
                Head = temp.Prev;
            }
        }
        // Поиск значения максимального элемента.
        public int Max() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            int max = Head.Value;
            int idx = 0;
            DNode currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value > max)
                {
                    max = currentNode.Value;
                    _indexMax = idx;
                }
                currentNode = currentNode.Next;
                idx++;
            }
            return max;
        }
        // Поиск значения минммального элемента.
        public int Min() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            int idx = 0;
            int min = Head.Value;
            DNode currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value < min)
                {
                    min = currentNode.Value;
                    _indexMin = idx;
                }

                currentNode = currentNode.Next;
                idx++;
            }
            return min;
        }
        // Поиск индекса максимального элемента.
        public int IndexOfMax() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            _indexMax = 0;
            Max();
            return _indexMax;
        }
        // Поиск индекса минимального элемента.
        public int IndexOfMin() 
        {
            if (Head == null)
            {
                throw new Exception("Error - Список пуст");
            }
            _indexMin = 0;
            Min();
            return _indexMin;
        }
        DNode Split(DNode head)
        {
            DNode fast = head, slow = head;
            while (fast.Next != null &&
                    fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            DNode temp = slow.Next;
            slow.Next = null;
            return temp;
        }
        public DNode Sort(DNode node)
        {
            if (node == null || node.Next == null)
            {
                return node;
            }
            DNode second = Split(node);

            node = Sort(node);
            second = Sort(second);

            return Merge(node, second);
        }
        public DNode SortDesc(DNode node)
        {
            if (node == null || node.Next == null)
            {
                return node;
            }
            DNode second = Split(node);

            node = SortDesc(node);
            second = SortDesc(second);

            return MergeDesc(node, second);
        }
        DNode Merge(DNode first, DNode second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            if (first.Value < second.Value)
            {
                first.Next = Merge(first.Next, second);
                first.Next.Prev = first;
                first.Prev = null;
                return first;
            }
            else
            {
                second.Next = Merge(first, second.Next);
                second.Next.Prev = second;
                second.Prev = null;
                return second;
            }
        }
        DNode MergeDesc(DNode first, DNode second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }
            if (first.Value > second.Value)
            {
                first.Next = MergeDesc(first.Next, second);
                first.Next.Prev = first;
                first.Prev = null;
                return first;
            }
            else
            {
                second.Next = MergeDesc(first, second.Next);
                second.Next.Prev = second;
                second.Prev = null;
                return second;
            }
        }
        // Вернёт хранимые данные в виде массива.
        public int[] ToArray() 
        {
            int[] newArray = new int[_count];
            DNode newNode = Head;
            int i = 0;

            while (newNode != null)
            {
                newArray[i++] = newNode.Value;
                newNode = newNode.Next;
            }
            return newArray;
        }
        // Вывод списка в консоль.
        public void PrintArrayList()
        {
            int[] array = ToArray();
            Console.WriteLine("\n");
            for (int i = 0; i < _count; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        // Очистка списка.
        public void Clear()
        {
            Head = null;
            Tail = null;
            _count = 0;
            _length = 0;
        }
    }
}
