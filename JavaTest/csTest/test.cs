using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.Automotive
{
    public class Car
    {
        private const int MaximumSpeed = 200;
        private int yearManufactured;
        private string manufacturer;
        private int speed;
        private int speedIncrement;

        public Car(int year, string manufacturer)
        {
            this.yearManufactured = year;
            this.manufacturer = manufacturer;
            this.speed = 0;
            this.speedIncrement = 3;
        }

        public Car(int year, string manufacturer, int speedIncrement)
        {
            this.yearManufactured = year;
            this.manufacturer = manufacturer;
            this.speed = 0;
            this.speedIncrement = speedIncrement;
        }

        public int GetYearManufactured()
        {
            return this.yearManufactured;
        }

        public void SetYearManufactured(int year)
        {
            this.yearManufactured = year;
        }

        public string GetManufacturer()
        {
            return this.manufacturer;
        }

        public void SetManufacturer(string manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        public int GetSpeed()
        {
            return this.speed;
        }

        public void Accelerate()
        {
            this.speed = Math.Min(this.speed + this.speedIncrement, MaximumSpeed);
        }

        public void Accelerate(int speed)
        {
            if(speed > this.speed)
            {
                this.speed = Math.Min(speed, MaximumSpeed);
            }
        }

        public void Brake()
        {
            this.speed = Math.Max(this.speed - this.speedIncrement, 0);
        }
    }
}



using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.Automotive
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(2000, "Toyota");
            Car car2 = new Car(2010, "Honda", 5);

            // Test Get and Set methods
            Console.WriteLine($"Car1 Manufacturer: {car1.GetManufacturer()}");
            Console.WriteLine($"Car1 Year Manufactured: {car1.GetYearManufactured()}");
            car1.SetManufacturer("Ford");
            car1.SetYearManufactured(2005);
            Console.WriteLine($"Car1 Manufacturer (after set): {car1.GetManufacturer()}");
            Console.WriteLine($"Car1 Year Manufactured (after set): {car1.GetYearManufactured()}");

            // Test Accelerate and Brake methods
            Console.WriteLine($"Car1 Speed: {car1.GetSpeed()}");
            car1.Accelerate();
            Console.WriteLine($"Car1 Speed (after accelerate): {car1.GetSpeed()}");
            car1.Brake();
            Console.WriteLine($"Car1 Speed (after brake): {car1.GetSpeed()}");

            // Test Overloaded Accelerate method
            car2.Accelerate(100);
            Console.WriteLine($"Car2 Speed (after accelerate to 100): {car2.GetSpeed()}");
            car2.Accelerate(50);
            Console.WriteLine($"Car2 Speed (after trying to accelerate to 50): {car2.GetSpeed()}");
        }
    }
}

namespace GroupLeaderLastName.GroupLeaderFirstName.Automotive
{
    public enum Gear
    {
        Park = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Reverse = 99
    }

    public class Car
    {
        public const int MaximumSpeed = 200;
        private int yearManufactured;
        private string manufacturer;
        private int speed;
        private int speedIncrement;

        public Car(int year, string manufacturer)
        {
            this.yearManufactured = year;
            this.manufacturer = manufacturer;
            this.speed = 0;
            this.speedIncrement = 3;
        }

        public Car(int year, string manufacturer, int speedIncrement)
        {
            this.yearManufactured = year;
            this.manufacturer = manufacturer;
            this.speed = 0;
            this.speedIncrement = speedIncrement;
        }

        public int GetYearManufactured()
        {
            return yearManufactured;
        }

        public void SetYearManufactured(int year)
        {
            yearManufactured = year;
        }

        public string GetManufacturer()
        {
            return manufacturer;
        }

        public void SetManufacturer(string manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public void Accelerate()
        {
            speed = Math.Min(speed + speedIncrement, MaximumSpeed);
        }

        public void Accelerate(int targetSpeed)
        {
            if (targetSpeed > speed)
            {
                speed = Math.Min(targetSpeed, MaximumSpeed);
            }
        }

        public void Brake()
        {
            speed = Math.Max(speed - speedIncrement, 0);
        }
    }
}

using System;
using GroupLeaderLastName.GroupLeaderFirstName.Automotive;

namespace Module1GroupActivity
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(2020, "Toyota");
            Car car2 = new Car(2021, "Honda", 5);

