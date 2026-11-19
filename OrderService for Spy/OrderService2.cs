using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService_for_Spy
{
    public class OrderService
    {
        private readonly ILogger _logger; // клас OrderService залежить від логувальника (ILogger)

        public OrderService(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateOrder()
        {
            _logger.Log("Order created"); // при створенні замовлення працює логер
        }
    }
}
