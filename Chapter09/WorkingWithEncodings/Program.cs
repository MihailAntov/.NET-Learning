using static System.Console;
using System.Text;
WriteLine("Encodings");
WriteLine("[1] ASCII");
//WriteLine("[2] UTF-7"); obsolete!
WriteLine("[3] UTF-8");
WriteLine("[4] UTF-16 (Unicode)");
WriteLine("[5] UTF-32");
WriteLine("[any other key] Default");

//choose an encoding
Write("Press a number to choose an encoding: ");
ConsoleKey number = ReadKey(intercept: false).Key;
WriteLine();
WriteLine();

Encoding encoder = number switch
{
    ConsoleKey.D1 => Encoding.ASCII,
    //ConsoleKey.D2 => Encoding.UTF7, obsolete!
    ConsoleKey.D3 => Encoding.UTF8,
    ConsoleKey.D4 => Encoding.Unicode,
    ConsoleKey.D5 => Encoding.UTF32,
    _             => Encoding.Default
};

//define a string to encode
string message = "A pint of milk is \u00A31.99";

//encode the string into a byte array
byte[] encoded = encoder.GetBytes(message);

//check how many bytes the encoding needed
WriteLine($"{encoder.GetType()} uses {encoded.Length:N0} bytes.");

//enumerate each byte
WriteLine($"BYTE  HEX  CHAR");
foreach (byte b in encoded)
{
    WriteLine($"{b,4} {b.ToString("X"),4} {(char)b,5}");
}

//decode the byte array back into a string and display it
string decoded = encoder.GetString(encoded);
WriteLine(decoded);