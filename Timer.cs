using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamaExamFullstack
{
    public static class GlobalTimer
    {
        static int  _timer;
        public static int CountTimer
        {
            get { return _timer; }
            set { _timer = value; }
        }

    }
}
