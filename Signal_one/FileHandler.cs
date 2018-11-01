using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Signal_one
{
    public static class FileHandler
    {
        public static void ReadFile(string _path, ref List<double> _value)
        {
            _value = File.ReadAllText(_path)
                .Split()
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Select(n => double.Parse(n))
                .ToList();
        }
        public static void OutputListInFile(ref List<double> _value, ref string _path)
        {
            File.WriteAllLines(_path, _value.Select(n => n.ToString()));
        }

    }
}
