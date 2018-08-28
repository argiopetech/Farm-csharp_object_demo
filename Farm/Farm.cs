using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Farm
    {
        // We assign `farmer` and `tractor` values in the constructor
        // If we don't, these will be `null` by default. Any attempt to use
        // them will result in an error at runtime.
        public Farmer farmer;
        public FarmingImplement tractor;

        // But `crops` is set here to default to an empty array (length 0)
        public Crop[] crops = new Crop[0];

        // In order to have a farm, you need a farmer and a tractor
        // This constructor ensures there's no other way to build a farm
        public Farm(Farmer farmer, FarmingImplement tractor)
        {
            // As long as we use the `this` (self-reference) operator, we can
            // give our parameters and our instance fields the same name
            this.farmer  = farmer;
            this.tractor = tractor;
        }

        // When we Grow an array of crops, we store them in our farm (presumably in the ground)
        public void Grow(Crop[] crops)
        {
            // In order to plant crops, you have to have a farmer run a tractor
            // For every crop we plant, we (arbitrarily) must operate the tractor for one hour.
            var hours = crops.Length;

            // This doesn't use a self-reference operator, but it's still refering to the instance field
            tractor.Operate(farmer, hours);

            this.crops = crops;
        }

        // When we Harvest the crops, we dig them out of the ground and return them. 
        public Crop[] Harvest()
        {
            // In order to harvest crops, you have to have a farmer run a tractor
            // For every crop harvested, we (arbitrarily) must operate the tractor for 1.5 hours.
            var hours = (int)(Math.Round(1.5 * crops.Length));

            tractor.Operate(farmer, hours);

            // We put the crops in a hopper so we can reset the instance field.
            var hopper = crops;

            // It's important to reset our crops to a new empty array
            // Otherwise we can harvest the same crops multiple times!
            crops = new Crop[0];

            // Finally, we return the temporary list of our crops
            return hopper;
        }
    }
}
