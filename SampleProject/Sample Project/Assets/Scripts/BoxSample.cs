using System;
using System.Collections.Generic;

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
            List<int> collection = new List<int>();
            collection.Add(1);
            collection.Add(1);
            collection.Add(1);
            collection.Add(1);
            collection.Add(1);
            collection.Add(1);

            foreach (var item in collection)
            {
                // ...do something
            }

            var enumerator = collection.GetEnumerator();
            for (; enumerator.MoveNext();)
            {
                // ...do something
            }
            enumerator.Dispose();

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