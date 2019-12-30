using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout.Entities
{
    public class Basket
    {
        public IList<LineItem> LineItems { get; set; }

        public Basket()
        {
            LineItems = new List<LineItem>();
        }
        public decimal Total()
        {
            return LineItems.Sum(scannedItem => scannedItem.Total);
        }
    }
}
