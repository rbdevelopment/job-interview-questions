using Xunit;

namespace Patterns
{
    public class SingletonPattern
    {
        public sealed class Singleton
        {
            private static Singleton _singleton;

            private Singleton()
            {
            }

            public static Singleton GetInstance()
            {
                return _singleton ?? (_singleton = new Singleton());
            }
        }

        [Fact]
        public void ReturnsTheSameInstance()
        {
            var firstRequest = Singleton.GetInstance();
            var secondRequest = Singleton.GetInstance();

            Assert.Equal(firstRequest, secondRequest);
        }
    }
}