            Console.WriteLine($"Car1 Year Manufactured: {car1.GetYearManufactured()}");
            Console.WriteLine($"Car2 Manufacturer: {car2.GetManufacturer()}");

            car1.Accelerate();
            Console.WriteLine($"Car1 Speed after accelerating: {car1.GetSpeed()}");

            car1.Accelerate(100);
            Console.WriteLine($"Car1 Speed after setting speed to 100: {car1.GetSpeed()}");

            car1.Brake();
            Console.WriteLine($"Car1 Speed after braking: {car1.GetSpeed()}");

            car2.SetYearManufactured(2019);
            Console.WriteLine($"Car2 Year Manufactured after setting a new year: {car2.GetYearManufactured()}");
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroupLeaderLastName.GroupLeaderFirstName.Automotive;

namespace Module1GroupActivityTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void GetSpeed_InitialSpeed_ShouldReturnZero()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");

            // Act
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(0, speed);
        }

        [TestMethod]
        public void Accelerate_DefaultIncrement_ShouldIncreaseSpeedByThree()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");

            // Act
            car.Accelerate();
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(3, speed);
        }

        [TestMethod]
        public void Accelerate_BeyondMaximumSpeed_ShouldSetSpeedToMaximumSpeed()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");

            // Act
            for (int i = 0; i < 100; i++)
            {
                car.Accelerate();
            }
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(200, speed);
        }

        [TestMethod]
        public void Brake_SpeedGreaterThanZero_ShouldDecreaseSpeedByThree()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");
            car.Accelerate();

            // Act
            car.Brake();
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(0, speed);
        }

        [TestMethod]
        public void Brake_SpeedAtZero_ShouldRemainAtZero()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");

            // Act
            car.Brake();
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(0, speed);
        }
    }
}

Math. and MaximumSpeed shows errors.


using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroupLeaderLastName.GroupLeaderFirstName.Automotive;

namespace Module1GroupActivityTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void GetSpeed_InitialSpeed_ShouldReturnZero()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");

            // Act
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(0, speed);
        }

        [TestMethod]
        public void Accelerate_DefaultIncrement_ShouldIncreaseSpeedByThree()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");

            // Act
            car.Accelerate();
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(3, speed);
        }

        [TestMethod]
        public void Accelerate_BeyondMaximumSpeed_ShouldSetSpeedToMaximumSpeed()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");

            // Act
            for (int i = 0; i < 100; i++)
            {
                car.Accelerate();
            }
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(200, speed);
        }

        [TestMethod]
        public void Brake_SpeedGreaterThanZero_ShouldDecreaseSpeedByThree()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");
            car.Accelerate();

            // Act
            car.Brake();
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(0, speed);
        }

        [TestMethod]
        public void Brake_SpeedAtZero_ShouldRemainAtZero()
        {
            // Arrange
            Car car = new Car(2020, "Toyota");

            // Act
            car.Brake();
            var speed = car.GetSpeed();

            // Assert
            Assert.AreEqual(0, speed);
        }
    }
}


test like this way   static void constructor1_ManufacturerAndYearManufactured_initializeManufacturerAndYearManufactured()
  {
      //setup
      string manufacturer = "BMW";
      int yearManufactured = 2020;
      //act
      Car newCar = new Car(yearManufactured, manufacturer);
      //confirm
      string expected = "2020 BMW";
      string actual = newCar.GetYearManufactured() + " " + newCar.GetManufacturer();

      Console.WriteLine($"Expected: {expected} \nActual: {actual} \n");
  }

for + GetSpeed() : int
+ Accelerate() : void
+ Brake() : void

using System; // Add this line

/**
 * Group Number: 8
 * Group Members: Francis Tan, Angelo Marcial, Ming Wang, Jose Timog
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-09-07
 * Updated: 2023-09-07
 */

