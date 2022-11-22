## Homa Games Code Reflection

Unity code analyzer tool. Based on https://github.com/jbevain/mono.reflection.


## API

***

```csharp
public static class CodeAnalyzer {
	public static List<MethodBase> FindUsageOfMethod(MethodInfo method, Assembly assembly) {}
	public static List<MethodBase> FindMethodUsageInsideMethodBody(MethodInfo method, MethodBase bodyMethod) {}
}
```

> Use these to find usage of a method inside any Assembly or other Method.

***

```csharp
public sealed class Image {
	public static bool IsAssembly (string fileName) {}
	public static bool IsAssembly (Stream stream) {}
}
```

> Test whether a file is a managed assembly or not.

***

```csharp
public static class BackingFieldResolver {
	public static FieldInfo GetBackingField (this PropertyInfo self) {}
}
```

> Returns the field backing a property or throws an InvalidOperationException.

***

```csharp
public static class Disassembler {
	public static IList<Instruction> GetInstructions (this MethodBase self) {}
}
```

> Returns a read only collection of Instruction representing the
> IL method body or throws an ArgumentException if the method doesn't provide a body.

***

```csharp
public class Instruction {
	public int Offset { get; }
	public OpCode OpCode { get; }
	public object Operand { get; }

	public Instruction Next { get; }
	public Instruction Previous { get; }
}
```

> Represents an IL instruction.
