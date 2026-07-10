using System.Security.Cryptography;


/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The size of the queue is = 0
        // Expected Result: The size of the queue should be = 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(2);
        Console.WriteLine(cs);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Adding a new customer using AddNewCustomer method
        // Expected Result: Customer gets successfully added to the back of the queue
        Console.WriteLine("Test 2");
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // Console.WriteLine(cs);
        // Defect(s) Found: 

        // Console.WriteLine("=================");

        // Test 3
        // Scenario: Adding a new customer using AddNewCustomer method
        // Expected Result: Customer gets successfully added to the back of the queue
        Console.WriteLine("Test 3");
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();

        // Defect(s) Found: It let us create additional customer even when queue was fullm we changed > for >=

        Console.WriteLine("=================");


        // Test 4
        // Scenario: Adding a new customer using AddNewCustomer method
        // Expected Result: Customer gets successfully added to the back of the queue
        Console.WriteLine("Test 4");
        // cs.AddNewCustomer();
        // cs.ServeCustomer();
        // cs.AddNewCustomer();
        // cs.ServeCustomer();

        // Defect(s) Found: We got an index out of range error msg System.ArgumentOutOfRangeException when serving a customer
        //To solve this we invert the order of   var customer = _queue[0]; and _queue.RemoveAt(0); quick tip -- the index of the next customer to exit must be reference or save so then it can be removed

        Console.WriteLine("=================");


          // Test 5
        // Scenario: Adding a new customer using AddNewCustomer method
        // Expected Result: Customer gets successfully added to the back of the queue
        Console.WriteLine("Test 5");
        cs.ServeCustomer();

        // Defect(s) Found: No error message was displayed... only a console error of System.ArgumentOutOfRangeException
        //To solve this I wrapped the ServeCustomer into a try catch to handle the System.ArgumentOutOfRangeException

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        try
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
             Console.WriteLine(customer);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Console.WriteLine("Your queue is empty, no elements to dequeue");
        }
        
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}