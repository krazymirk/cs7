using System.Threading.Tasks;

namespace WhatsNewInCS7
{
    public class ValueTasks
    {
        private bool cache = false;
        private int cacheResult;

        public ValueTask<int> CachedFunc()
        {
            return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
        }
        private async Task<int> LoadCache()
        {
            // simulate async work:
            await Task.Delay(100);
            cacheResult = 100;
            cache = true;
            return cacheResult;
        }
    }
}
