using System;
using Gtk;

namespace GtkCategoryGenerator
{
    partial class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {

            Application.Init();

            try
            {
                clsArgsConfig.Instance();
              
                clsArgsConfig.Instance()._setArgs(args);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (!clsArgsConfig.Instance()._validateCommandKey())
            {
                return;
            }
            
            try
            {
                string usingStr = "";
                string namespaceStr = "";
                string classStr = "";

                _parseCsContent(clsArgsConfig.Instance().FileDirPath, ref usingStr, ref namespaceStr, ref classStr);
                
                string fileDir = clsFolder._getFolderNamePath(clsArgsConfig.Instance().FileDirPath);
                string fileName =  clsPath._getFileNameNoExtension(clsArgsConfig.Instance().FileDirPath);
                
                var categoryName = clsClipboard._getText();

                if (categoryName == "")
                {
                    Console.WriteLine("Category name is missing. Copy and paste the Category name");
                    return;
                }
                if (!clsFolder._isFolder(fileDir))
                {
                    Console.WriteLine("There is no folder.");
                    return;   
                }
                
                string templateContent = clsFile._load_static( clsFile._getExePath_replace("categoryTemplate.txt"));
      
                templateContent = templateContent._replaceReplaceStr("{$Using}", usingStr);
                templateContent = templateContent._replaceReplaceStr("{$NamespaceName}", namespaceStr);                
                templateContent = templateContent._replaceReplaceStr("{$ClassName}", classStr);
;
                string classFilePath = fileDir._trimEnd("/") + "/" + fileName + "+" + categoryName  + ".cs";

                clsFile._saveFilePath(templateContent,classFilePath);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}