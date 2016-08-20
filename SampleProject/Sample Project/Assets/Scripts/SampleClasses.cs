using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class SampleSimpleClass
    {
        public int VT;
        public string RT;
    }

    abstract class SampleBase
    {
        public static string ClassFieldSample = @"Miaow!";
        public int InstanceFieldSample;

        public virtual string SampleMethod()
        {
            return @"From Base Instance.";
        }
    }

    class SampleSubclass : SampleBase
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
    }

    class SampleGenericsClass<T> where T : SampleBase
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

    class Doge
    {
        public override string ToString()
        {
            return "Instance Doge";
        }
    }
}
