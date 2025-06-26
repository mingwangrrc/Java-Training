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
        public event EventHandler RateOfPayChanged;
        public event EventHandler HoursWorkedChanged;
        public event EventHandler Paid;

        // "On" methods for events
        protected virtual void OnRateOfPayChanged()
        {
            if (RateOfPayChanged != null)
                RateOfPayChanged(this, EventArgs.Empty);
        }

        protected virtual void OnHoursWorkedChanged()
        {
            if (HoursWorkedChanged != null)
                HoursWorkedChanged(this, EventArgs.Empty);
        }

        protected virtual void OnPaid()
        {
            if (Paid != null)
                Paid(this, EventArgs.Empty);
        }

        public decimal RateOfPay
        {
            get { return this.rateOfPay; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The value must be zero or greater.");

                if (value != rateOfPay)
                {
                    this.rateOfPay = value;
                    OnRateOfPayChanged();  // Raise the event if the value actually changed
                }
            }
        }

        public double HoursWorked
        {
            get { return this.hoursWorked; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("value", "The value must be between zero and 100 (inclusive).");

                if (value != hoursWorked)
                {
                    this.hoursWorked = value;
                    OnHoursWorkedChanged();  // Raise the event if the value actually changed
                }
            }
        }

        // Pay() method
        public decimal Pay()
        {
            decimal payment = rateOfPay * (decimal)hoursWorked;
            hoursWorked = 0;  // Reset hours worked after payment
            OnPaid();  // Raise the Paid event
            return payment;
        }
    }
}

check this code
Declare and define event handler methods for each of the events within the Employee class. Implement them as follows:
RateOfPayChanged - Print “The rate of pay has changed.” to the console.
HoursWorkedChanged - Print “The number of hours worked has changed.” to the console.
Paid - Print “{name} has been paid.” to the Console, where {name} is the name of the Employee who was paid.


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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mackenzie.Cam.HumanResources
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

        // Rest of the class stays the same as your original...
    }
}
