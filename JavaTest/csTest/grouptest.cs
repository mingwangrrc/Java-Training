using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.HumanResources
{
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;
        private readonly string name;

        public Employee(decimal rateOfPay, double hoursWorked, string name)
        {
            this.rateOfPay = rateOfPay;
            this.hoursWorked = hoursWorked;
            this.name = name.Trim();
        }

        
        public decimal RateOfPay
        {
            get { return rateOfPay; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }
                rateOfPay = value;
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }
                hoursWorked = value;
            }
        }

        public string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return string.Format("{0} -- ${1:0.00} :: {2}", name, rateOfPay, hoursWorked);
        }
    }
}




using System;
using GroupLeaderLastName.GroupLeaderFirstName.HumanResources; // Assuming the namespace from Part A

namespace GroupLeaderLastName.GroupLeaderFirstName.RRCHR
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing exceptions in the constructor
            try
            {
                Employee badEmployee1 = new Employee(-1m, 50, "John Doe");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Constructor Test 1: " + ex.Message);
            }

            try
            {
                Employee badEmployee2 = new Employee(10m, 105, "John Doe");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Constructor Test 2: " + ex.Message);
            }

            try
            {
                Employee badEmployee3 = new Employee(10m, 50, "   ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Constructor Test 3: " + ex.Message);
            }

            // Creating a valid instance
            Employee goodEmployee = new Employee(10m, 50, "John Doe");
            Console.WriteLine(goodEmployee.ToString()); // Checking initial state

            // Testing properties
            try
            {
                goodEmployee.RateOfPay = -5m;
            }
            catch (Exception ex)
            {
                Console.WriteLine("RateOfPay Test 1: " + ex.Message);
            }

            try
            {
                goodEmployee.HoursWorked = 105;
            }
            catch (Exception ex)
            {
                Console.WriteLine("HoursWorked Test 1: " + ex.Message);
            }

            try
            {
                goodEmployee.HoursWorked = -5;
            }
            catch (Exception ex)
            {
                Console.WriteLine("HoursWorked Test 2: " + ex.Message);
            }

            // Setting valid values and checking state after each change
            goodEmployee.RateOfPay = 15m;
            Console.WriteLine(goodEmployee.ToString());

            goodEmployee.HoursWorked = 60;
            Console.WriteLine(goodEmployee.ToString());

            // Checking read-only property
            Console.WriteLine("Employee Name: " + goodEmployee.Name);

            Console.ReadLine(); // To keep the console window open
        }
    }
}


edit this code in this format:
   //Test rateofPay less than 0
   try
   {
       Employee target = new Employee(-1M, 50, "Jon");
   }
   catch (ArgumentOutOfRangeException)
   {
       Console.WriteLine("RateOfPay Exception Test: {0}", ArgumentOutOfRangeException);
       employee.RateOfPay = 0m;
   }

Part A

Create a new Class Library (.NET Framework) Visual Studio Project. Name the Visual Studio Project GroupLeaderLastName.GroupLeaderFirstName.HumanResources, where “GroupLeaderLastName” and “GroupLeaderFirstName” are the first and last names of the Group Leader.

Example: Omega.Kenny.HumanResources.

Name the Visual Studio Solution Module2GroupActivityA.

Develop a class with the identifier Employee. Declare the Employee class in the GroupLeaderLastName.GroupLeaderFirstName.HumanResources namespace.

Employee
- rateOfPay : decimal
- hoursWorked : double
<<Property>> + RateOfPay : decimal
<<Property>> + HoursWorked : double
<<Property>> <<Read-only>> + Name : string
+ Employee(rateOfPay : decimal, hoursWorked : double, name : string)
+ ToString() : string
The Employee class will have the following fields:

- rateOfPay : decimal - Represents the amount of money paid to the employee per pay rate frequency.
- hoursWorked : double - Represents the number of hours the employee worked during the pay period.
The Employee class will have the following properties:

+ RateOfPay : decimal - Gets and sets the amount of money paid to the employee per pay rate frequency.
An ArgumentOutOfRangeException is thrown when the RateOfPay is set to a value less than zero. The message will read: The value must be zero or greater.
+ HoursWorked : double - Gets and sets the amount of hours the employee worked during the pay period.
An ArgumentOutOfRangeException is thrown when the HoursWorked is set to a value less than zero or a value greater than 100. The message will read: The value must between zero and 100 (inclusive).
+ Name : string - Gets the employee’s full name.
Note: The employee’s name cannot be modified after it is initially set.
When throwing exceptions for properties, initialize the exception with a parameter name of "value".
The Employee class will have the following methods:

