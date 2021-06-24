using System.Collections.Generic;
using System.Threading.Tasks;

namespace SS.App.Data
{
    public class SsDataService
    {
        public async Task<IEnumerable<SSData>> GetAsync() => new List<SSData>
        {
            new SSData(),
            new SSData(),
            new SSData(),
        };
    }
}
