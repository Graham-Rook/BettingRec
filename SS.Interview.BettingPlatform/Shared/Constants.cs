namespace SS.Interview.BettingPlatform.Shared
{
    public class Constants
    {
        public static class Market
        {
            public static class Sport
            {
                public const string Tennis = "TENNIS";
                public const string Football = "FOOTBALL";
            }

            public static class Fixture
            {
                public const string SomeFixture = "SomeFixture";
            }
            public static class Validation
            {
                public const string SportMissing = "No sport has been provided.";
                public const string SportNotFound = "The provided sport is not found.";
                public const string FixtureMissing = "No fixture has been provided.";
            }
        }

    }
}