+ Employee(rateOfPay : decimal, hoursWorked : double, name : string) - Initializes an instance of the Employee class with a specified rate of pay, hours worked and name.
An ArgumentOutOfRangeException is thrown when the rate of pay parameter is set to a value less than 0. The message will read: The argument value must be zero or greater.
An ArgumentOutOfRangeException is thrown when the hours worked parameter is set to a value less than 0 or a value greater than 100. The message will read: The argument value must between zero and 100 (inclusive).
An ArgumentException is thrown when the name parameter is set to a string with no characters (whitespace characters are trimmed). The message will read: The argument must contain at least one character.
When throwing exceptions for the constructor above, initialize all exceptions with the parameter name and the message.
+ ToString() : string - Returns the string representation of the Employee.

Format:

{name} -- {rate of pay} :: {hours worked}
Example:

Kenny Omega -- $10.30 :: 35.5

just call the property, no need to write other things


using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.HumanResources
{
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;
        private readonly string name;

        public decimal RateOfPay
        {
            get { return rateOfPay; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }
                rateOfPay = value;
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }
                hoursWorked = value;
            }
        }

        public string Name => name;

        public Employee(decimal rateOfPay, double hoursWorked, string name)
        {
            ValidateInputs(rateOfPay, hoursWorked, name);

            this.rateOfPay = rateOfPay;
            this.hoursWorked = hoursWorked;
            this.name = name;
        }

        private void ValidateInputs(decimal rate, double hours, string empName)
        {
            if (rate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rate), "The argument value must be zero or greater.");
            }

            if (hours < 0 || hours > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(hours), "The argument value must be between zero and 100 (inclusive).");
            }

            if (string.IsNullOrWhiteSpace(empName))
            {
                throw new ArgumentException("The argument must contain at least one character.", nameof(empName));
            }
        }

        public override string ToString()
        {
            return $"{Name} -- ${RateOfPay} :: {HoursWorked}";
        }
    }
}

using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.HumanResources
{
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;
        private readonly string name;

        public decimal RateOfPay
        {
            get { return rateOfPay; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }
                rateOfPay = value;
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }
                hoursWorked = value;
            }
        }

        public string Name => name;

        public Employee(decimal rateOfPay, double hoursWorked, string name)
        {
            ValidateInputs(rateOfPay, hoursWorked, name);

            this.rateOfPay = rateOfPay;
            this.hoursWorked = hoursWorked;
            this.name = name;
        }

        private void ValidateInputs(decimal rate, double hours, string empName)
        {
            if (rate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rate), "The argument value must be zero or greater.");
            }

            if (hours < 0 || hours > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(hours), "The argument value must be between zero and 100 (inclusive).");
            }

            if (string.IsNullOrWhiteSpace(empName))
            {
                throw new ArgumentException("The argument must contain at least one character.", nameof(empName));
            }
        }

        public override string ToString()
        {
            return $"{Name} -- ${RateOfPay} :: {HoursWorked}";
        }
    }
}
using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.HumanResources
{
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;
        private readonly string name;

        public decimal RateOfPay
        {
            get { return rateOfPay; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }
                rateOfPay = value;
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }
                hoursWorked = value;
            }
        }

        public string Name => name;

        public Employee(decimal rateOfPay, double hoursWorked, string name)
        {
            ValidateInputs(rateOfPay, hoursWorked, name);

            this.rateOfPay = rateOfPay;
            this.hoursWorked = hoursWorked;
            this.name = name;
        }

        private void ValidateInputs(decimal rate, double hours, string empName)
        {
            if (rate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rate), "The argument value must be zero or greater.");
            }

            if (hours < 0 || hours > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(hours), "The argument value must be between zero and 100 (inclusive).");
            }

            if (string.IsNullOrWhiteSpace(empName))
            {
                throw new ArgumentException("The argument must contain at least one character.", nameof(empName));
            }
        }

        public override string ToString()
        {
            return $"{Name} -- ${RateOfPay} :: {HoursWorked}";
        }
    }
}
using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.HumanResources
{
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;
        private readonly string name;

        public Employee(decimal rateOfPay, double hoursWorked, string name)
        {
            if (rateOfPay < 0)
            {
                throw new ArgumentOutOfRangeException("rateOfPay", "The argument value must be zero or greater.");
            }
            if (hoursWorked < 0 || hoursWorked > 100)
            {
                throw new ArgumentOutOfRangeException("hoursWorked", "The argument value must be between zero and 100 (inclusive).");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The argument must contain at least one character.", "name");
            }
            this.rateOfPay = rateOfPay;
            this.hoursWorked = hoursWorked;
            this.name = name.Trim();
        }

        public decimal RateOfPay
        {
            get { return rateOfPay; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }
                rateOfPay = value;
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }
                hoursWorked = value;
            }
        }

        public string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return string.Format("{0} -- ${1:0.00} :: {2}", name, rateOfPay, hoursWorked);
        }
    }
}

