using Microsoft.EntityFrameworkCore;
using Mobilum.API.Models;

namespace Mobilum.Benchmark
{
    internal sealed class MoqDbContext
    {
        private MoqDbContext() 
        {
        }
        public static MoqDbContext Instance { get { return NestedMoqDbContext.instance; } }
        private class NestedMoqDbContext
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static NestedMoqDbContext()
            {
            }

            internal static readonly MoqDbContext instance = new MoqDbContext();
           
        }
        internal MobilumContext GetContext()
        {
            var options = new DbContextOptionsBuilder<MobilumContext>()
                           .UseInMemoryDatabase("dbo")
                           .Options;
            var mockContext = new MobilumContext(options);
            mockContext.Regions.RemoveRange(mockContext.Regions);
            mockContext.Regions.AddRange(
           new Region { Name = "Country 1", RegionCode = "001" },
                   new Region { Name = "Region 1", RegionCode = "0011" },
                   new Region { Name = "Region 2", RegionCode = "00122" },
                   new Region { Name = "Region 3", RegionCode = "00123311" });

            mockContext.SaveChanges();

            return mockContext;

        }
    }
}