namespace Tan.Francis.Automotive
{
    public class Car
    {
        private const int MaxTestSpeed = 200;
        private int yearManufactured;
        private string manufacturer;
        private int speed;
        private int speedIncrement;

        public Car(int year, string manufacturer)
        {
            this.yearManufactured = year;
            this.manufacturer =  manufacturer;
            this.speed = 0;
            this.speedIncrement = 3;
        }

        public Car(int year, string manufacturer, int speedIncrement)
        {
            this.yearManufactured = year;
            this.manufacturer = manufacturer;
            this.speed = 0;
            this.speedIncrement = speedIncrement;
        }

        public int GetYearManufactured()
        {
            return this.yearManufactured;
        }

        public void SetYearManufactured(int year)
        {
            this.yearManufactured = year;
        }

        public string GetManufacturer()
        {
            return this.manufacturer;
        }

        public void SetManufacturer(string manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public void Accelerate()
        {
            speed = Math.Min(speed + speedIncrement, MaxTestSpeed);
        }

        public void Accelerate(int targetSpeed)
        {
            if (targetSpeed > speed)
            {
                speed = Math.Min(targetSpeed, MaxTestSpeed);
            }
        }

        public void Brake()
        {
            speed = Math.Max(speed - speedIncrement, 0);
        }
    }
}

using System;

namespace Tan.Francis.Automotive
{
    public static class CarTests
    {
        public static void Main()
        {
            constructor1_ManufacturerAndYearManufactured_initializeManufacturerAndYearManufactured();
            getSpeed_InitialSpeed_isZero();
            accelerate_DefaultIncrement_increasesSpeedByDefaultIncrement();
            brake_DefaultDecrement_decreasesSpeedByDefaultIncrement();
        }

        static void constructor1_ManufacturerAndYearManufactured_initializeManufacturerAndYearManufactured()
        {
            //setup
            string manufacturer = "BMW";
            int yearManufactured = 2020;

            //act
            Car newCar = new Car(yearManufactured, manufacturer);

            //confirm
            string expected = "2020 BMW";
            string actual = newCar.GetYearManufactured() + " " + newCar.GetManufacturer();

            Console.WriteLine($"Expected: {expected} \nActual: {actual} \n");
        }

        static void getSpeed_InitialSpeed_isZero()
        {
            // setup
            Car newCar = new Car(2020, "BMW");

            // confirm
            int expected = 0;
            int actual = newCar.GetSpeed();

            Console.WriteLine($"Expected: {expected} \nActual: {actual} \n");
        }

        static void accelerate_DefaultIncrement_increasesSpeedByDefaultIncrement()
        {
            // setup
            Car newCar = new Car(2020, "BMW");

            // act
            newCar.Accelerate();

            // confirm
            int expected = 3; // the default speed increment is 3
            int actual = newCar.GetSpeed();

            Console.WriteLine($"Expected: {expected} \nActual: {actual} \n");
        }

        static void brake_DefaultDecrement_decreasesSpeedByDefaultIncrement()
        {
            // setup
            Car newCar = new Car(2020, "BMW");
            newCar.Accelerate(); // First accelerate to get speed > 0

            // act
            newCar.Brake();

            // confirm
            int expected = 0; // the speed will be reduced back to 0
            int actual = newCar.GetSpeed();

            Console.WriteLine($"Expected: {expected} \nActual: {actual} \n");
        }
    }

    public class Car
    {
        // your Car class implementation goes here...
    }
}

public int GetSpeed()
{
    return speed;
}

public void Accelerate()
{
    speed = Math.Min(speed + speedIncrement, MaxTestSpeed);
}

public void Accelerate(int targetSpeed)
{
    if (targetSpeed > speed)
    {
        speed = Math.Min(targetSpeed, MaxTestSpeed);
    }
}

public void Brake()
{
    speed = Math.Max(speed - speedIncrement, 0);
}  

use this format (/// <summary>
/// Returns the year the Car was manufactured.
/// </summary>
/// <returns>The year the car was manufactured.</returns>
public int GetYearManufactured()
{
    return this.yearManufactured;
})
to comment the code above

check this project:
see if there are any problem
namespace Tan.Francis.Automotive
{
    public class Car
    {
        private const int MaxTestSpeed = 200;
        private int yearManufactured;
        private string manufacturer;
        private int speed;
        private int speedIncrement;

