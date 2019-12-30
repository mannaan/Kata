using Kata.Checkout.Entities;

namespace Kata.Checkout.Services
{
    public interface IDiscountManager
    {
        Basket ApplyDiscounts(Basket basket);
    }
}
