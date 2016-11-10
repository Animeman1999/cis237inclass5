using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make a new instance of the entites class
            CarsJMartinEntities carsJMartinEntites = new CarsJMartinEntities();

            //***********************************
            //List out all of the ars in the table
            //**********************************
            Console.WriteLine("Print the list");
            foreach(Car car in carsJMartinEntites.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }

            //*******************************************
            //Find a specific one by the primary key
            //******************************************

            // PUll out a car from the table base on the id which is the primay key
            //If the record doesn't exist in the database, it will return null, so
            //check what you get back and see if it is null. If so, it doesn't exist

            Car foundCar = carsJMartinEntites.Cars.Find("V0LCD1814"); //Find only finds by the primary key

            //Print it out
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Print out a found car using the Find Method");
            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);

            //******************************************************************************
            //Find a specific one by any property
            //******************************************************************************

            //Call the Where method on the table Cars and pass in a lamda expression
            //for the criteria we are lookin for.  There is nothing special about the 
            //word car in the part that reads : cart +> car.id == "V)...." It could be
            //any characters we want it to be. It is just a variable name for the current
            //car we are considering in the expression. This will automagically loop
            //through all the Cars, and run the expression against each of them.  When
            //The result is finnaly true, it will return car.

            Car carToFind = carsJMartinEntites.Cars.Where(
                car => car.model == "Challenger").First();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Print out a found car using the where Method");
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);

            //****************************************************************************
            //Get out multiple cars
            //***************************************************************************
            List<Car> queryCars = carsJMartinEntites.Cars.Where(
                car => car.cylinders == 8
                ).ToList();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Fincall all cars with 8 cylinders");

            foreach(Car car in queryCars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }
        }
    }
}
