using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightManage.Domain.ValueObjects
{
    public class FlightNumber
    {
        public string Value { get; }

        public FlightNumber(string value)
        {
            if (!Regex.IsMatch(value, "^[A-Z]{2}[0-9]{4}$"))
                throw new ArgumentException("Flight number must match format AANNNN (e.g., TK1234).");

            Value = value;
        }

        public override bool Equals(object? obj) =>
            obj is FlightNumber other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();

        public static implicit operator string(FlightNumber flightNumber) => flightNumber.Value;
        public override string ToString() => Value;
    }
}
