using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.algorithm.Naive_Bayes_classifier
{
    public class PriorityQueue<T>
    {
        private List<T> _heap;
        private readonly IComparer<T> _comparer;

        public PriorityQueue() : this(null) { }

        public PriorityQueue(IComparer<T> comparer)
        {
            _heap = new List<T>();
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public PriorityQueue(int capacity) : this(capacity, null) { }

        public PriorityQueue(int capacity, IComparer<T> comparer)
        {
            _heap = new List<T>(capacity);
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public int Count
        {
            get { return _heap.Count; }
        }

        public void Enqueue(T item)
        {
            _heap.Add(item);
            int childIndex = _heap.Count - 1;

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;

                if (_comparer.Compare(_heap[childIndex], _heap[parentIndex]) > 0)
                {
                    Swap(childIndex, parentIndex);
                    childIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public T Dequeue()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The priority queue is empty.");
            }

            int lastIndex = _heap.Count - 1;
            T firstItem = _heap[0];
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            lastIndex--;
            int parentIndex = 0;

            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1;
                int rightChildIndex = parentIndex * 2 + 2;

                if (leftChildIndex > lastIndex)
                {
                    break;
                }

                int compareIndex = leftChildIndex;

                if (rightChildIndex <= lastIndex && _comparer.Compare(_heap[rightChildIndex], _heap[leftChildIndex]) > 0)
                {
                    compareIndex = rightChildIndex;
                }

                if (_comparer.Compare(_heap[compareIndex], _heap[parentIndex]) > 0)
                {
                    Swap(compareIndex, parentIndex);
                    parentIndex = compareIndex;
                }
                else
                {
                    break;
                }
            }

            return firstItem;
        }

        public T Peek()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The priority queue is empty.");
            }

            return _heap[0];
        }

        public void Clear()
        {
            _heap.Clear();
        }

        public T[] ToArray()
        {
            return _heap.ToArray();
        }

        private void Swap(int index1, int index2)
        {
            T temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }
    }
}
