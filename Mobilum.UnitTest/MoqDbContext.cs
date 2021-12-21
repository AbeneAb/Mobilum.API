using Microsoft.EntityFrameworkCore;
using Mobilum.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilum.UnitTest
{
    internal class MoqDbContext
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
                new Region { Name = "Region 1", RegionCode = "001" },
                        new Region { Name = "Region 2", RegionCode = "0011" },
                        new Region { Name = "Region 3", RegionCode = "00122" },
                        new Region { Name = "Region 4", RegionCode = "00123311" });

            mockContext.SaveChanges();

            return mockContext;
        }
    }
}
