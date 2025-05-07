using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
   public class UnAuthorizedException(string message = "Invalied Email Or Passwor!"): Exception(message)
    {

    }
}
