
using System;

namespace ConsoleApp1.Models
{
    public class Territory
    {
        public int territoryId { get; private set; }
        public string territoryDescription { get; private set; }
        public int regionId { get; private set; }

        public Territory(int territoryId, string territoryDescription, int regionId)
        {
            if (regionId < 0 && regionId > 4)
                throw new IndexOutOfRangeException("Region range is from 0 to 4");
            this.territoryId = territoryId;
            this.territoryDescription = territoryDescription;
            this.regionId = regionId;
        }
    }
}
