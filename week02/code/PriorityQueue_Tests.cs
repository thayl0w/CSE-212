using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueueing an item with High priority and then Dequeuing.
    // Expected Result: The item with High priority should be dequeued first.
    // Defect(s) Found: The priority queue should correctly prioritize High priority items.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Medium Priority", 2);
        priorityQueue.Enqueue("High Priority", 1);
        var dequeuedItem = priorityQueue.Dequeue();
        Assert.AreEqual("High Priority", dequeuedItem);
    }

    [TestMethod]
    // Scenario: Trying to dequeue from an empty priority queue.
    // Expected Result: The exception should indicate that the queue is empty.
    // Defect(s) Found: The exception message does not match the expected one.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority, then dequeue.
    // Expected Result: The first enqueued item with the highest priority is dequeued (FIFO for ties).
    // Defect(s) Found: If not FIFO, the test will fail.
    public void TestPriorityQueue_FIFOForTies()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First High", 1);
        priorityQueue.Enqueue("Second High", 1);
        priorityQueue.Enqueue("Third High", 1);

        Assert.AreEqual("First High", priorityQueue.Dequeue());
        Assert.AreEqual("Second High", priorityQueue.Dequeue());
        Assert.AreEqual("Third High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with different priorities, then dequeue all.
    // Expected Result: Items are dequeued in order of highest priority first, then next, etc.
    // Defect(s) Found: If not in correct priority order, the test will fail.
    public void TestPriorityQueue_PriorityOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 3);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High", 1);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with increasing priorities, then dequeue all.
    // Expected Result: Items are dequeued from highest to lowest priority.
    // Defect(s) Found: If not in correct order, the test will fail.
    public void TestPriorityQueue_EnqueueOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);
        priorityQueue.Enqueue("E", 1);

        Assert.AreEqual("E", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}