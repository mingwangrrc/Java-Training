using System;
using namespace Tan.Francis.Automotive;

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
