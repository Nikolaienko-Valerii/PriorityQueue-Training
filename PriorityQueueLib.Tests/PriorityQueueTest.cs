using System;
using System.Collections.Generic;
using System.Text;
using PriorityQueueLib;
using Xunit;

namespace PriorityQueueLib.Tests
{
    public class PriorityQueueTest
    {
        const int DEFAULT_CAPACITY = 8;

        [Fact]
        public void EmptyCollectionSize()
        {
            // Arrange 
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            // Act


            //Assert
            int size = priorityQueue.Size();
            Assert.Equal(0, size);
        }

        [Fact]
        public void AddSingleItem()
        {
            // Arrange 
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            // Act
            priorityQueue.Add(12);

            //Assert
            int size = priorityQueue.Size();
            Assert.Equal(1, size);
        }

        [Fact]
        public void AddMultiple()
        {
            // Arrange 
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            Random numGenerator = new Random();
            int itemsCount = numGenerator.Next(DEFAULT_CAPACITY + 1, 256);

            // Act
            for (int i = 0; i < itemsCount; i++)
            {
                priorityQueue.Add(numGenerator.Next());
            }

            //Assert
            int size = priorityQueue.Size();
            Assert.Equal(itemsCount, size);
        }

        [Fact]
        public void PeekMinEmpty()
        {
            // Arrange 
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            // Act
            Action act = () => priorityQueue.PeekMin();

            //Assert
            Assert.Throws<InvalidOperationException>(act);
            int size = priorityQueue.Size();
            Assert.Equal(0, size);
        }

        [Fact]
        public void PeekMinNonEmpty()
        {
            // Arrange 
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Add(10);
            priorityQueue.Add(1);
            priorityQueue.Add(1000);
            priorityQueue.Add(100);

            // Act
            int minValue = priorityQueue.PeekMin();

            //Assert
            int size = priorityQueue.Size();
            Assert.Equal(4, size);
            Assert.Equal(1, minValue);
        }

        [Fact]
        public void PopMinEmpty()
        {
            // Arrange 
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            // Act
            Action act = () => priorityQueue.PopMin();

            //Assert
            Assert.Throws<InvalidOperationException>(act);
            int size = priorityQueue.Size();
            Assert.Equal(0, size);
        }

        [Fact]
        public void PopMinNonEmpty()
        {
            // Arrange 
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Add(10);
            priorityQueue.Add(1);
            priorityQueue.Add(1000);
            priorityQueue.Add(100);

            // Act
            int minValue = priorityQueue.PopMin();

            //Assert
            int size = priorityQueue.Size();
            Assert.Equal(3, size);
            Assert.Equal(1, minValue);
        }

        [Fact]
        public void SortingTest()
        {
            // Arrange 
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            Random numGenerator = new Random();
            int[] addedItems = new int[5];
            int[] popedItems = new int[5];

            priorityQueue.Add(4);
            priorityQueue.Add(186);
            priorityQueue.Add(190);
            priorityQueue.Add(231);
            priorityQueue.Add(189);
            addedItems[0] = 4;
            addedItems[1] = 186;
            addedItems[2] = 190;
            addedItems[3] = 231;
            addedItems[4] = 189;

            Array.Sort(addedItems);

            // Act
            for (int i = 0; i < 5; i++)
            {
                popedItems[i] = priorityQueue.PopMin();
            }

            //Assert
            int size = priorityQueue.Size();
            Assert.Equal(0, size);
            Assert.Equal(addedItems, popedItems);
        }
    }
}
