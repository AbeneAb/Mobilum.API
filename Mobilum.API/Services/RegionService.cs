using Microsoft.EntityFrameworkCore;
using Mobilum.API.Models;
using Mobilum.API.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilum.API.Services
{
    public class RegionService : IRegionService
    {

        private readonly MobilumContext _context;
        private readonly Tree _cachedRegionData;
        public RegionService(MobilumContext mobilumContext)
        {
            _context = mobilumContext;
            _cachedRegionData = Tree.Instace;
        }
        public async Task<string> DetectCountryFromPhoneNumber(string phoneNumber)
        {
            if (!_cachedRegionData.DataIsLoaded)
                _cachedRegionData.InsertData(await GetAllRegions());

            return _cachedRegionData.Prefix(phoneNumber).GetShortestPathEndNode().Name;
        }
        private async Task<IEnumerable<Region>> GetAllRegions()
        {
            return await _context.Regions.AsNoTracking().ToListAsync();
        }
    }
}
