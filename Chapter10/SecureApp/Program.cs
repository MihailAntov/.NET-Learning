using static System.Console;
using CryptographyLib;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;
using System.Threading;
Protector.Register("Vilitu", "mishko", new[] {"Admins"});
Protector.Register("Bob", "Pa$$w0rd", new[] {"Sales", "TeamLeads"});
Protector.Register("Eve", "Pa$$w0rd");
Write("Enter your username:");
string username = ReadLine();
Write("Enter your password:");
string password = ReadLine();
Clear();
Protector.LogIn(username, password);
if(Thread.CurrentPrincipal == null)
{
    WriteLine("Log in failed.");
    return;
}

var p = Thread.CurrentPrincipal;
WriteLine($"IsAuthenticated: {p.Identity.IsAuthenticated}");
WriteLine($"AuthenticationType: {p.Identity.AuthenticationType}");
WriteLine($"Name: {p.Identity.Name}");
WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");

if (p is ClaimsPrincipal)
{
    WriteLine($"{p.Identity.Name} has the following claims:");
    foreach (Claim claim in (p as ClaimsPrincipal).Claims)
    {
        WriteLine($"{claim.Type} : {claim.Value}");
    }
}

static void SecureFeature()
{
    if (Thread.CurrentPrincipal == null)
    {
        throw new SecurityException("A user must be logged in to access this feature.");        
    }

    if(!Thread.CurrentPrincipal.IsInRole("Admins"))
    {
        throw new SecurityException("User must be a member of Admins to access this feature.");  
    }
    WriteLine("You have access to this secure feature.");
}
try
{
    SecureFeature();
}
catch (System.Exception ex)
{
    WriteLine($"{ex.GetType}: {ex.Message}");
}