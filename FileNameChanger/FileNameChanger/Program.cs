using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileNameChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            //handel user input
            string fromDirectory = "C:\\Users\\AAhmed\\Desktop\\Filecopy";//Console.ReadLine();
            string toDirectory = "C:\\Users\\AAhmed\\Desktop\\Filecopy\\copiedFiles";

            Console.WriteLine("Enter The Directory Name");
            string x = Console.ReadLine();


            //get all files in the directory
            string[] filePaths = Directory.GetFiles(fromDirectory);

            foreach (string file in filePaths)
            {

                //Get File Name
                string fileName = Path.GetFileName(file);


                //handel all the file editing here.
                string EditedfileName = renameFile(fileName);



                #region Set up the file location
                // Use Path class to manipulate file and directory paths. 
                string sourceFile = Path.Combine(fromDirectory, fileName);
                string destFile = Path.Combine(toDirectory, EditedfileName);

                //Directory does not exist
                if (!(Directory.Exists(destFile)))
                {
                    Directory.CreateDirectory(toDirectory);
                }
                #endregion

                #region copying the file
                File.Copy(sourceFile, destFile, true);
                #endregion
            }
        }

        public static string renameFile(string fileName)
        {
            fileName = fileName.Remove(0, 8);
            return fileName;
        }
    }
}
