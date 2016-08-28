using System;

namespace Assets.Scripts
{
    public class BoxSample
    {
        public void SampleMethod()
        {
            PureStruct? member = new PureStruct();
            
            GenericMethod(member);
        }

        public bool GenericMethod<T>(T? argu) where T : struct
        {
            return argu != null;
        }
    }

    public struct PureStruct
    {
        public int Field;

        public override string ToString()
        {
            return "Maru 9";
        }
    }
}