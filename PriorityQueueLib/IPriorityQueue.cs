using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueueLib
{
    public interface IPriorityQueue<T> where T: IComparable
    {
        void Add(T item);
        T PeekMin();
        T PopMin();
        int Size();
    }
}
