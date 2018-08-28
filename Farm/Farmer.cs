using System;

namespace Farm
{
    public class Farmer
    {
        // Farmers gain wear and tear, just like farming implements
        // This private instance field keeps track of that
        private int hours;

        // We won't let anyone access `hours` directly, so we provide a few accessors
        // First, a way to add hours
        public void AddHours(int hours) =>
            this.hours += hours;

        // Then, a way to get the number of whole days the farmer has worked
        public int WholeDays()
        {
            var fractionalWorkDays = FractionalDays();

            // Working part of the day is as draining as a whole day, so we always round up
            // We have to do a hacky cast, because Math.Ceiling doesn't return an int.
            return (int)Math.Ceiling(fractionalWorkDays);
        }

        // Work days are defined (arbitrarily) as 8 hours long
        public double FractionalDays() => hours / 8.0;
    }
}