using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.algorithm.Naive_Bayes_classifier
{
    public class MaxHeap
    {
        int sizeOfMaxHeap;
        double[] maxheap;
        int count;
        public MaxHeap(int size) 
        { 
            this.sizeOfMaxHeap = size;
            this.maxheap = new double[size];
        }
        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;
        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = maxheap[firstIndex];
            maxheap[firstIndex] = maxheap[secondIndex];
            maxheap[secondIndex] = temp;
        }
        public void insertElement(double x)
        {
            maxheap[count] = x;
            int i= count;
            while (GetParentIndex(i) >= 0 && maxheap[GetParentIndex(i)]<x)
            {
                Swap(i,GetParentIndex(i));
                i = GetParentIndex(i);
            }
            count++;
        }
        public void removeElement(double x)
        {

        }
    }
}
