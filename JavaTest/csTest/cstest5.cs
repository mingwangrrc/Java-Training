using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mackenzie.Cam.HumanResources
{
    public class Module4GroupActivityA
    {
        private decimal rateOfPay;
        private double hoursWorked;

        // Events declaration
        /// <summary>
        /// Occurs when the rate the employee is paid changes.
        /// </summary>
        public event EventHandler RateOfPayChanged;

        /// <summary>
        /// Occurs when the number of hours the employee works changes.
        /// </summary>
        public event EventHandler HoursWorkedChanged;

        /// <summary>
        /// Occurs when the employee is paid.
        /// </summary>
        public event EventHandler Paid;

        // "On" methods for events
        /// <summary>
        /// Raises the RateOfPayChange event.
        /// </summary>
        protected virtual void OnRateOfPayChanged()
        {
            if (RateOfPayChanged != null)
            {
                RateOfPayChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the HoursWorkedChanged event.
        /// </summary>
        protected virtual void OnHoursWorkedChanged()
        {
            if (HoursWorkedChanged != null)
            {
                HoursWorkedChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the Paid event.
        /// </summary>
        protected virtual void OnPaid()
        {
            if (Paid != null)
            {
                Paid(this, new EventArgs());
            }
        }

        //Declare and define the “On” methods for each event.
        public decimal RateOfPay
        {
            get
            {
                return this.rateOfPay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }

                if (value != rateOfPay)
                {
                    this.rateOfPay = value;
                    OnRateOfPayChanged();  // Raise the event if the value actually changed
                }
            }
        }

        public double HoursWorked
        {
            get
            {
                return this.hoursWorked;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }

                if (value != hoursWorked)
                {
                    this.hoursWorked = value;
                    OnHoursWorkedChanged();  // Raise the event if the value actually changed
                }
            }
        }

        // Pay() method
        /// <summary>
        /// Returns the amount of money the employee is paid.
        /// </summary>
        public decimal Pay()
        {
            decimal payment = rateOfPay * (decimal)hoursWorked;
            hoursWorked = 0;  // Reset hours worked after payment
            OnPaid();  // Raise the Paid event
            return payment;
        }
    }
}

























using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mackenzie.Cam.HumanResources;

namespace Mackenzie.Cam.RRCHR
{
    public class Module4GroupActivityB
    {
        private decimal rateOfPay;
        private double hoursWorked;

        public string Name
        {
            get;
            set;
        }
        public event EventHandler RateOfPayChanged;
        public event EventHandler HoursWorkedChanged;
        public event EventHandler Paid;

        public Module4GroupActivityB(string name)
        {
            Name = name;

            // Register event handlers
            RateOfPayChanged += HandleRateOfPayChanged;
            HoursWorkedChanged += HandleHoursWorkedChanged;
            Paid += HandlePaid;
        }

        private void HandleRateOfPayChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The rate of pay has changed.");
        }

        private void HandleHoursWorkedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The number of hours worked has changed.");
        }

        private void HandlePaid(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} has been paid.");
        }
    }
}




using System;
using System.Collections.Generic;

namespace Mackenzie.Cam.HumanResources
{
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;

        public string Name { get; set; }

        // Events declaration
        public event EventHandler RateOfPayChanged;
        public event EventHandler HoursWorkedChanged;
        public event EventHandler Paid;

        public Employee(string name)
        {
            Name = name;
        }

