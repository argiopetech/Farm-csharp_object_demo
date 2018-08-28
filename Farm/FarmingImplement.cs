using System;

namespace Farm
{
    public class FarmingImplement
    {
        // This class field keep track of hours on all the farming implements we use,
        // but can't be accessed outside the class.
        static private int totalFleetHours = 0;

        // This class method allows us to "get" the total fleet hours, but not to "set" it.
        static public int TotalFleetHours() => totalFleetHours;

        // This instance field keeps track of the specific number of hours on an object
        // of type FarmingImplemnet. It's not shared between objects like the static members,
        // but it's private (so it can't be changed by an overzealous coder).
        private int hours = 0;

        // This no-argument constructor allows a coder to create an object with default values (e.g., 0 hours)
        public FarmingImplement()
        { }

        // And this 1-argument constructor allows the creation of a FarmingImplement with
        // any number of hours "on the clock"
        public FarmingImplement(int hours)
        {
            this.hours = hours;
            FarmingImplement.totalFleetHours += hours; // Can't forget to add this value to the total!
        }

        // The primary function of a farm implement is to be operated by a farmer for some quantity of time
        // This, of course, also increases the total amount of time the fleet has been operating,
        // And, it requires the farmer's time.
        public void Operate(Farmer farmer, int hours)
        {
            this.hours += hours;
            FarmingImplement.totalFleetHours += hours;

            farmer.AddHours(hours);
        }

        // Since `hours` is private, we need a way to access it "read-only"
        public int GetHours() => hours;
    }
}