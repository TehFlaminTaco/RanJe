using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace RanJe
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if(args.Length == 0){
                Console.WriteLine("Please specify a file to run!");
                return;
            }
            List<string> flags = Flags.GetOptions(args);
            
            string file = args[0];
            if(!File.Exists(file)){
                Console.WriteLine("Could not find file with name '{0}'", file);
                return;
            }
            byte[] file_cont = File.ReadAllBytes(file);
            char[] code;
            if(flags.Contains("u")){
                code = UTF8Encoding.UTF8.GetChars(file_cont, 0, file_cont.Length);
            }else{
                code = SMBC.Encoding.GetChars(file_cont, 0, file_cont.Length);
            }

            
        }
    }
}
