using Kata.Checkout.Entities;

namespace Kata.Checkout.Services
{
    public interface IDiscountProcessor
    {
        Basket Apply(Basket basket);
    }
}
