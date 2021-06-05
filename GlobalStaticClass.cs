using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;


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
        public static NavigationManager navigationManager;
        public static void VerifyCreator(int CheckedID)
        {
            if (LoggedCreatorID != CheckedID) navigationManager.NavigateTo("/");
        }
        public static void VerifyParticipant(int CheckedID)
        {
            if (LoggedParticipantID != CheckedID) navigationManager.NavigateTo("/");
        }
    }
}
