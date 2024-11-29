using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    internal interface IPayment
    {
        public void ProcessPayment(decimal amount);
        public bool IsActive();
        public void GetDetails();
    }
}
