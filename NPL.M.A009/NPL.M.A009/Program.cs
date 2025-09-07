using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FixedWing
{
    public string ID { get; set; }
    public string Model { get; set; }
    public string PlaneType { get; set; }
    public int CruiseSpeed { get; set; }
    public int EmptyWeight { get; set; }
    public int MaxTakeoffWeight { get; set; }
    public int MinNeededRunwaySize { get; set; }

    public void Fly()
    {
        Console.WriteLine("Fixed wing is flying (fixed wing)");
    }
}

class Helicopter
{
    public string ID { get; set; }
    public string Model { get; set; }
    public int CruiseSpeed { get; set; }
    public int EmptyWeight { get; set; }
    public int MaxTakeoffWeight { get; set; }
    public int Range;

    public void Fly()
    {
        Console.WriteLine("Helicopter is flying (rotated wing)");
    }
}

class Airport
{
    public string ID { get; set; }
    public string Name { get; set; }
    public int RunwaySize { get; set; }
    public int MaxFixedWingParkingPlace { get; set; }
    public int MaxRotatedWingParkingPlace { get; set; }
    public List<string> FixedWingAirplaneIDs { get; set; }
    public List<string> HelicopterIDs { get; set; }

    public Airport(string id, string name, int runwaySize, int maxFixedWingParkingPlace, int maxRotatedWingParkingPlace)
    {
        ID = id;
        Name = name;
        RunwaySize = runwaySize;
        MaxFixedWingParkingPlace = maxFixedWingParkingPlace;
        MaxRotatedWingParkingPlace = maxRotatedWingParkingPlace;
        FixedWingAirplaneIDs = new List<string>();
        HelicopterIDs = new List<string>();
    }
}

class AirportManagementSystem
{
    private List<Airport> airports;
    private List<FixedWing> fixedWings;
    private List<Helicopter> helicopters;

    public AirportManagementSystem()
    {
        airports = new List<Airport>();
        fixedWings = new List<FixedWing>();
        helicopters = new List<Helicopter>();
    }

    public void AddAirport(Airport airport)
    {
        if (airports.Any(a => a.ID == airport.ID))
        {
            Console.WriteLine("Airport with the same ID already exists.");
        }
        else
        {
            airports.Add(airport);
            Console.WriteLine("Airport added successfully.");
        }
    }

    public void RemoveAirport(string airportID)
    {
        var airportToRemove = airports.FirstOrDefault(a => a.ID == airportID);
        if (airportToRemove != null)
        {
            airports.Remove(airportToRemove);
            Console.WriteLine("Airport removed successfully.");
        }
        else
        {
            Console.WriteLine("Airport not found.");
        }
    }

    public void AddFixedWingToAirport(string airportID, FixedWing fixedWing)
    {
        var airport = airports.FirstOrDefault(a => a.ID == airportID);
        if (airport != null)
        {
            if (airport.FixedWingAirplaneIDs.Count < airport.MaxFixedWingParkingPlace &&
                fixedWing.MinNeededRunwaySize <= airport.RunwaySize)
            {
                airport.FixedWingAirplaneIDs.Add(fixedWing.ID);
                fixedWings.Add(fixedWing);
                Console.WriteLine("Fixed wing added to the airport successfully.");
            }
            else
            {
                Console.WriteLine("Cannot add fixed wing to the airport due to parking capacity or runway size.");
            }
        }
        else
        {
            Console.WriteLine("Airport not found.");
        }
    }

    public void RemoveHelicopterFromAirport(string airportID, string helicopterID)
    {
        var airport = airports.FirstOrDefault(a => a.ID == airportID);
        if (airport != null)
        {
            if (airport.HelicopterIDs.Contains(helicopterID))
            {
                airport.HelicopterIDs.Remove(helicopterID);
                var helicopterToRemove = helicopters.FirstOrDefault(h => h.ID == helicopterID);
                if (helicopterToRemove != null)
                {
                    helicopters.Remove(helicopterToRemove);
                    Console.WriteLine("Helicopter removed from the airport successfully.");
                }
            }
            else
            {
                Console.WriteLine("Helicopter not found in the airport.");
            }
        }
        else
        {
            Console.WriteLine("Airport not found.");
        }
    }

    public void AddHelicopterToAirport(string airportID, Helicopter helicopter)
    {
        var airport = airports.FirstOrDefault(a => a.ID == airportID);
        if (airport != null)
        {
            if (airport.HelicopterIDs.Count < airport.MaxRotatedWingParkingPlace &&
                helicopter.MaxTakeoffWeight <= 1.5 * helicopter.EmptyWeight)
            {
                airport.HelicopterIDs.Add(helicopter.ID);
                helicopters.Add(helicopter);
                Console.WriteLine("Helicopter added to the airport successfully.");
            }
            else
            {
                Console.WriteLine("Cannot add helicopter to the airport due to parking capacity or weight limit.");
            }
        }
        else
        {
            Console.WriteLine("Airport not found.");
        }
    }

