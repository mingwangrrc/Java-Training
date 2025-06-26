using System;

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
}