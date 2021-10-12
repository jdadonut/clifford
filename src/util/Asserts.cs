using System;
using System.Reflection;
using System.IO;
using System.Diagnostics;
namespace Clifford.Util
{
    public static class Asserts
    {
        public static void FileExists(string path)
        {
            MethodBase caller_method = new StackFrame(1).GetMethod();
            string caller = caller_method.Name;
            if (!File.Exists(path))
            {

                throw new AssertionError("File not found: " + path);
            }
            else
            {
                Console.WriteLine("Assertion passed: \nType: FileExists\nCaller: " + caller + "\nTime: " + DateTime.Now.ToString());
            }
        }
    }
    public class AssertionError : Exception
    {
        public AssertionError(string message) : base(message)
        {
        }
    }
}
