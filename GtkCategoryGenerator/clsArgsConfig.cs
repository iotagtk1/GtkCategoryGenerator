using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace GtkCategoryGenerator
{
    public class clsArgsConfig
    {
        private static clsArgsConfig _singleInstance = null;

        public string FileDirPath = "";
        public static clsArgsConfig Instance()
        {
            if (_singleInstance == null) {
                _singleInstance = new clsArgsConfig();
            }
            return _singleInstance;
        }
   
        //次の値がコマンドでないことを確認用
        private List<string> commndKeyArray = new List<string> {
            "-fileDir"};
        public Boolean _validateCommandKey()
        {
            
            if (FileDirPath == "")
            {
                Console.WriteLine("-FileDirが指定されていない");
                return false;
            }

            if (!clsFile._isFile(FileDirPath))
            {
                Console.WriteLine("ファイルがありません");
                return false;
            }
            
            if (FileDirPath._indexOf(".cs") == -1)
            {
                Console.WriteLine("csファイルではありません");
                return false;
            }

            return true;
        }
        public void _setArgs(string[] args)
        {

            int i = 0;
            foreach (var commandKey in args)
            {
                if (commandKey._indexOf("-fileDir") != -1)
                {
                    if (args._safeIndexOf(i + 1) && 
                        commndKeyArray.IndexOf(args[i+1]) == -1 && 
                        args[i+1] != ""){
                        FileDirPath = args[i + 1];
                    }
                    i++;
                    continue;
                }


                i++;
            }
        }

    }
}