using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mackenzie.Cam.HumanResources
{
    public class Employee
    {
        private decimal rateOfPay;
        private decimal hoursWorked;

        public string Name
        {
            get;
            set;
        }

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

        public decimal HoursWorked
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
        public decimal Pay
        {
            get
            {
                decimal payment = (decimal)HoursWorked * RateOfPay;
                HoursWorked = 0;
                OnPaid();
                return payment;
            }
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
        public Employee(string name, decimal rateOfPay, decimal hoursWorked)
        {
            if (rateOfPay < 0)
                throw new ArgumentOutOfRangeException("rateOfPay", "The argument value must be zero or greater.");

            if (hoursWorked < 0 || hoursWorked > 100)
                throw new ArgumentOutOfRangeException("hoursWorked", "The argument value must between zero and 100 (inclusive).");

            if (name.Trim().Equals(string.Empty))
                throw new ArgumentException("The argument must contain at least one character.", "name");

            this.rateOfPay = rateOfPay;
            this.hoursWorked = hoursWorked;
            this.Name = name;
        }

    }
}






















using System;
using System.Collections.Generic;
using Mackenzie.Cam.HumanResources;

namespace Mackenzie.Cam.RRCHR
{
    internal class Program
    {
        private class EmployeeWrapper
        {
            public string Name { get; set; }
            public Employee EmployeeData { get; set; }
        }

        static void Main(string[] args)
        {
            List<EmployeeWrapper> employees = new List<EmployeeWrapper>
            {
                new EmployeeWrapper
                {
                Name = "Hulk Hogan", EmployeeData = new Employee("Hulk Hogan", 15.00m, 40)
                },
                new EmployeeWrapper
                {
                Name = "Kevin Nash", EmployeeData = new Employee("Kevin Nash", 30.00m, 40)
                },
                new EmployeeWrapper
                {
                Name = "Scott Hall", EmployeeData = new Employee("Scott Hall", 45.00m, 40)
                }
            };


            // Subscribe to events
            foreach (var empWrapper in employees)
            {
                empWrapper.EmployeeData.RateOfPayChanged += Employee_RateOfPayChanged;
                empWrapper.EmployeeData.HoursWorkedChanged += Employee_HoursWorkedChanged;
                empWrapper.EmployeeData.Paid += Employee_Paid;
            }

            // Increase rate of pay and get payment
            foreach (var empWrapper in employees)
            {
                empWrapper.EmployeeData.RateOfPay += 1.35m;
                decimal payment = empWrapper.EmployeeData.Pay;
            }

            // Create a dictionary
            Dictionary<string, Employee> stuff = new Dictionary<string, Employee>();
            foreach (var empWrapper in employees)
            {
                stuff[empWrapper.Name] = empWrapper.EmployeeData;
            }

            // Set hours worked and get payment
            if (stuff.ContainsKey("Kevin Nash"))
            {
                stuff["Kevin Nash"].HoursWorked = 100;
                decimal payBilly = stuff["Kevin Nash"].Pay;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void Employee_RateOfPayChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The rate of pay has changed.");
        }

        private static void Employee_HoursWorkedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The number of hours worked has changed.");
        }

        private static void Employee_Paid(object sender, EventArgs e)
        {
            Employee employee = (Employee)sender;
            Console.WriteLine($"{employee.Name} has been paid.");
        }
    }
}





