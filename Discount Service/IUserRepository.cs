using System;
using System.Collections.Generic;
using System.Text;

namespace Discount_Service
{
    public interface IUserRepository
    {
        bool IsPremiumUser(int userId);
    }
}
