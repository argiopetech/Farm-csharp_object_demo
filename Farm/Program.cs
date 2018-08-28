using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            // We can access static methods/fields as soon as Main starts
            Console.WriteLine($"{ FarmingImplement.TotalFleetHours()}");

            // Instantiate some Farming Implements...
            var combine = new FarmingImplement(); // This is a co-op combine, purchased brand new this year
            var oldTractor = new FarmingImplement(700); // This is Dad's old tractor, an old but functional hand-me-down

            // And a farm with an anonymous object for a farmer...
            var ourFarm = new Farm(new Farmer(), oldTractor);

            // And an array of 4 non-descript crops
            Crop[] inheritedCrops = { new Crop(), new Crop()
                                    , new Crop(), new Crop() };

            // Now, we can call an instance method with our crops
            ourFarm.Grow( inheritedCrops );

            // Time marches on...

            // Harvest time has come
            // A new friend (stranger) from the co-op comes to run the combine for 20 hours
            combine.Operate(new Farmer(), 20);

            // And we harvest what we can from our personal field
            var harvestedCrops = ourFarm.Harvest();

            // We can put some data together in handy format using an anonymous object
            var data = new { tractorHours   = oldTractor.GetHours()
                           , farmerDays     = ourFarm.farmer.WholeDays()
                           , cropsHarvested = harvestedCrops.Length };

            // And, finally, print it all out
            Console.WriteLine($"Our farm harvested {data.cropsHarvested} crops" +
                              $" with {data.farmerDays} days of labor. We now have" +
                              $" {data.tractorHours} hours on the old tractor." +
                              $" Additionally, we hired a day farmer to run the" +
                              $" combine, which now has {combine.GetHours()} hours," +
                              $" bringing our fleet total to" +
                              $" {FarmingImplement.TotalFleetHours()} hours.");
        }
    }
}
