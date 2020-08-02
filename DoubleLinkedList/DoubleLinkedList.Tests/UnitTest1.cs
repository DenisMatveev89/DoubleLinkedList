using NUnit.Framework;
using System;

namespace DoubleLinkedList.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(5, new int[] { 5, 5 })]
        [TestCase(0, new int[] { 0, 0 })]
        public void AddLastTest(int a, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();

            DlList.AddLast(a);
            DlList.AddLast(a);
            int[] actual = DlList.ToArray();
            Assert.AreEqual(ex, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 5, 6, 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 5, 6, 0, 0, 0, 0 })]
        public void AddLastTest(int[] a, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();

            DlList.AddLast(5);
            DlList.AddLast(6);
            DlList.AddLast(a);
            int[] actual = DlList.ToArray();
            Assert.AreEqual(ex, actual);

        }

        [TestCase(15, new int[] { 15, 5, 6 })]
        [TestCase(0, new int[] { 0, 5, 6 })]
        public void AddFirstTest(int a, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();

            DlList.AddLast(5);
            DlList.AddLast(6);
            DlList.AddFirst(a);
            int[] actual = DlList.ToArray();
            Assert.AreEqual(ex, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 5, 6 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 5, 6 })]
        public void AddFirstTest(int[] a, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();

            DlList.AddLast(5);
            DlList.AddLast(6);
            DlList.AddFirst(a);
            int[] actual = DlList.ToArray();
            Assert.AreEqual(ex, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 25, new int[] { 1, 25, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 25, new int[] { 1, 2, 3, 4, 25, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 25, new int[] { 1, 2, 3, 4, 5, 25 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 25, new int[] { 25, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 25, new int[] { 1, 2, 25, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 25, new int[] { 1, 2, 3, 25, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -3, 25, new int[] { 1, 2, 3, 4, 5 })]
        public void AddAtTest(int[] array, int idx, int val, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (idx < 0 || idx > array.Length)
            {
                Assert.Throws<Exception>(() => DlList.AddAt(idx, val));
            }
            else
            {

                DlList.AddLast(array);
                DlList.AddAt(idx, val);

                int[] actual = DlList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 2, 3, 4, }, new int[] { 1, 1, 2, 3, 4, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 1, 2, 3, 4, }, new int[] { 1, 2, 3, 4, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -5, new int[] { 1, 2, 3, 4, }, new int[] { 1, 2, 3, 4, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 15, new int[] { 1, 2, 3, 4, }, new int[] { 1, 2, 3, 4, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2, 3, 4, }, new int[] { 1, 2, 3, 1, 2, 3, 4, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4, }, new int[] { 1, 2, 3, 4, 1, 2, 3, 4, 5 })]
        public void AddAtTest(int[] array, int idx, int[] values, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (idx < 0 || idx > array.Length)
            {
                Assert.Throws<Exception>(() => DlList.AddAt(idx, values));
            }
            else
            {

                DlList.AddLast(array);
                DlList.AddAt(idx, values);

                int[] actual = DlList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 25, new int[] { 1, 25, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 25, new int[] { 25, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 25, new int[] { 1, 2, 3, 4, 25 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 25, new int[] { 1, 2, 3, 25, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -4, 25, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 25, 25, new int[] { })]

        public void SetTest(int[] array, int idx, int value, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (idx < 0 || idx > array.Length)
            {
                Assert.Throws<Exception>(() => DlList.Set(idx, value));
            }
            else
            {

                DlList.AddLast(array);
                DlList.Set(idx, value);

                int[] actual = DlList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]

        public void RemoveFirstTest(int[] array, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length <= 1)
            {
                Assert.Throws<Exception>(() => DlList.RemoveFirst());
            }
            else
            {

                DlList.AddLast(array);
                DlList.RemoveFirst();

                int[] actual = DlList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]

        public void RemoveLastTest(int[] array, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length <= 1)
            {
                Assert.Throws<Exception>(() => DlList.RemoveLast());
            }
            else
            {

                DlList.AddLast(array);
                DlList.RemoveLast();

                int[] actual = DlList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { })]


        public void RemoveAtTest(int[] array, int index, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (index < 0 || index > array.Length - 1)
            {
                Assert.Throws<Exception>(() => DlList.RemoveAt(index));
            }
            else
            {

                DlList.AddLast(array);
                DlList.RemoveAt(index);

                int[] actual = DlList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 2, 4, 5 }, 2, new int[] { 1, 4, 5 })]
        [TestCase(new int[] { 1, 2, 2, 4, 1, 5 }, 1, new int[] { 2, 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 2, 4, 1, 1 }, 1, new int[] { 2, 2, 4 })]
        [TestCase(new int[] { 1, 2, 2, 4, 1, 1 }, 0, new int[] { 1, 2, 2, 4, 1, 1 })]
        [TestCase(new int[] { }, 2, new int[] { })]


        public void RemoveAllTest(int[] array, int value, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => DlList.RemoveAll(value));
            }
            else
            {
                DlList.AddLast(array);
                DlList.RemoveAll(value);
                int[] actual = DlList.ToArray();
                Assert.AreEqual(ex, actual);
            }
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, true)]
        [TestCase(new int[] { }, 0, false)]
        public void ContainsTest(int[] array, int val, bool ex)
        {
            DoubleLinkedList dList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                bool actual = false;
            }
            else
            {
                dList.AddLast(array);
                bool actual = dList.Contains(val);
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7 }, 7, 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7 }, 25, -1)]
        [TestCase(new int[] { }, 7, null)]
        public void IndexOfTest(int[] array, int val, int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => DlList.IndexOf(val));
            }
            else
            {
                DlList.AddLast(array);
                int actual = DlList.IndexOf(val);
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, 1)]
        [TestCase(new int[] { 2, 3, 4, 5, 7 }, 2)]
        [TestCase(new int[] { 7 }, 7)]
        [TestCase(new int[] { }, null)]
        public void GetFirstTest(int[] array, int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => DlList.GetFirst());
            }
            else
            {
                DlList.AddLast(array);
                int actual = DlList.GetFirst();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, 7)]
        [TestCase(new int[] { 2, 3, 4, 5, 7 }, 7)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 2, 3 }, 3)]
        [TestCase(new int[] { 7 }, 7)]
        [TestCase(new int[] { }, null)]
        public void GetLastTest(int[] array, int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => DlList.GetLast());
            }
            else
            {
                DlList.AddLast(array);
                int actual = DlList.GetLast();
                Assert.AreEqual(ex, actual);
            }
        }

        [TestCase(100000)]
        public void GetSizeTest(int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();



            for (int i = 0; i < 100000; i++)
            {
                DlList.AddLast(i);
            }
            int actual = DlList.GetSize();
            Assert.AreEqual(ex, actual);

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5, 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 15, 0)]
        [TestCase(new int[] { }, 5, 0)]
        public void GetTest(int[] array, int idx, int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0 || idx < 0 || idx > array.Length)
            {
                Assert.Throws<Exception>(() => DlList.Get(idx));
            }
            else
            {
                DlList.AddLast(array);
                int actual = DlList.Get(idx);
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        public void ReverseTest(int[] a, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            DlList.AddLast(a);
            DlList.Reverse();
            int[] actual = DlList.ToArray();
            Assert.AreEqual(ex, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 8, 6, 7 }, 8)]
        [TestCase(new int[] { 8, 2, 3, 4, 6, 7 }, 8)]
        [TestCase(new int[] { }, 0)]
        public void MaxTest(int[] array, int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => DlList.Max());
            }
            else
            {
                DlList.AddLast(array);
                int actual = DlList.Max();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)]
        [TestCase(new int[] { 8, 2, 3, 4, 8, 6, 1 }, 1)]
        [TestCase(new int[] { 8, 2, 3, 4, 6, 7 }, 2)]
        [TestCase(new int[] { }, 0)]
        public void MinTest(int[] array, int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => DlList.Min());
            }
            else
            {
                DlList.AddLast(array);
                int actual = DlList.Min();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        [TestCase(new int[] { 8, 2, 3, 4, 8, 6, 1 }, 0)]
        [TestCase(new int[] { 1, 2, 8, 4, 6, 7 }, 2)]
        [TestCase(new int[] { 1, 2, 8, 10, 6, 7 }, 3)]
        [TestCase(new int[] { }, 0)]
        public void IndexOfMaxTest(int[] array, int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => DlList.IndexOfMax());
            }
            else
            {
                DlList.AddLast(array);
                int actual = DlList.IndexOfMax();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(new int[] { 8, 2, 3, 4, 8, 6, 1 }, 6)]
        [TestCase(new int[] { 1, 2, 8, 4, 6, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 8, 10, 6, 7 }, 0)]
        [TestCase(new int[] { }, 0)]
        public void IndexOfMinTest(int[] array, int ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();
            if (array.Length == 0)
            {
                Assert.Throws<Exception>(() => DlList.IndexOfMin());
            }
            else
            {
                DlList.AddLast(array);
                int actual = DlList.IndexOfMin();
                Assert.AreEqual(ex, actual);
            }
        }
        [TestCase(new int[] { 1, 2, 8, 10, 6, 7 }, new int[] { 1, 2, 6, 7, 8, 10 })]
        [TestCase(new int[] { 6, 6, 32, 2, 56, 8, 0, 1, 23, 34, 56, 89 }, new int[] { 0, 1, 2, 6, 6, 8, 23, 32, 34, 56, 56, 89 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortTest(int[] array, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();

            DlList.AddLast(array);
            DlList.Head = DlList.Sort(DlList.Head);
            int[] actual = DlList.ToArray();
            Assert.AreEqual(ex, actual);

        }
        [TestCase(new int[] { 1, 2, 8, 10, 6, 7 }, new int[] { 10, 8, 7, 6, 2, 1 })]
        [TestCase(new int[] { 6, 6, 32, 2, 56, 8, 0, 1, 23, 34, 56, 89 }, new int[] { 89, 56, 56, 34, 32, 23, 8, 6, 6, 2, 1, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortDescTest(int[] array, int[] ex)
        {
            DoubleLinkedList DlList = new DoubleLinkedList();

            DlList.AddLast(array);
            DlList.Head = DlList.SortDesc(DlList.Head);
            int[] actual = DlList.ToArray();
            Assert.AreEqual(ex, actual);

        }
    }
}