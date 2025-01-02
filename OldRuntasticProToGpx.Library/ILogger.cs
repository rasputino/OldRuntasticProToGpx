using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldRuntasticProToGpx.Library
{
    public interface ILogger
    {
        void Log(string message);

        void LogSplitted(string message);

        void ClearAndLog(string message);
    }
}
