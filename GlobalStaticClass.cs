using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamaExamFullstack
{
    public static class GlobalSetting
    {
        public static string baseAddress = "https://localhost:5001/";
    }
    public static class GlobalLoginState
    {
        public static int LoggedCreatorID = -1;
        public static int LoggedParticipantID = -1;
    }
}