        public Car(int year, string manufacturer)
        {
            this.yearManufactured = year;
            this.manufacturer =  manufacturer;
            this.speed = 0;
            this.speedIncrement = 3;
        }

        public Car(int year, string manufacturer, int speedIncrement)
        {
            this.yearManufactured = year;
            this.manufacturer = manufacturer;
            this.speed = 0;
            this.speedIncrement = speedIncrement;
        }

        /// <summary>
        /// Returns the year the Car was manufactured.
        /// </summary>
        /// <returns>The year the car was manufactured.</returns>
        public int GetYearManufactured()
        {
            return this.yearManufactured;
        }

        /// <summary>
        /// Sets the year the Car was manufactured.
        /// </summary>
        /// <param name="year">The year the Car was manufactured.</param>
        public void SetYearManufactured(int year)
        {
            this.yearManufactured = year;
        }

        /// <summary>
        /// Returns the company that manufactured the Car.
        /// </summary>
        /// <returns>The company that manufactured the Car.</returns>
        public string GetManufacturer()
        {
            return this.manufacturer;
        }

        /// <summary>
        /// Sets the company that manufactured the Car.
        /// </summary>
        /// <param name="manufacturer">The company that manufactured the Car.</param>
        public void SetManufacturer(string manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        /// <summary>
        /// Returns the current speed of the vehicle.
        /// </summary>
        /// <returns>The current speed of the vehicle.</returns>
        public int GetSpeed()
        {
            return this.speed;
        }

        /// <summary>
        /// Increases the vehicle's speed by a standard increment, up to a predefined maximum test speed.
        /// </summary>
        public void Accelerate()
        {
            this.speed = Math.Min(this.speed + speedIncrement, MaxTestSpeed);
        }

        /// <summary>
        /// Increases the vehicle's speed to a specified target speed, up to a predefined maximum test speed.
        /// </summary>
        /// <param name="targetSpeed">The target speed to attempt to set the vehicle's speed to.</param>
        public void Accelerate(int targetSpeed)
        {
            if (targetSpeed > speed)
            {
                this.speed = Math.Min(targetSpeed, MaxTestSpeed);
            }
        }

        /// <summary>
        /// Decreases the vehicle's speed by a standard increment, down to a minimum speed of 0.
        /// </summary>
        public void Brake()
        {
            this.speed = Math.Max(this.speed - speedIncrement, 0);
        }
    }check if its available
}


public int GetSpeed()
{
    return this.speed;
}

/// <summary>
/// Increases the vehicle's speed by the specified increment or by a standard increment if none is specified, 
/// up to a predefined maximum test speed.
/// </summary>
/// <param name="increment">The amount by which to increase the vehicle's speed. Optional.</param>
public void Accelerate(int increment = -1)
{
    if (increment == -1)
    {
        this.speed = Math.Min(this.speed + speedIncrement, MaxTestSpeed);
    }
    else
    {
        this.speed = Math.Min(this.speed + increment, MaxTestSpeed);
    }
}

/// <summary>
/// Decreases the vehicle's speed by a standard increment, down to a minimum speed of 0.
/// </summary>
public void Brake()
{
    this.speed = Math.Max(this.speed - speedIncrement, 0);
}


using System;

namespace GroupLeaderLastName.GroupLeaderFirstName.Automotive
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(2023, "Toyota", 5);

            Console.WriteLine("Initial Speed: " + myCar.GetSpeed()); // Expecting 0

            myCar.Accelerate();
            Console.WriteLine("Speed after accelerating: " + myCar.GetSpeed()); // Expecting 5

