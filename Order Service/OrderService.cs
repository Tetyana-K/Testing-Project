using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Service
{
    public class OrderService
    {
        private readonly ILogger _logger; // клас має залежність від логера (ILogger)

        public OrderService(ILogger logger) // у конструктор передається об'єкт логера
        {
            _logger = logger;
        }

        public int CalculateTotal(int price, int quantity)
        {
            return price * quantity;
        }
    }
}
