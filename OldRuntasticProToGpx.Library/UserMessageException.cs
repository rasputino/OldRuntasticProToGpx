using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldRuntasticProToGpx.Library
{
    public class UserMessageException:Exception
    {

        public UserMessageException(string msj):base(msj) { }
    }
}
