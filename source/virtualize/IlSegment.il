// [35 7 - 35 44]
    IL_0087: newobj       instance void Assets.Scripts.BaseClass::.ctor()
    IL_008c: stloc.s      baseClass

    // [36 7 - 36 41]
    IL_008e: newobj       instance void Assets.Scripts.SubClass::.ctor()
    IL_0093: stloc.s      subClass

    // [37 7 - 37 62]
    IL_0095: newobj       instance void Assets.Scripts.FinallySubClass::.ctor()
    IL_009a: stloc.s      finallySubClass

    // [38 7 - 38 31]
    IL_009c: ldloc.s      baseClass
    IL_009e: callvirt     instance void Assets.Scripts.BaseClass::DoSomethingA()

    // [39 7 - 39 32]
    IL_00a3: ldloc.s      baseClass
    IL_00a5: callvirt     instance void Assets.Scripts.BaseClass::DoSomethingA2()

    // [40 7 - 40 31]
    IL_00aa: ldloc.s      baseClass
    IL_00ac: callvirt     instance void Assets.Scripts.BaseClass::DoSomethingB()

    // [41 7 - 41 31]
    IL_00b1: call         void Assets.Scripts.BaseClass::DoSomethingC()

    // [42 7 - 42 30]
    IL_00b6: ldloc.s      subClass
    IL_00b8: callvirt     instance void Assets.Scripts.SubClass::DoSomethingA()

    // [43 7 - 43 31]
    IL_00bd: ldloc.s      subClass
    IL_00bf: callvirt     instance void Assets.Scripts.SubClass::DoSomethingA2()

    // [44 7 - 44 30]
    IL_00c4: ldloc.s      subClass
    IL_00c6: callvirt     instance void Assets.Scripts.SubClass::DoSomethingB()

    // [45 7 - 45 31]
    IL_00cb: call         void Assets.Scripts.BaseClass::DoSomethingC()

    // [46 7 - 46 37]
    IL_00d0: ldloc.s      finallySubClass
    IL_00d2: callvirt     instance void Assets.Scripts.FinallySubClass::DoSomethingA()

    // [47 7 - 47 38]
    IL_00d7: ldloc.s      finallySubClass
    IL_00d9: callvirt     instance void Assets.Scripts.FinallySubClass::DoSomethingA2()

    // [48 7 - 48 37]
    IL_00de: ldloc.s      finallySubClass
    IL_00e0: callvirt     instance void Assets.Scripts.FinallySubClass::DoSomethingB()

    // [49 7 - 49 31]
    IL_00e5: call         void Assets.Scripts.BaseClass::DoSomethingC()
