using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        private static string[] MakeTestDirectories()
        {
            string localApplicationData = Path.Combine(
                Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
                @"Programming CSharp\FindDuplicates");

            //Get the name of the logged in user
            string userName = WindowsIdentity.GetCurrent().Name;
            //Make the access control rule
            FileSystemAccessRule fsarAllow =
                new FileSystemAccessRule(
                userName,
                FileSystemRights.FullControl,
                AccessControlType.Allow);
            DirectorySecurity ds = new DirectorySecurity();
            ds.AddAccessRule(fsarAllow);

            FileSystemAccessRule fsarDeny =
                new FileSystemAccessRule(
                    userName,
                    FileSystemRights.WriteExtendedAttributes,
                    AccessControlType.Deny);
            ds.AddAccessRule(fsarDeny);

            //Let's make three test directories
            var directories = new string[3];
            for (int i = 0; i < directories.Length; i++)
            {
                string directory = Path.GetRandomFileName();
                //Combine the local application data with the new
                //random file/directory name
                string fullPath = Path.Combine(localApplicationData, directory);
                //And create the directory
                Directory.CreateDirectory(fullPath);
                directories[i] = fullPath;
                Console.WriteLine(fullPath);
            }
            Console.ReadKey();
            CreateTestFiles(directories);
            return directories;
        }

        private static void CreateFile(string fullPath, string p)
        {
            using (StreamWriter writer = File.CreateText(fullPath))
            {
                writer.Write(p);
            }
        }

        private static void CreateTestFiles(IEnumerable<string> directories)
        {
            string fileForAllDirectories = "SameNameAndContent.txt";
            string fileSameInAllButDifferentSize = "SameNameDifferentSize.txt";

            int directoryIndex = 0;
            //Let's create a distinct file that appears in each directory
            foreach (string directory in directories)
            {
                directoryIndex++;

                //Create the distinct file for this directory
                string filename = Path.GetRandomFileName();
                string fullPath = Path.Combine(directory, filename);
                CreateFile(fullPath, "Example content 1");

                //And now the file that is in all the directories
                fullPath = Path.Combine(directory, fileForAllDirectories);
                CreateFile(fullPath, "Found in all directories.");

                //And now the file with a common name but different size
                fullPath = Path.Combine(directory, fileSameInAllButDifferentSize);

                StringBuilder builder = new StringBuilder();
                builder.AppendLine("Now with");
                builder.AppendLine(new string('x', directoryIndex));
                CreateFile(fullPath, builder.ToString());
            }
        }

        private static void CleanUpTestDirectories(IEnumerable<string> directories)
        {
            foreach (var directory in directories)
            {
                Directory.Delete(directory, true);
            }
        }
        
        static void Main(string[] args)
        {
            
            var testFiles = MakeTestDirectories();
            CleanUpTestDirectories(testFiles);
        }
    }
}
