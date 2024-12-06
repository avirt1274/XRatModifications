using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    private static string command = "start";
  
    static void Main()
    {
      Console.WriteLine("test1");
      Process.Start($"cmd.exe /min /c {command}");
    }
}
