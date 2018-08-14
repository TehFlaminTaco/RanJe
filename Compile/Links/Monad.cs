namespace RanJe.Compile.Links{
    abstract class Monad : Link{
        public override int Airity{
            get{
                return 1;
            }
        }
    }
}