    public void DisplayAirports()
    {
        foreach (var airport in airports)
        {
            Console.WriteLine($"ID: {airport.ID}, Name: {airport.Name}, Runway Size: {airport.RunwaySize}");
        }
    }

    public void DisplayFixedWings()
    {
        foreach (var fixedWing in fixedWings)
        {
            Console.WriteLine($"ID: {fixedWing.ID}, Model: {fixedWing.Model}");
        }
    }

    public void DisplayHelicopters()
    {
        foreach (var helicopter in helicopters)
        {
            Console.WriteLine($"ID: {helicopter.ID}, Model: {helicopter.Model}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        AirportManagementSystem ams = new AirportManagementSystem();

        while (true)
        {
            Console.WriteLine("\nAirport Management System");
            Console.WriteLine("1. Add Airport");
            Console.WriteLine("2. Remove Airport");
            Console.WriteLine("3. Add Fixed Wing to Airport");
            Console.WriteLine("4. Remove Helicopter from Airport");
            Console.WriteLine("5. Add Helicopter to Airport");
            Console.WriteLine("6. Display Airports");
            Console.WriteLine("7. Display Fixed Wings");
            Console.WriteLine("8. Display Helicopters");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Airport ID: ");
                        string airportID = Console.ReadLine();
                        Console.Write("Enter Airport Name: ");
                        string airportName = Console.ReadLine();
                        Console.Write("Enter Runway Size: ");
                        int runwaySize = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Max Fixed Wing Parking Places: ");
                        int maxFixedWingParking = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Max Rotated Wing Parking Places: ");
                        int maxRotatedWingParking = Convert.ToInt32(Console.ReadLine());
                        Airport newAirport = new Airport(airportID, airportName, runwaySize, maxFixedWingParking, maxRotatedWingParking);
                        ams.AddAirport(newAirport);
                        break;
                    case 2:
                        Console.Write("Enter Airport ID to remove: ");
                        string removeAirportID = Console.ReadLine();
                        ams.RemoveAirport(removeAirportID);
                        break;
                    case 3:
                        Console.Write("Enter Airport ID: ");
                        string fwAirportID = Console.ReadLine();
                        Console.Write("Enter Fixed Wing ID: ");
                        string fwID = Console.ReadLine();
                        Console.Write("Enter Fixed Wing Model: ");
                        string fwModel = Console.ReadLine();
                        Console.Write("Enter Fixed Wing Cruise Speed: ");
                        int fwCruiseSpeed = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Fixed Wing Empty Weight: ");
                        int fwEmptyWeight = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Fixed Wing Max Takeoff Weight: ");
                        int fwMaxTakeoffWeight = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Fixed Wing Min Needed Runway Size: ");
                        int fwMinNeededRunwaySize = Convert.ToInt32(Console.ReadLine());
                        FixedWing newFixedWing = new FixedWing
                        {
                            ID = fwID,
                            Model = fwModel,
                            CruiseSpeed = fwCruiseSpeed,
                            EmptyWeight = fwEmptyWeight,
                            MaxTakeoffWeight = fwMaxTakeoffWeight,
                            MinNeededRunwaySize = fwMinNeededRunwaySize
                        };
                        ams.AddFixedWingToAirport(fwAirportID, newFixedWing);
                        break;
                    case 4:
                        Console.Write("Enter Airport ID: ");
                        string removeHeliAirportID = Console.ReadLine();
                        Console.Write("Enter Helicopter ID to remove: ");
                        string heliIDToRemove = Console.ReadLine();
                        ams.RemoveHelicopterFromAirport(removeHeliAirportID, heliIDToRemove);
                        break;
                    case 5:
                        Console.Write("Enter Airport ID: ");
                        string heliAirportID = Console.ReadLine();
                        Console.Write("Enter Helicopter ID: ");
                        string heliID = Console.ReadLine();
                        Console.Write("Enter Helicopter Model: ");
                        string heliModel = Console.ReadLine();
                        Console.Write("Enter Helicopter Cruise Speed: ");
                        int heliCruiseSpeed = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Helicopter Empty Weight: ");
                        int heliEmptyWeight = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Helicopter Max Takeoff Weight: ");
                        int heliMaxTakeoffWeight = Convert.ToInt32(Console.ReadLine());
                        Helicopter newHelicopter = new Helicopter
                        {
                            ID = heliID,
                            Model = heliModel,
                            CruiseSpeed = heliCruiseSpeed,
                            EmptyWeight = heliEmptyWeight,
                            MaxTakeoffWeight = heliMaxTakeoffWeight
                        };
                        ams.AddHelicopterToAirport(heliAirportID, newHelicopter);
                        break;
                    case 6:
                        ams.DisplayAirports();
                        break;
                    case 7:
                        ams.DisplayFixedWings();
                        break;
                    case 8:
                        ams.DisplayHelicopters();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
