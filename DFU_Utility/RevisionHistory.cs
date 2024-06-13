using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFU_Utility
{
    public class RevisionHistory
    {
        static public string RevisionHeader = @"UniversalDfuTool";
        static public string MajorStep = "1";
        static public string MinorStep = "0.00";
        static public string RevisionDate = @"6/13/2024";

        static public string GetCurrentVersion()
        {
            return MajorStep + "." + MinorStep;
        }
    }
}
