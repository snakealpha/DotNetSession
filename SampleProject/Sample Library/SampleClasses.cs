using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class SampleSimpleClass
    {
        public int VT;
        public string RT;
    }

    public abstract class SampleBase
    {
        public static string ClassFieldSample = @"Miaow!";
        public int InstanceFieldSample;

        public virtual string SampleMethod()
        {
            return @"From Base Instance.";
        }
    }

    public sealed class SampleSubclass : SampleBase
    {
        public int SampleProperty { get; set; }

        private int SubclassField;
        
        public override string SampleMethod()
        {
            List<string> baseList = new List<string>();
            for (int i = 0; i < 255; i++)
            {
                baseList.Add(i.ToString());
            }

            int randomResult = new System.Random().Next()%256;
            foreach (var item in baseList)
            {
                if (randomResult.ToString() == item)
                    return item;
            }

            return @"";
        }

        public static string SampleClassMethod(SampleSubclass fakeArgument1, int fakeArgument2)
        {
            return @"The quick brown fox jumps over the lazy dog.";
        }

        public string NonvirtualMethod()
        {
            return @"Nonvirtual Method";
        }

        public void SimpleControlFlow()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i != 10; i++)
            {
                builder.Append(i.ToString());
            }
        }

        IEnumerable<int> ForeachSampleEnumerator()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield break;
        }

        public void ForeachSample()
        {
            List<int> list = new List<int>();
            foreach (var value in list)
            {
                
            }
        }
    }

    public class SampleGenericsClass<T> where T : SampleBase
    {
        public string SampleMethod(T instance)
        {
            return instance.SampleMethod();
        }

        public string SampleGenericsMethod<TArg>(TArg argu)
        {
            return argu.ToString();
        }
    }

    public class Doge
    {
        public override string ToString()
        {
            return "Instance Doge";
        }
    }
}
