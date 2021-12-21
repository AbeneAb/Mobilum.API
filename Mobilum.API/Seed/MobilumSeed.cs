using Mobilum.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilum.API.Seed
{
    public class MobilumSeed
    {
        public static async Task Seed(MobilumContext context) 
        {
            if (!context.Regions.Any()) 
            {
                context.Regions.AddRange(GetPreconfiguredRegion1());
                context.Regions.AddRange(GetPreconfiguredRegion2());
                await context.SaveChangesAsync();
            }
        }
        private static IEnumerable<Region> GetPreconfiguredRegion1() 
        {
            IList<Region> regions = new List<Region>();
            regions.Add(new Region() { Name = "Country1", RegionCode = "001" });
            regions.Add(new Region() { Name = "Region2", RegionCode = "0011" });
            regions.Add(new Region() { Name = "Region3", RegionCode = "0012" });
            regions.Add(new Region() { Name = "Region4", RegionCode = "00123311" });
            regions.Add(new Region() { Name = "Region5", RegionCode = "001456" });
            return regions;
        }
        private static IEnumerable<Region> GetPreconfiguredRegion2() 
        {
            IList<Region> regions = new List<Region>();
            regions.Add(new Region() { Name = "Country2", RegionCode = "002" });
            regions.Add(new Region() { Name = "Region6", RegionCode = "0021" });
            regions.Add(new Region() { Name = "Region7", RegionCode = "0022" });
            regions.Add(new Region() { Name = "Region8", RegionCode = "00223311" });
            regions.Add(new Region() { Name = "Region9", RegionCode = "002456" });
            return regions;
        }

    }
}
