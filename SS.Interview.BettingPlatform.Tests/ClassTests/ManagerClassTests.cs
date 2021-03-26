using NUnit.Framework;
using SS.Interview.BettingPlatform.Managers;
using SS.Interview.BettingPlatform.Requests;
using SS.Interview.BettingPlatform.Shared;
using System;

namespace SS.Interview.BettingPlatform.Tests.ClassTests
{
    [TestFixture]
    class ManagerClassTests
    {
        private class Resources : IDisposable
        {
            public readonly MarketManager MarketManager;

            public Resources()
            {
                MarketManager = new MarketManager();
            }
            public void Dispose()
            { }
        }

        [TestCase(Constants.Market.Sport.Tennis)]
        [TestCase(Constants.Market.Sport.Football)]
        public void Get_Success(string sport)
        {
            using var resources = new Resources();

            //Given
            var requestModel = new MarketRequest
            {
                Fixture = Constants.Market.Fixture.SomeFixture,
                Sport = sport
            };

            //When
            var result = resources.MarketManager.Get(requestModel);

            //Then
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [TestCase(null, Constants.Market.Fixture.SomeFixture, Constants.Market.Validation.SportMissing)]
        [TestCase("", Constants.Market.Fixture.SomeFixture, Constants.Market.Validation.SportMissing)]
        [TestCase(" ", Constants.Market.Fixture.SomeFixture, Constants.Market.Validation.SportMissing)]
        [TestCase("Boxing", Constants.Market.Fixture.SomeFixture, Constants.Market.Validation.SportNotFound)]
        [TestCase(Constants.Market.Sport.Football, null, Constants.Market.Validation.FixtureMissing)]
        public void Get_Invalid(string sport, string fixture, string expectedErrorMessage)
        {
            using var resources = new Resources();

            //Given
            var requestModel = new MarketRequest
            {
                Fixture = fixture,
                Sport = sport
            };

            //When
        
            var exception = Assert.Throws<Exception>(() => resources.MarketManager.Get(requestModel));

            //THEN
            Assert.AreEqual(expectedErrorMessage, exception.Message);
        }
    }
}
