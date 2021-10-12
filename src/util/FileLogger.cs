using System.IO;
using System;
using System.Reflection;


namespace Clifford.Util
{
    public class FileLogger
    {
        public string fileName;
        public StreamWriter writer;
        public FileLogger(string? fileName = null)
        {
            fileName = fileName ?? Assembly.GetExecutingAssembly().GetName() + DateTime.Now.ToString("_yyyyMMDD_HHmmss") + ".log";
            this.fileName = fileName;
            writer = new StreamWriter(fileName);
        }
        public void Log(string message)
        {
            writer.WriteLine(message);
        }
        public void Warn(string message)
        {
            writer.WriteLine("WARN: " + message);
        }
        public void Error(string message)
        {
            writer.WriteLine("ERROR: " + message);
        }
        public void Dump(byte[] mem)
        {
            string currTime = DateTime.Now.ToString("_yyyyMMDD_HHmmss");
            writer.WriteLine("DUMP: " + mem.Length + " bytes into file " + Assembly.GetExecutingAssembly().GetName() + currTime + ".dmp");
            writer.Write(BitConverter.ToString(mem));
            using (var fs = new FileStream(Assembly.GetExecutingAssembly().GetName() + ".dmp", FileMode.Append))
            {
                fs.WriteAsync(mem, 0, mem.Length);
            }
        }

        public void Close()
        {
            writer.Close();
        }
    }
}