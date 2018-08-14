using System.Collections.Generic;

namespace RanJe{
    class Flags{
        public static List<string> GetOptions(string[] args){
            List<string> flags = new List<string>();
            for(int i=0; i < args.Length; i++){
                if(args[i].Length > 0 && args[i][0] == '-'){
                    flags.Add(args[i].Substring(1));
                }
            }
            return flags;
        }
    }
}