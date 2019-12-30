using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout.Entities
{
    public class Basket
    {
        public IList<LineItem> LineItems { get; }

        public Basket()
        {
            LineItems = new List<LineItem>();
        }
        
    }
}
