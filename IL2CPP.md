当选择使用IL2CPP作为代码后端时，C++代码会在当前项目的目录下进行缓存，其路径为

    {Project Path}/Temp/StagingAera/Data/il2cppOutput

对这个目录进行观察，可见里面的文件数量还是相当之多的，毕竟标准库与Unity库同样通过IL2CPP进行了编译。

和大多数C++的常见写法一样，类型的定义被放置在.h文件中，而函数和方法被放置在.cpp文件中。

### 字段

以下为范例工程生成的C++代码的一部分，包含了SampleBase类的字段定义。
``` cpp
struct  SampleBase_t2587948449  : public Il2CppObject
{
public:
	// System.Int32 Assets.Scripts.SampleBase::InstanceFieldSample
	int32_t ___InstanceFieldSample_1;

public:
	inline static int32_t get_offset_of_InstanceFieldSample_1() { return static_cast<int32_t>(offsetof(SampleBase_t2587948449, ___InstanceFieldSample_1)); }
	inline int32_t get_InstanceFieldSample_1() const { return ___InstanceFieldSample_1; }
	inline int32_t* get_address_of_InstanceFieldSample_1() { return &___InstanceFieldSample_1; }
	inline void set_InstanceFieldSample_1(int32_t value)
	{
		___InstanceFieldSample_1 = value;
	}
};

struct SampleBase_t2587948449_StaticFields
{
public:
	// System.String Assets.Scripts.SampleBase::ClassFieldSample
	String_t* ___ClassFieldSample_0;

public:
	inline static int32_t get_offset_of_ClassFieldSample_0() { return static_cast<int32_t>(offsetof(SampleBase_t2587948449_StaticFields, ___ClassFieldSample_0)); }
	inline String_t* get_ClassFieldSample_0() const { return ___ClassFieldSample_0; }
	inline String_t** get_address_of_ClassFieldSample_0() { return &___ClassFieldSample_0; }
	inline void set_ClassFieldSample_0(String_t* value)
	{
		___ClassFieldSample_0 = value;
		Il2CppCodeGenWriteBarrier(&___ClassFieldSample_0, value);
	}
};
```


有一下两点值得注意：

1. .h文件中不包含任何方法的定义。稍后我们会看到在对应的cpp文件中定义的方法内容；
2. 实例字段和静态字段被区分为两个不同的结构处理。对应于之前.Net部分介绍的内容，实例构造函数(.ctor)被用于初始化实例字段的内容，而类构造函数(.cctor)被用于构造静态字段。

### 方法

.cpp文件中的方法的一个例子如下：

```cpp

// System.String Assets.Scripts.SampleSubclass::NonvirtualMethod()
extern Il2CppCodeGenString* _stringLiteral3550574421;
extern const uint32_t SampleSubclass_NonvirtualMethod_m1104769664_MetadataUsageId;
extern "C"  String_t* SampleSubclass_NonvirtualMethod_m1104769664 (SampleSubclass_t3102098066 * __this, const MethodInfo* method)
{
	static bool s_Il2CppMethodIntialized;
	if (!s_Il2CppMethodIntialized)
	{
		il2cpp_codegen_initialize_method (SampleSubclass_NonvirtualMethod_m1104769664_MetadataUsageId);
		s_Il2CppMethodIntialized = true;
	}
	{
		return _stringLiteral3550574421;
	}
}

```


这匪夷所思的代码开头，il2cpp好心地留下了一行注释来标注生成的代码对应的托管方法的名字。简单地总结一下il2cpp生成方法的特征，大致如下：
1. 没有实例方法。这或许是为了生成器结构简单采取的权衡；
2. 方法作为C方法导出；
3. 方法的头两个参数为this指针和MethodInfo指针。对于静态方法，this指针同样存在，只不过该值始终会被传入NULL；MethodInfo指向方法的元数据，当调用虚方法时，这个参数会被用到。

### C# vs IL vs C++

下面再来稍微看下各个不同阶段中代码的对应关系。首先是一个C#方法：
```csharp
    public void SimpleControlFlow()
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index != 10; ++index)
        stringBuilder.Append(index.ToString());
    }
```

