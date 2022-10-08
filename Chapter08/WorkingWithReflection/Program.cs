using static System.Console;
using System.Runtime.CompilerServices;
using System;
using System.Reflection;
using System.Linq;

WriteLine("Assembly metadata:");
var assembly = Assembly.GetEntryAssembly();
WriteLine($"   Full name: {assembly.FullName}");
WriteLine($"   Location: {assembly.Location}");
var attributes = assembly.GetCustomAttributes();
WriteLine($"    Attributes:");
foreach(Attribute a in attributes)
{
    WriteLine($"         {a.GetType()}");
}
var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
WriteLine($" Version: {version.InformationalVersion}");
var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
WriteLine($" Company: {company.Company}");
bool IsCompilerGenerated(Type t)
{
    var attr = Attribute.GetCustomAttribute(t, typeof(CompilerGeneratedAttribute));
    return attr != null;
}

WriteLine();
WriteLine($"* Types:");
Type[] types = assembly.GetTypes();
foreach(Type type in types)
{
    if(IsCompilerGenerated(type))
    {
        continue;
    }
    WriteLine($"Type: {type.FullName}");
    MemberInfo[] members = type.GetMembers();
    foreach (MemberInfo member in members)
    {
        WriteLine($"{member.MemberType} : {member.Name} ({member.DeclaringType.Name})");
        var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);
        foreach (CoderAttribute coder in coders)
        {
            WriteLine($"Modified by {coder.Coder} on {coder.LastModified.ToShortDateString()}.");
        }
    }
    WriteLine();
}
// 285 ?!?!? before doing more with reflection