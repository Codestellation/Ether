using System;
using System.IO;
using System.Reflection;

namespace Codestellation.Ether.Misc
{
    public static class Utils
    {
        public static string MakeRootedPath(string folderPath)
        {
            if (Path.IsPathRooted(folderPath))
            {
                return folderPath;
            }

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string executingAssemblyUrl = executingAssembly.GetName().CodeBase;
            string uriAssemblyFolder = Path.GetDirectoryName(executingAssemblyUrl);

            string executingAssemblyPath = new Uri(uriAssemblyFolder).LocalPath;
            folderPath = Path.Combine(executingAssemblyPath, folderPath);
            return folderPath;
        }

        public static void Dispose(object obj)
        {
            var disposable = obj as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}