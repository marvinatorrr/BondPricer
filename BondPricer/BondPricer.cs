
namespace BondPricer
{
    public class NaivePricer : IBondPricer
    {
        public decimal Calculate(decimal ParValue, decimal CouponRate,
            decimal YieldToMaturity, decimal YearsToMaturity)
        {
            var result = 0m;

            var coupon = ParValue * CouponRate;

            for(var i = 0; i < YearsToMaturity - 1; i++)
            {
                result += coupon / 
                    (decimal)Math.Pow((double)(1 + YieldToMaturity), i + 1);
            }

            result += (coupon + ParValue) / 
                (decimal)Math.Pow((double)(1 + YieldToMaturity), (double)YearsToMaturity);

            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
    }

    public class ClosedFormPricer : IBondPricer
    {
        public decimal Calculate(decimal ParValue, decimal CouponRate,
            decimal YieldToMaturity, decimal YearsToMaturity)
        {
            var coupon = ParValue * CouponRate;

            var pvCoupons = coupon * (1 - (decimal)Math.Pow((double)(1 + YieldToMaturity), (double)-YearsToMaturity)) / YieldToMaturity;

            var pvPar = ParValue / (decimal)Math.Pow((double)(1 + YieldToMaturity), (double)YearsToMaturity);

            var result = pvCoupons + pvPar;

            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
    }

    public interface IBondPricer
    {
        decimal Calculate(decimal ParValue, decimal CouponRate, decimal YieldToMaturity, decimal YearsToMaturity);
    }
        
}