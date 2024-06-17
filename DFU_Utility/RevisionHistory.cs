using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFU_Utility
{
    public class RevisionHistory
    {
        static public string RevisionHeader = @"DFU_Utility";
        static public string MajorStep = "1";
        static public string MinorStep = "0.01";
        static public string RevisionDate = @"6/17/2024";

        static public string GetCurrentVersion()
        {
            return MajorStep + "." + MinorStep;
        }
    }
}
