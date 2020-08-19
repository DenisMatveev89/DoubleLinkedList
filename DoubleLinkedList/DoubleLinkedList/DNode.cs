using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList
{
    public class DNode
    {
        public DNode() { }
        public DNode(int value)
        {
            Value = value;
        }

        public int Value;
        public DNode Prev, Next;
    }
}
