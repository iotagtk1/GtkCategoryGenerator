using System;
using System.Collections;
using Gtk;

namespace GtkCategoryGenerator
{
    partial class Program
    {
        static void _parseCsContent(string csFilePath,ref string usingStr ,
            ref string namespaceStr ,ref string classStr ){

            string csContnet = clsFile._load_static(csFilePath);

            string patarn0 = "(using.*?namespace)";
            ArrayList usingArray = clsUtility._patarnMatch(csContnet, patarn0,1);
            if (usingArray.Count > 0)
            {
                usingStr = usingArray[0] != null ? usingArray[0].ToString() : "";
                usingStr = usingStr._replaceReplaceStr("namespace", "");
                usingStr = usingStr.TrimStart().TrimEnd();
                
            }
            string patarn1 = "namespace(.*?)" + Environment.NewLine;
            ArrayList namespaceArray = clsUtility._patarnMatch(csContnet, patarn1,1);
            if (namespaceArray.Count > 0)
            {
                namespaceStr = namespaceArray[0] != null ? namespaceArray[0].ToString() : "";
                namespaceStr = namespaceStr.TrimStart().TrimEnd();
            }
            string patarn2 = "class(.*?)" + Environment.NewLine;
            ArrayList classArray = clsUtility._patarnMatch(csContnet, patarn2,1);
            if (classArray.Count > 0)
            {
                classStr = classArray[0] != null ? classArray[0].ToString() : "";
                classStr = classStr.TrimStart().TrimEnd();
            }

        }       
    }
}