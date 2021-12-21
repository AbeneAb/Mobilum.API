using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobilum.API.Models;
using Mobilum.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mobilum.UnitTest
{
    [TestClass]
    public class RegionServiceUnitTest
    {
        public static IEnumerable<object[]> GetPhoneNumbersResult() 
        {
            yield return new object[]
            {
                new PhoneNumberWithResult("00131313", "Region 1"),
            };
            yield return new object[]
            {
                new PhoneNumberWithResult("00112333", "Region 2"),
            };
            yield return new object[]
            {
                new PhoneNumberWithResult("001224434", "Region 3"),
            };
            yield return new object[]
            {
                new PhoneNumberWithResult("00123311", "Region 4"),
            };
        }

        [TestMethod]
        [DynamicData(nameof(GetPhoneNumbersResult), DynamicDataSourceType.Method)]
        public async Task DetectCountryFromPhoneNumberTest(PhoneNumberWithResult testData)
        {
            // Arrange
            MobilumContext mockContext = MoqDbContext.Instance.GetContext();
            IRegionService service = new RegionService(mockContext);
            var expected = testData.Name;

            // Act
            var actual = await service.DetectCountryFromPhoneNumber(testData.PhoneNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
