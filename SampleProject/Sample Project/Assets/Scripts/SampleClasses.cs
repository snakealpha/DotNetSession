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

            var baseInstance = new BaseClass();
            var subInstance = new SubClass();
            var fsubInstance = new FinallySubClass();

            baseInstance.DoSomethingA();
            baseInstance.DoSomethingA2();
            baseInstance.DoSomethingB();
            BaseClass.DoSomethingC();

            subInstance.DoSomethingA();
            subInstance.DoSomethingA2();
            subInstance.DoSomethingB();
            SubClass.DoSomethingC();

            fsubInstance.DoSomethingA();
            fsubInstance.DoSomethingA2();
            fsubInstance.DoSomethingB();
            FinallySubClass.DoSomethingC();

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
            foreach (var value in ForeachSampleEnumerator())
            {
                // do something.
            }
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

    class BaseClass
    {
        public virtual void DoSomethingA()
        {
            // ...Do something
        }

        public virtual void DoSomethingA2()
        {
            // ...Do something
        }

        public void DoSomethingB()
        {
            // ...Do something
        }

        public static void DoSomethingC()
        {
            // ...Do something
        }
    }

    class SubClass:BaseClass
    {
        public override void DoSomethingA()
        {
            // ...Do something
        }

        public sealed override void DoSomethingA2()
        {
            // ...Do something
        }

        public new void DoSomethingB()
        {
            // ...Do something
        }
    }

    sealed class FinallySubClass:BaseClass
    {
        public override void DoSomethingA()
        {
            // ...Do something
        }

        public override void DoSomethingA2()
        {
            // ...Do something
        }

        public new void DoSomethingB()
        {
            // ...Do something
        }
    }
}
