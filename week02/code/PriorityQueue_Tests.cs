using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add new items to the queue and make sure there are placed at the end of it 
    // Expected Result: Queue shall contain the items by order
    // Defect(s) Found: 
    //Test Result: Passed! Items are queued at the end of the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("item1", 5);
        priorityQueue.Enqueue("item2", 4);
        priorityQueue.Enqueue("item3", 3);
        var expectedQueue = "[item1 (Pri:5), item2 (Pri:4), item3 (Pri:3)]";
        Assert.AreEqual(expectedQueue, priorityQueue.ToString());
        
    }

    [TestMethod]
    // Scenario: Given the following queue of items [item1 (Pri:5), item2 (Pri:7), item3 (Pri:1)] the one with highest priority is removed
    // Expected Result: item2 (Pri:7) should be dequeue firts leaving the queue like this [item1 (Pri:5), item3 (Pri:1)]
    // Defect(s) Found: Error de Assert.AreEqual. Se esperaba <[item1 (Pri:5), item3 (Pri:1)]>, pero es <[item1 (Pri:5), item2 (Pri:7), item3 (Pri:1)]>.
    //Test Results: Passed! I implemented a fix for the defect found so the hight priority item was removed from the queue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("item1", 5);
        priorityQueue.Enqueue("item2", 7);
        priorityQueue.Enqueue("item3", 1);
        var dequeuedItem = priorityQueue.Dequeue();
        var expectDequeuedItem = "item2";
        var expectedQueue = "[item1 (Pri:5), item3 (Pri:1)]";
        Assert.AreEqual(expectDequeuedItem, dequeuedItem);
        Assert.AreEqual(expectedQueue, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Given the following queue of items [item1 (Pri:1), item2 (Pri:4), item3 (Pri:4)] where 2 items have the same priority, the first toward the start of the queue is removed
    // Expected Result: item2 (Pri:4) should be dequeue firts leaving the queue like this [item1 (Pri:1), item3 (Pri:4)]
    // Defect(s) Found:  Error de Assert.AreEqual. Se esperaba <item3>, pero es <item2>.
    //Error de Assert.AreEqual. Se esperaba <item2>, pero es <item3>
    //Test Result: Passed! I implemented a fix in the code so it evaluates all items in the queue but only removes the closest to the front
    //if there are more than 1 with same high priority
    public void TestPriorityQueue_3()
    {
        
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("item1", 1);
        priorityQueue.Enqueue("item2", 4);
        priorityQueue.Enqueue("item3", 4);
        var dequeuedItem = priorityQueue.Dequeue();
        var expectDequeuedItem = "item2";
        var expectedQueue = "[item1 (Pri:1), item3 (Pri:4)]";
        Assert.AreEqual(expectDequeuedItem, dequeuedItem);
        Assert.AreEqual(expectedQueue, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: User attemtps to dequeue an item from an empty list
    // Expected Result: Exception error is returned with the message of "The queue is empty."
    // Defect(s) Found: 
    //Test Result: An exception with the expected msg was returned.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
         catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }     
    }
}