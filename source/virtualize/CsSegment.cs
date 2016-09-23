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
