using System;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class CoderAttribute : Attribute
{
    public string Coder { get; set; }
    public DateTime LastModified { get; set; }
    public CoderAttribute(string coder, string lastModified)
    {
        Coder = coder;
        LastModified = DateTime.Parse(lastModified);
    }

    [Coder("Mark Price", "22 August 2019")]
    [Coder("Johnni Rasmussen", "13 September 2019")]
    public static void DoStuff()
    {

    }
}

