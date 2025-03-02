using System.Reflection;

namespace Lambda.Modules.Lessons.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
