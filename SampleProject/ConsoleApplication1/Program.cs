using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<AStruct, int> dict = new Dictionary<AStruct, int>();
            var a = new AStruct();
            var b = new AStruct();;

            for (var i = 0; i != 1000; i++)
            {
                dict[new AStruct() {member = i + 1}] = i + 1;
            }
            dict[a] = 0;

            for (var i = 0; i != 100000000; i++)
            {
                var tar = dict[a];
            }
        }

        static void RunBoxMethod()
        {
            int v = 1;
            BoxMethod(v);               // Box!

            object objV = v;            // Box!
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
}
