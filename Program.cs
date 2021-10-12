using System;
using Clifford.Util;
namespace Clifford
{
    class Program
    {
        static FileLogger logger = new FileLogger();
        static void Main(string[] args)
        {
            
            
        }
        static void Panic(string message, byte[]? dump, Int16? code)
        {
            logger.Error(message);
            logger.Dump(dump ?? new byte[0]);
            Environment.Exit(code ?? -1);
        }
    }
}
