using System;
using System.Collections.Generic;
using System.Text;

namespace Discount_Service
{
    public class DiscountService
    {
        // DiscountService залежить від інтерфейсу IUserRepository, а не від конкретної реалізації бази даних
        private readonly IUserRepository _repository;

        public DiscountService(IUserRepository repository)
        {
            _repository = repository;
        }

        public int CalculateDiscount(int userId)
        {
            if (_repository.IsPremiumUser(userId))
                return 20;

            return 5;
        }
    }
}
