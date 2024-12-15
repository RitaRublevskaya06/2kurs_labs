using System;
using System.Collections.Generic;

public class Flight
{
    public string Destination { get; set; }
    public string DayOfWeek { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public string AircraftType { get; set; }
    public int FlightNumber { get; set; }
}

public class Airline
{
    public List<Flight> Flights { get; set; } = new List<Flight>();

    public IEnumerable<Flight> GetFlightsByDestination(string destination)
    {
        return Flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Flight> GetFlightsByDay(string day)
    {
        return Flights.Where(f => f.DayOfWeek.Equals(day, StringComparison.OrdinalIgnoreCase));
    }

    public int CountFlightsByAircraftType(string aircraftType)
    {
        return Flights.Count(f => f.AircraftType.Equals(aircraftType, StringComparison.OrdinalIgnoreCase));
    }
}

public class Airport
{
    public string Name { get; set; }
    public string Location { get; set; }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lab_10
//{
//    internal class Class
//    {
//    }
//}

//public Flight GetMaxFlightByDay(string day)
//{
//    return Flights.Where(f => f.DayOfWeek.Equals(day, StringComparison.OrdinalIgnoreCase))
//                  .OrderByDescending(f => f.DepartureTime)
//                  .FirstOrDefault();
//}

//public IEnumerable<Flight> GetFlightsAtLatestDeparture(string day)
//{
//    var latestTime = Flights.Where(f => f.DayOfWeek.Equals(day, StringComparison.OrdinalIgnoreCase))
//                            .Max(f => f.DepartureTime);
//    return Flights.Where(f => f.DayOfWeek.Equals(day, StringComparison.OrdinalIgnoreCase) && f.DepartureTime == latestTime);
//}