对应的IL代码如下
```cil

  .method public hidebysig instance void
    SimpleControlFlow() cil managed
  {
    .maxstack 7
    .locals init (
      [0] class [mscorlib]System.Text.StringBuilder stringBuilder,
      [1] int32 index
    )

    // [50 7 - 50 56]
    IL_0000: newobj       instance void [mscorlib]System.Text.StringBuilder::.ctor()
    IL_0005: stloc.0      // stringBuilder

    // [51 12 - 51 25]
    IL_0006: ldc.i4.0
    IL_0007: stloc.1      // index

    IL_0008: br           IL_001f

    // [52 9 - 52 47]
    IL_000d: ldloc.0      // stringBuilder
    IL_000e: ldloca.s     index
    IL_0010: call         instance string [mscorlib]System.Int32::ToString()
    IL_0015: callvirt     instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_001a: pop

    // [51 40 - 51 47]
    IL_001b: ldloc.1      // index
    IL_001c: ldc.i4.1
    IL_001d: add
    IL_001e: stloc.1      // index

    // [51 27 - 51 38]
    IL_001f: ldloc.1      // index
    IL_0020: ldc.i4.s     10 // 0x0a
    IL_0022: bne.un       IL_000d
    IL_0027: ret

  } // end of method SampleSubclass::SimpleControlFlow

```
CLI的虚拟机是基于栈而非寄存器的，看惯了x86汇编的大家会不会有点新奇呢。方法头一直到.maxstack块结束的部分就是方法头带来的信息。为了分配方便，所有局部变量都要在栈声明处初始化，这一点也是颇有pascal之风。最后找出这个方法的C++版本：

```cpp
// System.Void Assets.Scripts.SampleSubclass::SimpleControlFlow()
extern Il2CppClass* StringBuilder_t1221177846_il2cpp_TypeInfo_var;
extern const uint32_t SampleSubclass_SimpleControlFlow_m3549376175_MetadataUsageId;
extern "C"  void SampleSubclass_SimpleControlFlow_m3549376175 (SampleSubclass_t3102098066 * __this, const MethodInfo* method)
{
	static bool s_Il2CppMethodIntialized;
	if (!s_Il2CppMethodIntialized)
	{
		il2cpp_codegen_initialize_method (SampleSubclass_SimpleControlFlow_m3549376175_MetadataUsageId);
		s_Il2CppMethodIntialized = true;
	}
	StringBuilder_t1221177846 * V_0 = NULL;
	int32_t V_1 = 0;
	{
		StringBuilder_t1221177846 * L_0 = (StringBuilder_t1221177846 *)il2cpp_codegen_object_new(StringBuilder_t1221177846_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m3946851802(L_0, /*hidden argument*/NULL);
		V_0 = L_0;
		V_1 = 0;
		goto IL_001f;
	}

IL_000d:
	{
		StringBuilder_t1221177846 * L_1 = V_0;
		String_t* L_2 = Int32_ToString_m2960866144((&V_1), /*hidden argument*/NULL);
		StringBuilder_Append_m3636508479(L_1, L_2, /*hidden argument*/NULL);
		int32_t L_3 = V_1;
		V_1 = ((int32_t)((int32_t)L_3+(int32_t)1));
	}

IL_001f:
	{
		int32_t L_4 = V_1;
		if ((!(((uint32_t)L_4) == ((uint32_t)((int32_t)10)))))
		{
			goto IL_000d;
		}
	}
	{
		return;
	}
}
```

il2cpp把生成的C++代码分解成了几个块。对比IL我们知道，每个控制流的分支都被追加了单独的标签用于跳转之用，而稍微看下代码的含义的话，每个块中的C++代码和相应行号的IL代码做的事甚至是完全一样的。

IL2CPP的做法是针对每条IL指令将其参数带入模版以生成C++代码。嗯，证据确凿。

