using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilum.UnitTest
{
    public class PhoneNumberWithResult
    {
        public PhoneNumberWithResult(string phoneNumber, string name)
        {
            PhoneNumber = phoneNumber;
            Name = name;
        }

        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
