using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc415.CodingTracker
{
    internal class CodingSession
    {
        DateTime startTime;
        DateTime endTime;
        TimeSpan duration;

        public CodingSession() 
        {
            startTime = DateTime.Now;
        }

        public void EndCodingSession()
        {
            endTime = DateTime.Now;
            duration = startTime - endTime;
        }
    }
}
