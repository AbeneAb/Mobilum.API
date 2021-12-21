using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Mobilum.API.Search;
using Mobilum.API.Services;
using Mobilum.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilum.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    internal class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<BenchmarkBriantrust>();
        }
    }
    public class BenchmarkBriantrust
    {
        [Benchmark]
        public async Task RunSearch()
        {
            MobilumContext mockContext = GetMobilumContext();
            IRegionService service = new RegionService(mockContext);

            var phoneNumbers = new List<string>
            {
                "00131313",
                "00112333",
                "001224434",
                "00123311",
            };
            foreach (var phoneNumber in phoneNumbers)
            {
                var country = await service.DetectCountryFromPhoneNumber(phoneNumber);

                if (!string.IsNullOrEmpty(country))
                    Console.WriteLine($"{phoneNumber}  :  {country}");
            }
        }

        [Benchmark]
        public MobilumContext GetMobilumContext()
        {
            return MoqDbContext.Instance.GetContext();
        }
    }
}
