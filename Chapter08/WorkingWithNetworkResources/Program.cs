﻿using System.Net;
using static System.Console;
using System.Net.NetworkInformation;
Write("Enter a valid web address: ");
string url = ReadLine();
if (string.IsNullOrWhiteSpace(url))
{
    url = "https://world.episerver.com/cms/?q=pagetype";
}
var uri = new Uri(url);
WriteLine($"URL: {uri}");
WriteLine($"Scheme: {uri.Scheme}");
WriteLine($"Port: {uri.Port}");
WriteLine($"Host: {uri.Host}");
WriteLine($"Path: {uri.AbsolutePath}");
WriteLine($"Query: {uri.Query}");
IPHostEntry entry = Dns.GetHostEntry(uri.Host);
WriteLine($"{entry.HostName} has the following IP addresses: ");
foreach(IPAddress address in entry.AddressList)
{
    WriteLine($"  {address}");
}
try
{
    var ping = new Ping();
    WriteLine("Pinging server. Please wait...");
    PingReply reply = ping.Send(uri.Host);
    WriteLine($"{uri.Host} was pinged and replied: {reply.Status}");
    if (reply.Status == IPStatus.Success)
    {
        WriteLine($"Reply from {reply.Address} took {reply.RoundtripTime:N0} ms.");
    }
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
}