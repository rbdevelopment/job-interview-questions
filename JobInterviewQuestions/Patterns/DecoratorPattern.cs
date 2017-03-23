using NSubstitute;
using Xunit;

namespace Patterns
{
    public class DecoratorPattern
    {
        public interface IDoSomething
        {
            int Something();
        }

        private class Decorator : IDoSomething
        {
            private readonly IDoSomething _inner;

            public Decorator(IDoSomething inner)
            {
                _inner = inner;
            }

            public int Something()
            {
                return _inner.Something();
            }
        }

        [Fact]
        public void ExternalWrapperClassWithTheSameInterfaceUsesInternalClass()
        {
            var inner = Substitute.For<IDoSomething>();
            const int result = 10;
            inner.Something().Returns(result);

            IDoSomething decorator = new Decorator(inner);
            var decoratorResult = decorator.Something();

            inner.Received().Something();
            Assert.Equal(result, decoratorResult);
        }
    }
}