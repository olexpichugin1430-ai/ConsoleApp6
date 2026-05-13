using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class CustomLinkedList : IEnumerable<int>
    {
        private Node head;

        public int this[int index] // indexator
        {
            get
            {
                Node current = head;
                int currentIndex = 0;

                while (current != null)
                {
                    if (currentIndex == index) return current.Value;
                    current = current.Next;
                    currentIndex++;
                }
                throw new IndexOutOfRangeException("Приятелю, ти вийшов за межі списку!");
            }
        }

        public void Add(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                return;
            }

            Node lastNode = head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }
            lastNode.Next = new Node(value);
        }

        public void InsertAfterSecond(int value)
        {
            if (head == null || head.Next == null) return;

            Node newNode = new Node(value);
            newNode.Next = head.Next.Next;
            head.Next.Next = newNode;
        }

        public void RemoveAt(int position)
        {
            if (head == null || position < 0) return;

            if (position == 0)
            {
                head = head.Next;
                return;
            }

            Node current = head;
            for (int i = 0; current != null && i < position - 1; i++)
            {
                current = current.Next;
            }

            if (current == null || current.Next == null) return;

            current.Next = current.Next.Next;
        }

        public int? FindFirstMultipleOf(int factor)
        {
            foreach (int num in this)
            {
                if (num % factor == 0) return num;
            }
            return null;
        }

        public int CountPositive()
        {
            int count = 0;
            foreach (int num in this)
            {
                if (num > 0) count++;
            }
            return count;
        }

        public CustomLinkedList GetElementsAbove(int limit)
        {
            CustomLinkedList resultList = new CustomLinkedList();
            foreach (int num in this)
            {
                if (num > limit) resultList.Add(num);
            }
            return resultList;
        }

        public void RemoveAboveAverage()
        {
            if (head == null) return;

            double sum = 0;
            int count = 0;
            foreach (int num in this)
            {
                sum += num;
                count++;
            }

            double average = sum / count;

            while (head != null && head.Value > average)
            {
                head = head.Next;
            }

            Node current = head;
            while (current != null && current.Next != null)
            {
                if (current.Next.Value > average)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        public IEnumerator<int> GetEnumerator() // foreach!!!
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}