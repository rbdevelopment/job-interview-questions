using Xunit;

namespace Patterns
{
    public class AbstractFactoryPattern
    {
        private enum ProductTypes
        {
            One,
            Two
        }

        private interface IProduct
        {
        }

        private interface IFactory
        {
            IProduct CreateProduct(ProductTypes type);
        }

        private class ProductOne : IProduct
        {
        }

        private class ProductTwo : IProduct
        {
        }

        private class Factory : IFactory
        {
            public IProduct CreateProduct(ProductTypes type)
            {
                switch (type)
                {
                    case ProductTypes.One:
                        return new ProductOne();
                    case ProductTypes.Two:
                        return new ProductTwo();
                    default:
                        return null;
                }
            }
        }

        [Fact]
        public void FactoryProducesDifferentProductsBasedOnParameter()
        {
            var factory = new Factory();

            var one = factory.CreateProduct(ProductTypes.One);
            var two = factory.CreateProduct(ProductTypes.Two);

            Assert.True(one is ProductOne);
            Assert.True(two is ProductTwo);
        }
    }
}