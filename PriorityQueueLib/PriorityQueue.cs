using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PriorityQueueLib
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T: IComparable
    {
        private const int DEFAULT_CAPACITY = 8;
        private T[] items;
        private int count = 0;

        public PriorityQueue()
        {
            items = new T[DEFAULT_CAPACITY];
        }

        public void Add(T item)
        {
            if (count + 1 >= items.Length)
            {
                DoubleCapacity();
            }
            count++;
            items[count] = item;
            BubbleUp(count);
        }

        public T PeekMin()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            return items[1];
        }

        public T PopMin()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            var result = items[1];
            items[1] = items[count];
            count--;
            Sink(1);
            return result;
        }

        public int Size()
        {
            return count;
        }

        private void DoubleCapacity()
        {
            T[] temp = new T[items.Length * 2];
            for (int i = 1; i < items.Length; i++)
            {
                temp[i] = items[i];
            }
            items = temp;
        }

        private void Sink(int index)
        {
            var leftIndex = 2 * index;
            var rightIndex = 2 * index + 1;
            int minIndex = 0;
            if (leftIndex <= count)
            {
                minIndex = leftIndex;
                if (rightIndex <= count && items[rightIndex].CompareTo(items[leftIndex]) < 0)
                {
                    minIndex = rightIndex;
                }
            }
            if (minIndex == 0)
            {
                return;
            }
            if (items[index].CompareTo(items[minIndex]) > 0)
            {
                Swap(index, minIndex);
                Sink(minIndex);
            }
        }

        private void BubbleUp(int index)
        {
            int parentIndex = index / 2;
            if (parentIndex > 0 && items[index].CompareTo(items[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                BubbleUp(parentIndex);
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
    }
}