        private void HandleRateOfPayChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The rate of pay has changed.");
        }

        private void HandleHoursWorkedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The number of hours worked has changed.");
        }

        private void HandlePaid(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} has been paid.");
        }

        public decimal RateOfPay
        {
            get { return rateOfPay; }
            set
            {
                rateOfPay = value;
                RateOfPayChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set
            {
                hoursWorked = value;
                HoursWorkedChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public decimal Pay()
        {
            decimal payment = RateOfPay * (decimal)hoursWorked;
            hoursWorked = 0;
            Paid?.Invoke(this, EventArgs.Empty);
            return payment;
        }

        public static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee("Hulk Hogan"),
                new Employee("Kevin Nash"),
                new Employee("Scott Hall")
            };

            foreach (var employee in employees)
            {
                employee.RateOfPayChanged += employee.HandleRateOfPayChanged;
                employee.HoursWorkedChanged += employee.HandleHoursWorkedChanged;
                employee.Paid += employee.HandlePaid;
            }

            foreach (var employee in employees)
            {
                employee.RateOfPay += 1.35M;
                employee.Pay();
            }

            var employeeDictionary = new Dictionary<string, Employee>();
            foreach (var employee in employees)
            {
                employeeDictionary[employee.Name] = employee;
            }

            // Set the hours worked for the second employee and pay
            employeeDictionary["Kevin Nash"].HoursWorked = 45;
            employeeDictionary["Kevin Nash"].Pay();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}


The rate of pay has changed.
The number of hours worked has changed.
Hulk Hogan has been paid.
The rate of pay has changed.
The number of hours worked has changed.
Kevin Nash has been paid.
The rate of pay has changed.
The number of hours worked has changed.
Scott Hall has been paid.
The number of hours worked has changed.
The number of hours worked has changed.
Kevin Nash has been paid.
Press any key to continue...

the output should be like this 

using System;
using System.Collections.Generic;

namespace Mackenzie.Cam.HumanResources
{
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;

        public string Name { get; set; }

        // Events declaration
        public event EventHandler RateOfPayChanged;
        public event EventHandler HoursWorkedChanged;
        public event EventHandler Paid;

        public Employee(string name, double initialHours = 0)
        {
            Name = name;
            HoursWorked = initialHours;  // Setting the initial hours worked
        }

        private void HandleRateOfPayChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The rate of pay has changed.");
        }

        private void HandleHoursWorkedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The number of hours worked has changed.");
        }

        private void HandlePaid(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} has been paid.");
        }

        public decimal RateOfPay
        {
            get { return rateOfPay; }
            set
            {
                rateOfPay = value;
                RateOfPayChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set
            {
                hoursWorked = value;
                HoursWorkedChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public decimal Pay()
        {
            decimal payment = RateOfPay * (decimal)hoursWorked;
            Paid?.Invoke(this, EventArgs.Empty);
            return payment;
        }

        public static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee("Hulk Hogan", 10),
                new Employee("Kevin Nash", 8),
                new Employee("Scott Hall", 9)
            };

            foreach (var employee in employees)
            {
                employee.RateOfPayChanged += employee.HandleRateOfPayChanged;
                employee.HoursWorkedChanged += employee.HandleHoursWorkedChanged;
                employee.Paid += employee.HandlePaid;
            }

            foreach (var employee in employees)
            {
                employee.RateOfPay += 1.35M;
                employee.Pay();
            }

            var employeeDictionary = new Dictionary<string, Employee>();
            foreach (var employee in employees)
            {
                employeeDictionary[employee.Name] = employee;
            }

            // Adjust Kevin Nash's hours and pay
            employeeDictionary["Kevin Nash"].HoursWorked += 2;
            employeeDictionary["Kevin Nash"].Pay();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
The program should perform the following tasks:

For each task, code the statements independently of other tasks. The code must be written in the order the tasks are listed below.
Declare and define event handler methods for each of the events within the Employee class. Implement them as follows:
RateOfPayChanged - Print “The rate of pay has changed.” to the console.
HoursWorkedChanged - Print “The number of hours worked has changed.” to the console.
Paid - Print “{name} has been paid.” to the Console, where {name} is the name of the Employee who was paid.
Instantiate three or more instances of the Employee class. Add each instance to a new generic List<T> collection.
Loop through all the Employees in the List. For each iteration, subscribe to all of the object’s events using the event handler methods completed in Step 1.
Code another loop that increases each Employee’s rate of pay by a $1.35 and then Pay them.
Create a new generic Dictionary<K, V> where the key is a string and the value is an Employee. Populate the Dictionary with data from the List. Use the Employee’s name as the key.
Set the hours worked of the second Employee in the Dictionary to a value greater than 40 and then Pay that employee.
Sample Output

The rate of pay has changed.
The number of hours worked has changed.
Hulk Hogan has been paid.
The rate of pay has changed.
The number of hours worked has changed.
Kevin Nash has been paid.
The rate of pay has changed.
The number of hours worked has changed.
Scott Hall has been paid.
The number of hours worked has changed.
The number of hours worked has changed.
Kevin Nash has been paid.
Press any key to continue...

trying to use this format
menuItems.Add("Pizza", 15);
class Program
{
    static void Main(string[] args)
    {
        SortedList menuItems = new SortedList();

        menuItems.Add("Pizza", 15);
        menuItems.Add("Hot Dog", 2);
        menuItems.Add("Noodles", 5);

        Console.WriteLine("Hot dog price: {0:C}", menuItems["Hot Dog"]);

        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine("{0} is {1:C}", menuItems.GetKey(i), menuItems.GetByIndex(i));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mackenzie.Cam.HumanResources
{
    public class Module4GroupActivityA
    {
        private decimal rateOfPay;
        private double hoursWorked;

        // Events declaration
        /// <summary>
        /// Occurs when the rate the employee is paid changes.
        /// </summary>
        public event EventHandler RateOfPayChanged;

        /// <summary>
        /// Occurs when the number of hours the employee works changes.
        /// </summary>
        public event EventHandler HoursWorkedChanged;

        /// <summary>
        /// Occurs when the employee is paid.
        /// </summary>
        public event EventHandler Paid;

        // "On" methods for events
        /// <summary>
        /// Raises the RateOfPayChange event.
        /// </summary>
        protected virtual void OnRateOfPayChanged()
        {
            if (RateOfPayChanged != null)
            {
                RateOfPayChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the HoursWorkedChanged event.
        /// </summary>
        protected virtual void OnHoursWorkedChanged()
        {
            if (HoursWorkedChanged != null)
            {
                HoursWorkedChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the Paid event.
        /// </summary>
        protected virtual void OnPaid()
        {
            if (Paid != null)
            {
                Paid(this, new EventArgs());
            }
        }

        //Declare and define the “On” methods for each event.
        public decimal RateOfPay
        {
            get
            {
                return this.rateOfPay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }

                if (value != rateOfPay)
                {
                    this.rateOfPay = value;
                    OnRateOfPayChanged();  // Raise the event if the value actually changed
                }
            }
        }

        public double HoursWorked
        {
            get
            {
                return this.hoursWorked;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }

                if (value != hoursWorked)
                {
                    this.hoursWorked = value;
                    OnHoursWorkedChanged();  // Raise the event if the value actually changed
                }
            }
        }

        // Pay() method
        /// <summary>
        /// Returns the amount of money the employee is paid.
        /// </summary>
        public decimal Pay()
        {
            decimal payment = rateOfPay * (decimal)hoursWorked;
            hoursWorked = 0;  // Reset hours worked after payment
            OnPaid();  // Raise the Paid event
            return payment;
        }
    }
}
here is the code you need to write base on


using System;
using System.Collections.Generic;

namespace Mackenzie.Cam.HumanResources
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Declare and define event handler methods
            void OnRateOfPayChanged(object sender, EventArgs e)
            {
                Console.WriteLine("The rate of pay has changed.");
            }

            void OnHoursWorkedChanged(object sender, EventArgs e)
            {
                Console.WriteLine("The number of hours worked has changed.");
            }

            void OnPaid(object sender, EventArgs e)
            {
                if (sender is Module4GroupActivityA employee)
                {
                    Console.WriteLine($"{employee.Name} has been paid.");
                }
            }

            // 2. Instantiate three instances & add to List
            List<Module4GroupActivityA> employees = new List<Module4GroupActivityA>
            {
                new Module4GroupActivityA { Name = "Hulk Hogan" },
                new Module4GroupActivityA { Name = "Kevin Nash" },
                new Module4GroupActivityA { Name = "Scott Hall" }
            };

            // 3. Subscribe to events
            foreach (var employee in employees)
            {
                employee.RateOfPayChanged += OnRateOfPayChanged;
                employee.HoursWorkedChanged += OnHoursWorkedChanged;
                employee.Paid += OnPaid;
            }

            // 4. Increase rate of pay and Pay
            foreach (var employee in employees)
            {
                employee.RateOfPay += 1.35M;
                employee.Pay();
            }

            // 5. Create and populate Dictionary
            Dictionary<string, Module4GroupActivityA> employeeDictionary = new Dictionary<string, Module4GroupActivityA>();
            foreach (var employee in employees)
            {
                employeeDictionary.Add(employee.Name, employee);
            }

            // 6. Update second Employee's hours and Pay
            if (employeeDictionary.TryGetValue("Kevin Nash", out var secondEmployee))
            {
                secondEmployee.HoursWorked = 45;
                secondEmployee.Pay();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mackenzie.Cam.HumanResources
{
    public class Module4GroupActivityA
    {
        private decimal rateOfPay;
        private double hoursWorked;

        // Events declaration
        /// <summary>
        /// Occurs when the rate the employee is paid changes.
        /// </summary>
        public event EventHandler RateOfPayChanged;

        /// <summary>
        /// Occurs when the number of hours the employee works changes.
        /// </summary>
        public event EventHandler HoursWorkedChanged;

        /// <summary>
        /// Occurs when the employee is paid.
        /// </summary>
        public event EventHandler Paid;

        // "On" methods for events
        /// <summary>
        /// Raises the RateOfPayChange event.
        /// </summary>
        protected virtual void OnRateOfPayChanged()
        {
            if (RateOfPayChanged != null)
            {
                RateOfPayChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the HoursWorkedChanged event.
        /// </summary>
        protected virtual void OnHoursWorkedChanged()
        {
            if (HoursWorkedChanged != null)
            {
                HoursWorkedChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the Paid event.
        /// </summary>
        protected virtual void OnPaid()
        {
            if (Paid != null)
            {
                Paid(this, new EventArgs());
            }
        }

        //Declare and define the “On” methods for each event.
        public decimal RateOfPay
        {
            get
            {
                return this.rateOfPay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }

                if (value != rateOfPay)
                {
                    this.rateOfPay = value;
                    OnRateOfPayChanged();  // Raise the event if the value actually changed
                }
            }
        }

        public double HoursWorked
        {
            get
            {
                return this.hoursWorked;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }

                if (value != hoursWorked)
                {
                    this.hoursWorked = value;
                    OnHoursWorkedChanged();  // Raise the event if the value actually changed
                }
            }
        }

        // Pay() method
        /// <summary>
        /// Returns the amount of money the employee is paid.
        /// </summary>
        public decimal Pay()
        {
            decimal payment = rateOfPay * (decimal)hoursWorked;
            hoursWorked = 0;  // Reset hours worked after payment
            OnPaid();  // Raise the Paid event
            return payment;
        }
    }
}

















using System;
using System.Collections.Generic;
using Mackenzie.Cam.HumanResources;

namespace GroupLeaderLastName.GroupLeaderFirstName.RRCHR
{
    class Program
    {
        private class NamedEmployee
        {
            public string Name { get; set; }
            public Module4GroupActivityA Employee { get; set; }
        }

        static void Main(string[] args)
        {
            List<NamedEmployee> employees = new List<NamedEmployee>
            {
                new NamedEmployee { Name = "Hulk Hogan", Employee = new Module4GroupActivityA() },
                new NamedEmployee { Name = "Kevin Nash", Employee = new Module4GroupActivityA() },
                new NamedEmployee { Name = "Scott Hall", Employee = new Module4GroupActivityA() }
            };

            // Subscribe to events
            foreach (var emp in employees)
            {
                emp.Employee.RateOfPayChanged += RateOfPayChangedHandler;
                emp.Employee.HoursWorkedChanged += HoursWorkedChangedHandler;
                emp.Employee.Paid += (sender, e) => { Console.WriteLine(emp.Name + " has been paid."); };
            }

            // Increase rate of pay and pay them
            foreach (var emp in employees)
            {
                emp.Employee.RateOfPay += 1.35M;
                emp.Employee.Pay();
            }

            // Create a dictionary
            Dictionary<string, Module4GroupActivityA> employeeDict = new Dictionary<string, Module4GroupActivityA>();
            foreach (var emp in employees)
            {
                employeeDict[emp.Name] = emp.Employee;
            }

            // Set hours worked and pay
            if (employeeDict.ContainsKey("Kevin Nash"))
            {
                employeeDict["Kevin Nash"].HoursWorked = 45;
                employeeDict["Kevin Nash"].Pay();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void RateOfPayChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The rate of pay has changed.");
        }

        static void HoursWorkedChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The number of hours worked has changed.");
        }
    }
}





using System;
using System.Collections.Generic;
using Mackenzie.Cam.HumanResources;

namespace GroupLeaderLastName.GroupLeaderFirstName.RRCHR
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Module4GroupActivityA> employees = new List<Module4GroupActivityA>();

            // Instantiate three or more instances of the Employee class.
            Module4GroupActivityA hulk = new Module4GroupActivityA { Name = "Hulk Hogan" };
            Module4GroupActivityA kevin = new Module4GroupActivityA { Name = "Kevin Nash" };
            Module4GroupActivityA scott = new Module4GroupActivityA { Name = "Scott Hall" };

            employees.Add(hulk);
            employees.Add(kevin);
            employees.Add(scott);

            // Subscribe to events
            foreach (var emp in employees)
            {
                emp.RateOfPayChanged += RateOfPayChangedHandler;
                emp.HoursWorkedChanged += HoursWorkedChangedHandler;
                emp.Paid += (sender, e) => Console.WriteLine($"{((Module4GroupActivityA)sender).Name} has been paid.");
            }

            // Code another loop that increases each Employee’s rate of pay by a $1.35 and then Pay them.
            foreach (var emp in employees)
            {
                emp.RateOfPay += 1.35M;
                emp.Pay();
            }

            // Create a dictionary
            Dictionary<string, Module4GroupActivityA> employeeDict = new Dictionary<string, Module4GroupActivityA>();

            foreach (var emp in employees)
            {
                employeeDict[emp.Name] = emp;
            }

            // Set the hours worked of the second Employee in the Dictionary to a value greater than 40 and then Pay that employee.
            if (employeeDict.ContainsKey("Kevin Nash"))
            {
                employeeDict["Kevin Nash"].HoursWorked = 45;
                employeeDict["Kevin Nash"].Pay();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void RateOfPayChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The rate of pay has changed.");
        }

        static void HoursWorkedChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The number of hours worked has changed.");
        }
    }
}


do not using  =>




using System;
using System.Collections.Generic;
using Mackenzie.Cam.HumanResources;

namespace Mackenzie.Cam.RRCHR
{
    class Module4GroupActivityB
    {
        static void Main(string[] args)
        {
            List<Module4GroupActivityA> employees = new List<Module4GroupActivityA>();

            // Instantiate three or more instances of the Employee class.
            Module4GroupActivityA hulk = new Module4GroupActivityA { Name = "Hulk Hogan" };
            Module4GroupActivityA kevin = new Module4GroupActivityA { Name = "Kevin Nash" };
            Module4GroupActivityA scott = new Module4GroupActivityA { Name = "Scott Hall" };

            employees.Add(hulk);
            employees.Add(kevin);
            employees.Add(scott);

            // Subscribe to events
            foreach (var emp in employees)
            {
                emp.RateOfPayChanged += RateOfPayChangedHandler;
                emp.HoursWorkedChanged += HoursWorkedChangedHandler;
                emp.Paid += PaidHandler;
            }

            // Code another loop that increases each Employee’s rate of pay by a $1.35 and then Pay them.
            foreach (var emp in employees)
            {
                emp.RateOfPay += 1.35M;
                emp.Pay();
            }

            // Create a dictionary
            Dictionary<string, Module4GroupActivityA> employeeDict = new Dictionary<string, Module4GroupActivityA>();

            foreach (var emp in employees)
            {
                employeeDict[emp.Name] = emp;
            }

            // Set the hours worked of the second Employee in the Dictionary to a value greater than 40 and then Pay that employee.
            if (employeeDict.ContainsKey("Kevin Nash"))
            {
                employeeDict["Kevin Nash"].HoursWorked = 45;
                employeeDict["Kevin Nash"].Pay();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void RateOfPayChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The rate of pay has changed.");
        }

        static void HoursWorkedChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The number of hours worked has changed.");
        }

        static void PaidHandler(object sender, EventArgs e)
        {
            Module4GroupActivityA employee = sender as Module4GroupActivityA;
            if (employee != null)
            {
                Console.WriteLine(employee.Name + " has been paid.");
            }
        }
    }
}



















using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mackenzie.Cam.HumanResources
{
    public class Module4GroupActivityA
    {
        private decimal rateOfPay;
        private double hoursWorked;

        // Events declaration
        /// <summary>
        /// Occurs when the rate the employee is paid changes.
        /// </summary>
        public event EventHandler RateOfPayChanged;

        /// <summary>
        /// Occurs when the number of hours the employee works changes.
        /// </summary>
        public event EventHandler HoursWorkedChanged;

        /// <summary>
        /// Occurs when the employee is paid.
        /// </summary>
        public event EventHandler Paid;

        // "On" methods for events
        /// <summary>
        /// Raises the RateOfPayChange event.
        /// </summary>
        protected virtual void OnRateOfPayChanged()
        {
            if (RateOfPayChanged != null)
            {
                RateOfPayChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the HoursWorkedChanged event.
        /// </summary>
        protected virtual void OnHoursWorkedChanged()
        {
            if (HoursWorkedChanged != null)
            {
                HoursWorkedChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the Paid event.
        /// </summary>
        protected virtual void OnPaid()
        {
            if (Paid != null)
            {
                Paid(this, new EventArgs());
            }
        }

        //Declare and define the “On” methods for each event.
        public decimal RateOfPay
        {
            get
            {
                return this.rateOfPay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }

                if (value != rateOfPay)
                {
                    this.rateOfPay = value;
                    OnRateOfPayChanged();  // Raise the event if the value actually changed
                }
            }
        }

        public double HoursWorked
        {
            get
            {
                return this.hoursWorked;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }

                if (value != hoursWorked)
                {
                    this.hoursWorked = value;
                    OnHoursWorkedChanged();  // Raise the event if the value actually changed
                }
            }
        }

        // Pay() method
        /// <summary>
        /// Returns the amount of money the employee is paid.
        /// </summary>
        public decimal Pay()
        {
            decimal payment = rateOfPay * (decimal)hoursWorked;
            hoursWorked = 0;  // Reset hours worked after payment
            OnPaid();  // Raise the Paid event
            return payment;
        }
    }
}

check if its meet the requiremnts:
Declare Events
+ <<event>> RateOfPayChanged : EventHandler - Occurs when the rate the employee is paid changes.
+ <<event>> HoursWorkedChanged : EventHandler - Occurs when the number of hours the employee works changes.
+ <<event>> Paid : EventHandler - Occurs when the employee is paid.
Define “On” Methods
Declare and define the “On” methods for each event.

Add a Method
+ Pay() : decimal - Return the amount of money the employee is paid. The employee is paid using the formula: rate of pay multiplied by the number of hours the employee worked. After calculating the amount the employee is paid, the employee’s hours are set to zero.
Raise the Events
Add the necessary code to raise each of the events.

“Changed” events should only be raised when the state actually changes. If the value of the current state is equal to the value it is being set to, the event will not be raised.


here is the source code for employee.class
using System;

namespace ADEV.ACE.RRC.HumanResources
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;

        /// <summary>
        /// Gets and sets the amount of money paid to the employee per pay rate frequency. 
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when the RateOfPay is set to a value less than zero. 
        /// </exception>
        public decimal RateOfPay
        {
            get
            {
                return this.rateOfPay;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");

                this.rateOfPay = value;
            }
        }

        /// <summary>
        /// Gets and sets the amount of hours the employee worked during the pay period. 
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when the HoursWorked is set to a value less than zero or a value than 100. 
        /// </exception>
        public double HoursWorked
        {
            get
            {
                return this.hoursWorked;
            }

            set
            {
                if(value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("value", "The value must between zero and 100 (inclusive).");

                this.hoursWorked = value;
            }
        }

        /// <summary>
        /// Gets the employee’s full name. 
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of the Employee class with a specified rate of pay, hours worked and name.  
        /// </summary>
        /// <param name="rateOfPay">The amount of money paid to the employee per pay rate frequency.</param>
        /// <param name="hoursWorked">The number of hours the employee worked during the pay period.</param>
        /// <param name="name">The employee's full name.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when the rate of pay parameter is set to a value less than zero or 
        /// the hours worked parameter is set to a value less than zero or a value than 100.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the name parameter is set to a string with no characters (whitespace characters are trimmed).
        /// </exception>
        public Employee(decimal rateOfPay, double hoursWorked, string name)
        {
            if(rateOfPay < 0)
                throw new ArgumentOutOfRangeException("rateOfPay", "The argument value must be zero or greater.");

            if(hoursWorked < 0 || hoursWorked > 100)
                throw new ArgumentOutOfRangeException("hoursWorked", "The argument value must between zero and 100 (inclusive).");

            if (name.Trim().Equals(string.Empty))
                throw new ArgumentException("The argument must contain at least one character.", "name");

            this.rateOfPay = rateOfPay;
            this.hoursWorked = hoursWorked;
            this.Name = name;
        }

        /// <summary>
        /// Returns the string representation of the Employee.
        /// </summary>
        /// <returns>The string representation of the Employee.</returns>
        public override string ToString()
        {
            return String.Format("{0} -- {1:C} :: {2}",
                                 this.Name,
                                 this.RateOfPay,
                                 this.HoursWorked);
        }
    }
}









Let's go through the provided code to see if it meets the requirements:

Declare Events
RateOfPayChanged: ✅ Declared and described with the comment: "Occurs when the rate the employee is paid changes."
HoursWorkedChanged: ✅ Declared and described with the comment: "Occurs when the number of hours the employee works changes."
Paid: ✅ Declared and described with the comment: "Occurs when the employee is paid."
Define “On” Methods
OnRateOfPayChanged: ✅ Defined and raises the RateOfPayChanged event when called.
OnHoursWorkedChanged: ✅ Defined and raises the HoursWorkedChanged event when called.
OnPaid: ✅ Defined and raises the Paid event when called.
Add a Method
Pay(): ✅ Defined. This method returns the calculated pay and resets hoursWorked to zero after calculating.
Raise the Events
RateOfPayChanged: ✅ Raised in the setter of the RateOfPay property if the value actually changed.
HoursWorkedChanged: ✅ Raised in the setter of the HoursWorked property if the value actually changed.
Paid: ✅ Raised in the Pay() method.
“Changed” events should only be raised when the state actually changes.
This is correctly implemented. Events are raised only if the current value is different from the set value.
The provided Module4GroupActivityA class seems to meet all the specified requirements.

As for the Employee class, it's a well-structured representation of an employee but doesn't contain any event handling. If you wish to integrate the event handling mechanism of Module4GroupActivityA into the Employee class, you would need to adapt and merge their functionalities accordingly. If that's something you'd like to do, let me know, and I can assist further!



remember this events:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mackenzie.Cam.HumanResources
{
    public class Module4GroupActivityA
    {
        private decimal rateOfPay;
        private double hoursWorked;

        // Events declaration
        /// <summary>
        /// Occurs when the rate the employee is paid changes.
        /// </summary>
        public event EventHandler RateOfPayChanged;

        /// <summary>
        /// Occurs when the number of hours the employee works changes.
        /// </summary>
        public event EventHandler HoursWorkedChanged;

        /// <summary>
        /// Occurs when the employee is paid.
        /// </summary>
        public event EventHandler Paid;

        // "On" methods for events
        /// <summary>
        /// Raises the RateOfPayChange event.
        /// </summary>
        protected virtual void OnRateOfPayChanged()
        {
            if (RateOfPayChanged != null)
            {
                RateOfPayChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the HoursWorkedChanged event.
        /// </summary>
        protected virtual void OnHoursWorkedChanged()
        {
            if (HoursWorkedChanged != null)
            {
                HoursWorkedChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the Paid event.
        /// </summary>
        protected virtual void OnPaid()
        {
            if (Paid != null)
            {
                Paid(this, new EventArgs());
            }
        }

        //Declare and define the “On” methods for each event.
        public decimal RateOfPay
        {
            get
            {
                return this.rateOfPay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }

                if (value != rateOfPay)
                {
                    this.rateOfPay = value;
                    OnRateOfPayChanged();  // Raise the event if the value actually changed
                }
            }
        }

        public double HoursWorked
        {
            get
            {
                return this.hoursWorked;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }

                if (value != hoursWorked)
                {
                    this.hoursWorked = value;
                    OnHoursWorkedChanged();  // Raise the event if the value actually changed
                }
            }
        }

        // Pay() method
        /// <summary>
        /// Returns the amount of money the employee is paid.
        /// </summary>
        public decimal Pay()
        {
            decimal payment = rateOfPay * (decimal)hoursWorked;
            hoursWorked = 0;  // Reset hours worked after payment
            OnPaid();  // Raise the Paid event
            return payment;
        }

        public string Name
        {
            get;
            set;
        }
    }
}

now you are going to 

Part B

Create a new Console App (.NET Framework) Visual Studio Project. Name the Visual Studio Project GroupLeaderLastName.GroupLeaderFirstName.RRCHR.

Example: Omega.Kenny.RRCHR.

Name the Visual Studio Solution Module4GroupActivityB.

The Program class will be declared within the GroupLeaderLastName.GroupLeaderFirstName.RRCHR namespace. DO NOT change this.

Next, copy the successfully built .dll created in Part A to the bin\debug directory within the Part B project. Add a reference to the .dll in Visual Studio.

The program should perform the following tasks:

For each task, code the statements independently of other tasks. The code must be written in the order the tasks are listed below.
Declare and define event handler methods for each of the events within the Employee class. Implement them as follows:
RateOfPayChanged - Print “The rate of pay has changed.” to the console.
HoursWorkedChanged - Print “The number of hours worked has changed.” to the console.
Paid - Print “{name} has been paid.” to the Console, where {name} is the name of the Employee who was paid.
Instantiate three or more instances of the Employee class. Add each instance to a new generic List<T> collection.
Loop through all the Employees in the List. For each iteration, subscribe to all of the object’s events using the event handler methods completed in Step 1.
Code another loop that increases each Employee’s rate of pay by a $1.35 and then Pay them.
Create a new generic Dictionary<K, V> where the key is a string and the value is an Employee. Populate the Dictionary with data from the List. Use the Employee’s name as the key.
Set the hours worked of the second Employee in the Dictionary to a value greater than 40 and then Pay that employee.
Sample Output

The rate of pay has changed.
The number of hours worked has changed.
Hulk Hogan has been paid.
The rate of pay has changed.
The number of hours worked has changed.
Kevin Nash has been paid.
The rate of pay has changed.
The number of hours worked has changed.
Scott Hall has been paid.
The number of hours worked has changed.
The number of hours worked has changed.
Kevin Nash has been paid.
Press any key to continue...



using System;
using System.Collections.Generic;
using Mackenzie.Cam.HumanResources;

namespace GroupLeaderLastName.GroupLeaderFirstName.RRCHR
{
    class Program
    {
        private class NamedEmployee
        {
            public string Name { get; set; }
            public Module4GroupActivityA Employee { get; set; }
        }

        static void Main(string[] args)
        {
            List<NamedEmployee> employees = new List<NamedEmployee>
            {
                new NamedEmployee { Name = "Hulk Hogan", Employee = new Module4GroupActivityA() },
                new NamedEmployee { Name = "Kevin Nash", Employee = new Module4GroupActivityA() },
                new NamedEmployee { Name = "Scott Hall", Employee = new Module4GroupActivityA() }
            };
            // Subscribe to events
            foreach (var emp in employees)
            {
                emp.Employee.RateOfPayChanged += RateOfPayChangedHandler;
                emp.Employee.HoursWorkedChanged += HoursWorkedChangedHandler;
                emp.Employee.Paid += PaidHandler(emp.Name);
            }

            // Increase rate of pay and pay them
            foreach (var emp in employees)
            {
                emp.Employee.RateOfPay += 1.35M;
                emp.Employee.Pay();
            }

            // Create a dictionary
            Dictionary<string, Module4GroupActivityA> employeeDict = new Dictionary<string, Module4GroupActivityA>();
            foreach (var emp in employees)
            {
                employeeDict[emp.Name] = emp.Employee;
            }

            // Set hours worked and pay
            if (employeeDict.ContainsKey("Kevin Nash"))
            {
                employeeDict["Kevin Nash"].HoursWorked = 45;
                employeeDict["Kevin Nash"].Pay();
            }

            if (employeeDict.ContainsKey("Hulk Hogan"))
            {
                employeeDict["Hulk Hogan"].HoursWorked = 45;
                employeeDict["Hulk Hogan"].Pay();
            }

            if (employeeDict.ContainsKey("Scott Hall"))
            {
                employeeDict["Scott Hall"].HoursWorked = 45;
                employeeDict["Scott Hall"].Pay();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void RateOfPayChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The rate of pay has changed.");
        }

        static void HoursWorkedChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The number of hours worked has changed.");
        }

        static EventHandler PaidHandler(string employeeName)
        {
            return delegate (object sender, EventArgs e)
            {
                Console.WriteLine(employeeName + " has been paid.");
            };
        }
    }
}