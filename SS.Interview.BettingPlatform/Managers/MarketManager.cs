using System;
using System.Linq;
using SS.Interview.BettingPlatform.Interfaces;
using SS.Interview.BettingPlatform.MarketGeneration.Generators;
using SS.Interview.BettingPlatform.MarketGeneration.Models;
using SS.Interview.BettingPlatform.Requests;
using SS.Interview.BettingPlatform.Shared;

namespace SS.Interview.BettingPlatform.Managers
{
    public class MarketManager : IMarketManager
    {
        /// <summary>
        /// Get Array of Markets
        /// </summary>
        /// <param name="request">MarketRequest</param>
        /// <returns>Market[]</returns>
        public Market[] Get(MarketRequest request)
        {
            //validate we have values provided in the request
            if (string.IsNullOrWhiteSpace(request.Sport))
                throw new Exception(Constants.Market.Validation.SportMissing);

            if (string.IsNullOrWhiteSpace(request.Fixture))
                throw new Exception(Constants.Market.Validation.FixtureMissing);

            //switch on different sports
            switch (request.Sport.Trim().ToUpper())
            {
                case Constants.Market.Sport.Football:
                    return new FootballMarketGenerator().GetMarkets(request.Fixture);
                case Constants.Market.Sport.Tennis:
                    return new TennisMarketGenerator().GetMarkets(request.Fixture).ToArray();
            }

            //sport not found
            throw new Exception(Constants.Market.Validation.SportNotFound);
        }
    }
}