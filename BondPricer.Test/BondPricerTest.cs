namespace BondPricer.Test
{
    public class BondPricerTest
    {
        private readonly NaivePricer _naivePricer;
        private readonly ClosedFormPricer _closedFormPricer;

        public BondPricerTest()
        {
            _naivePricer = new NaivePricer();
            _closedFormPricer = new ClosedFormPricer();
        }

        [TestCaseSource(nameof(BondArguments))]
        public void NaiveTest(decimal parValue, decimal couponRate, decimal YieldToMaturity, decimal YearsToMaturity, decimal expected)
        {
            var result = _naivePricer.Calculate(parValue, couponRate, YieldToMaturity, YearsToMaturity);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(BondArguments))]
        public void ClosedFormTest(decimal parValue, decimal couponRate, decimal YieldToMaturity, decimal YearsToMaturity, decimal expected)
        {
            var result = _closedFormPricer.Calculate(parValue, couponRate, YieldToMaturity, YearsToMaturity);
            Assert.That(result, Is.EqualTo(expected));
        }

        public static object[] BondArguments =
        {
            new object[] { 1000m, 0.07m, 0.085m, 5m, 940.89m }
        };
    }
}