using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.HumanResources
{
    /// <summary>
    /// Represents an employee with details about their rate of pay, hours worked, and name.
    /// </summary>
    public class Employee
    {
        private decimal rateOfPay;
        private double hoursWorked;
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="rateOfPay">The rate of pay for the employee.</param>
        /// <param name="hoursWorked">The number of hours the employee has worked.</param>
        /// <param name="name">The name of the employee.</param>
        public Employee(decimal rateOfPay, double hoursWorked, string name)
        {
            if (rateOfPay < 0)
            {
                throw new ArgumentOutOfRangeException("rateOfPay", "The argument value must be zero or greater.");
            }
            if (hoursWorked < 0 || hoursWorked > 100)
            {
                throw new ArgumentOutOfRangeException("hoursWorked", "The argument value must be between zero and 100 (inclusive).");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The argument must contain at least one character.", "name");
            }
            this.rateOfPay = rateOfPay;
            this.hoursWorked = hoursWorked;
            this.name = name.Trim();
        }

        /// <summary>
        /// Gets or sets the rate of pay for the employee.
        /// </summary>
        public decimal RateOfPay
        {
            get { return rateOfPay; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");
                }
                rateOfPay = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of hours the employee has worked.
        /// </summary>
        public double HoursWorked
        {
            get { return hoursWorked; }
            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");
                }
                hoursWorked = value;
            }
        }

        /// <summary>
        /// Gets the name of the employee.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Returns a string that represents the current employee.
        /// </summary>
        /// <returns>A string that represents the current employee.</returns>
        public override string ToString()
        {
            return string.Format("{0} -- ${1:0.00} :: {2}", name, rateOfPay, hoursWorked);
        }
    }
}

/// <summary>
    /// Represents an employee with details about their rate of pay, hours worked, and name.
    /// </summary>

    /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
       

       using System;
using GroupLeaderLastName.GroupLeaderFirstName.HumanResources; // Assuming the namespace from Part A

namespace GroupLeaderLastName.GroupLeaderFirstName.RRCHR
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a valid instance for later use
            Employee employee = new Employee(10m, 50, "Jon");
            Console.WriteLine(employee.ToString()); // Checking initial state

            // Test rateOfPay less than 0
            try
            {
                Employee target = new Employee(-1M, 50, "Jon");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("RateOfPay Exception Test: {0}", ex.Message);
                employee.RateOfPay = 0m;
            }
        }


            // Creating a valid instance for later use
    Employee employee = new Employee(10m, 50, "Jon");
    Console.WriteLine(employee.ToString()); // Checking initial state

        // Test rateOfPay less than 0
        try
        {
            Employee target = new Employee(-1M, 50, "Jon");
}
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("RateOfPay Exception Test: {0}", ex.Message);
            employee.RateOfPay = 0m;
        }
}

            // Test hoursWorked more than 100
            try
            {
                Employee target = new Employee(10m, 105, "Jon");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("HoursWorked Exception Test (over 100): {0}", ex.Message);
                employee.HoursWorked = 100;
            }

            // Test hoursWorked less than 0
            try
            {
                Employee target = new Employee(10m, -5, "Jon");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("HoursWorked Exception Test (less than 0): {0}", ex.Message);
                employee.HoursWorked = 0;
            }

            // Test name as whitespace
            try
            {
                Employee target = new Employee(10m, 50, "   ");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Name Exception Test: {0}", ex.Message);
                // Name is read-only, so no corrective action here
            }

            // Setting valid values and checking state after each change
            employee.RateOfPay = 15m;
            Console.WriteLine(employee.ToString());

            employee.HoursWorked = 60;
            Console.WriteLine(employee.ToString());

            // Checking read-only property
            Console.WriteLine("Employee Name: " + employee.Name);

            Console.ReadLine(); // To keep the console window open
        }