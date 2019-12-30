﻿using Kata.Checkout.Entities;
using System.Text;

namespace Kata.Checkout.Services
{
    public interface IScanner
    {
        Basket Scan(Basket basket, Item item, int quantity);
    }
}