            myCar.Brake();
            Console.WriteLine("Speed after braking: " + myCar.GetSpeed()); // Expecting 0

            myCar.Accelerate(210);
            Console.WriteLine("Speed after setting speed to 210: " + myCar.GetSpeed()); // Expecting 200, since 210 exceeds maximum speed

            myCar.Brake();
            myCar.Brake();
            Console.WriteLine("Speed after braking twice: " + myCar.GetSpeed()); // Expecting 190, because speed increment is 5 and 200 - (5*2) = 190

            // Add more test cases as necessary to thoroughly test all possible scenarios
        }
    }
}

public class Car
{
    
    private int MaximumSpeed = 200;
    private int yearManufactured;
    private string manufacturer;
    private int speed = 0;
    private int speedIncrement = 3;
    


    public int GetSpeed()
    {
        return this.speed;
    }

    public void Accelerate()
    {
        this.speed += this.speedIncrement;

        if (this.speed > this.MaximumSpeed)
        {
            this.speed = this.MaximumSpeed;
        }
    }

    public void Accelerate(int increment)
    {
        if (increment > this.speed)
        {
            this.speed = increment;
        }
        
        if (this.speed > this.MaximumSpeed)
        {
            this.speed = this.MaximumSpeed;
        }
    }

    public void Brake()
    {
        this.speed -= this.speedIncrement;

        if (this.speed < 0)
        {
            this.speed = 0;
        }
    }
}




public class Car
{
    // Your existing class attributes and other methods here...

    /// <summary>
    /// Returns the Car's current speed.
    /// </summary>
    /// <returns>The current speed of the Car.</returns>
    public int GetSpeed()
    {
        return this.speed;
    }

    /// <summary>
    /// Increases the Car's speed by the speed increment without exceeding the maximum speed.
    /// </summary>
    public void Accelerate()
    {
        this.speed += this.speedIncrement;
        if (this.speed > MaxTestSpeed)
        {
            this.speed = MaxTestSpeed;
        }
    }

    /// <summary>
    /// Increases the Car's speed to a specified value without exceeding the maximum speed.
    /// </summary>
    /// <param name="speed">The new speed value.</param>
    public void Accelerate(int speed)
    {
        if (speed > this.speed)
        {
            this.speed = speed;
        }
        if (this.speed > MaxTestSpeed)
        {
            this.speed = MaxTestSpeed;
        }
    }

    /// <summary>
    /// Decreases the Car's speed by the speed increment without going below zero.
    /// </summary>
    public void Brake()
    {
        this.speed -= this.speedIncrement;
        if (this.speed < 0)
        {
            this.speed = 0;
        }
    }
}

static void constructor1_GetSpeed_initializesToZero()
{
    //setup
    string manufacturer = "BMW";
    int yearManufactured = 2020;

    //act
    Car newCar = new Car(yearManufactured, manufacturer);

    //confirm
    int expected = 0;
    int actual = newCar.GetSpeed();

    Console.WriteLine($"Expected: {expected} \nActual: {actual} \n");
}

static void constructor1_Accelerate_incrementsSpeedBySpeedIncrement()
{
    //setup
    string manufacturer = "BMW";
    int yearManufactured = 2020;

    //act
    Car newCar = new Car(yearManufactured, manufacturer);
    newCar.Accelerate();

    //confirm
    int expected = 3;  // Default speedIncrement is 3
    int actual = newCar.GetSpeed();

    Console.WriteLine($"Expected: {expected} \nActual: {actual} \n");
}

static void constructor1_Brake_decrementsSpeedBySpeedIncrement()
{
    //setup
    string manufacturer = "BMW";
    int yearManufactured = 2020;

    //act
    Car newCar = new Car(yearManufactured, manufacturer);
    newCar.Accelerate();  // First accelerate to increase speed, then brake
    newCar.Brake();

    //confirm
    int expected = 0;  // Speed increases to 3 with Accelerate() and then back to 0 with Brake()
    int actual = newCar.GetSpeed();

    Console.WriteLine($"Expected: {expected} \nActual: {actual} \n");
}