### 异常
这样一段IL代码
```il
    .try
    {

      IL_0042: br           IL_0069

    // [30 11 - 30 46]
      IL_0047: ldloca.s     V_4
      IL_0049: call         instance !0/*string*/ valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<string>::get_Current()
      IL_004e: stloc.3      // current

    // [31 11 - 31 41]
      IL_004f: ldloca.s     num
      IL_0051: call         instance string [mscorlib]System.Int32::ToString()
      IL_0056: ldloc.3      // current
      IL_0057: call         bool [mscorlib]System.String::op_Equality(string, string)
      IL_005c: brfalse      IL_0069

    // [32 13 - 32 28]
      IL_0061: ldloc.3      // current
      IL_0062: stloc.s      V_5

      IL_0064: leave        IL_008d

    // [28 9 - 28 38]
      IL_0069: ldloca.s     V_4
      IL_006b: call         instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<string>::MoveNext()
      IL_0070: brtrue       IL_0047
      IL_0075: leave        IL_0087
    } // end of .try
    finally
    {
      IL_007a: ldloc.s      V_4
      IL_007c: box          valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<string>
      IL_0081: callvirt     instance void [mscorlib]System.IDisposable::Dispose()
      IL_0086: endfinally
    } // end of finally
```

转换成C++之后是这样的：
```cpp
IL_0042:
	try
	{ // begin try (depth: 1)
		{
			goto IL_0069;
		}

IL_0047:
		{
			String_t* L_9 = Enumerator_get_Current_m870713862((&V_4), /*hidden argument*/Enumerator_get_Current_m870713862_MethodInfo_var);
			V_3 = L_9;
			String_t* L_10 = Int32_ToString_m2960866144((&V_2), /*hidden argument*/NULL);
			String_t* L_11 = V_3;
			IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
			bool L_12 = String_op_Equality_m1790663636(NULL /*static, unused*/, L_10, L_11, /*hidden argument*/NULL);
			if (!L_12)
			{
				goto IL_0069;
			}
		}

IL_0061:
		{
			String_t* L_13 = V_3;
			V_5 = L_13;
			IL2CPP_LEAVE(0x8D, FINALLY_007a);
		}

IL_0069:
		{
			bool L_14 = Enumerator_MoveNext_m4175023932((&V_4), /*hidden argument*/Enumerator_MoveNext_m4175023932_MethodInfo_var);
			if (L_14)
			{
				goto IL_0047;
			}
		}

IL_0075:
		{
			IL2CPP_LEAVE(0x87, FINALLY_007a);
		}
	} // end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		__last_unhandled_exception = (Exception_t1927440687 *)e.ex;
		goto FINALLY_007a;
	}
```

鉴于与主旨关系不大，我们忽略FINALLY_007a代码块。重要的事情是：il的.try块和C++的try实现大不一样。对于il的.try块来说，只有当异常发生时，代码被跳转到SEH块按照异常对象的类型检索处理代码时才会带来性能减损；对于C++来说，诚然诸多先进编译器都是用类似的方法来减小异常的花销，然而你不能保证你的代码最终会通过这些现代编译器被编译。

别忘了Unity自己就是积年累月不更新编译器的现行犯。

### 接口和虚方法
IL2CPP生成的接口方法调用类似于下面：

    InterfaceFuncInvoker0< Il2CppObject* >::Invoke(0, IEnumerable_1_t2364004493_il2cpp_TypeInfo_var, L_0);

虚方法和接口调用方式差不多，都是通过类似方法进行。方法的定义可以从下列文件中找到：

```
GeneratedGenericInterfaceInvokers.cpp
GeneratedGenericVirtualInvokers.cpp
GeneratedInterfaceInvokers.cpp
GeneratedVirtualInvokers.cpp
```
其内容类似这样：

```cpp
template <typename R>
struct VirtFuncInvoker0
{
	typedef R (*Func)(void*, const MethodInfo*);

	static inline R Invoke (Il2CppMethodSlot slot, void* obj)
	{
		VirtualInvokeData invokeData;
		il2cpp::vm::Runtime::GetVirtualInvokeData (slot, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
```
其中GetVirtualInvokeData被用于从方法表搜寻正确方法。
