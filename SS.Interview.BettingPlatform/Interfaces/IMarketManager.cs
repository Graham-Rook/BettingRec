using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;

namespace SS.Interview.BettingPlatform.Interfaces
{
    public interface IMarketManager
    {
        Market[] Get(MarketRequest request);
    }
}
