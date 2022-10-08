// See https://aka.ms/new-console-template for more information
using static System.Console;
int a = 10; // 0000 1010
int b = 6;  // 0000 0110 
WriteLine($"a = {a}.");
WriteLine($"b = {b}.");
WriteLine($"a & b = {a & b}"); // 2-bit column only
WriteLine($"a | b = {a | b}"); // 8, 4, and 2-bit columns
WriteLine($"a ^ b = {a ^ b}"); // 8 and 4-bit columns

// 0101 0000 left-shift a by three bit columns
WriteLine($"a << 3 = {a << 3}");
// multiply a by 8
WriteLine($"a * 8 = {a * 8}");
// 0000 0011 right-shift b by one 
WriteLine($"b >> 1 = {b >> 1}");

int age = 4724634;
for(int i = 0; i<Convert.ToString(age).Length; i++)
{
  if(i == 0)
    {
        WriteLine($"The first digit is {age.ToString()[i]}");
    }
    else if(i == (Convert.ToString(age).Length - 1))
    {
        WriteLine($"The last digit is {age.ToString()[i]}");
    }
    else
    {
        WriteLine($"The next digit is {age.ToString()[i]}");
    }
}