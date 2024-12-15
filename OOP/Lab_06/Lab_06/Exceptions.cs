using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InvalidGeographyItemException : Exception
{
    public InvalidGeographyItemException(string message) : base(message) { }
}

public class GeographyItemNotFoundException : Exception
{
    public GeographyItemNotFoundException(string message) : base(message) { }
}

public class CoordinatesOutOfRangeException : ArgumentOutOfRangeException
{
    public CoordinatesOutOfRangeException(string message) : base(message) { }
}