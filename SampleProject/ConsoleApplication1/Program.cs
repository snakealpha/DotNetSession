using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        struct SStruct
        {
            private int value;

            public void Change(int value)
            {
                this.value = value;
            }
        }

        delegate void dele1(object obj);

        delegate void dele2(object obj);

        static void Main(string[] args)
        {
            var structObj = new SStruct();
            structObj.Change(42);
            object boxedObj = structObj;            // Box
            ((SStruct)boxedObj).Change(119);        // boxedObj is still 42

            dele2 dele = (_) =>
            {
            };

            //deleFunc(dele);
        }

        static void RunBoxMethod()
        {
            int v = 1;
            BoxMethod(v);               // Box!

            object objV = v;            // Box!
        }

        static void deleFunc(dele1 dele)
        {
        }

        static int BoxMethod(object boxedValue)
        {
            int v = (int)boxedValue;
            return v;
        }

        static void RunNormalMethod()
        {
            int v = 1;
            for (int i = 0; i != 100000000; i++)
                NormalMethod(v);
        }

        static int NormalMethod(int value)
        {
            return value;
        }
    }

    struct AStruct:IEquatable<AStruct>
    {
        public int member;

        public bool Equals(AStruct obj)
        {
            return member == obj.member;
        }

        public override int GetHashCode()
        {
            return member;
        }
    }

    class SampleClass
    {
        public void TriggerBox()
        {
            string ReferenceInstance = "1";
            MakeArgumentBox(ReferenceInstance);

            int? valueInstance = 1;
            MakeArgumentBox(valueInstance);
        }

        private bool MakeArgumentBox<T>(T? valueObject) where T:struct 
        {
            return valueObject != null;
        }

        private bool MakeArgumentBox<T>(T valueObject)
        {
            return valueObject != null;
        }

        private void DoSomethind()
        {
            
        }

        interface IStructInterface
        {
            void DoSomething();
        }
    }

    class BaseClass
    {
        protected virtual void DoSomething()
        {
            // ...do something
        }

        public BaseClass()
        {
            DoSomething();
        }
    }

    class SubClass:BaseClass
    {
        private readonly string Text;

        protected override void DoSomething()
        {
            base.DoSomething();
            System.Diagnostics.Debug.Assert(Text != null);  // EXCEPTION!!!
        }

        public SubClass():base()
        {
            Text = "The quick brown fox jumps over the lazy dog.";
        }
    }
}
