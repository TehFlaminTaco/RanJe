using System.Collections.Generic;


namespace RanJe.Compile.Links{
    abstract class Link : Atom{
        List<Link> arguments = new List<Link>(3); // We max out the capacity of the list to 3, despite the fact that Lists are usually dynamically sized
                                                  // Because the highest Airty of any link is Tri. (I hope).
        public abstract int Airity{
            get;
        }
    }
}