using static System.Console;
using System.Linq;
using System;

static void LinqWithArrayOfStrings()
{
    var names = new string[] {"Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed"};
    
    //progressively simpler and better ways of filtering names

    //1
    //var query = names.Where(new Func<string, bool>(NameLongerThanFour));
    
    //2
    //var query2 = names.Where(NameLongerThanFour);
    
    //3
    var query3 = names
        .Where(name => name.Length > 4)
        .OrderBy(name => name.Length)
        .ThenBy(name => name);
    
    
    foreach (string item in query3)
    {
        WriteLine(item);
    }
}

static void LinqWithArrayOfExceptions()
{
    var errors = new Exception[]
    {
        new ArgumentException(),
        new SystemException(),
        new IndexOutOfRangeException(),
        new InvalidOperationException(),
        new NullReferenceException(),
        new InvalidCastException(),
        new OverflowException(),
        new DivideByZeroException(),
        new ApplicationException()
    };

    var numberErrors = errors.OfType<ArithmeticException>();
    foreach (var error in numberErrors)
    {
        WriteLine(error);
    }
}


//static bool NameLongerThanFour(string name)
//{
//    return name.Length > 4;
//}
LinqWithArrayOfStrings();
LinqWithArrayOfExceptions();