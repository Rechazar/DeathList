using DeathList.Droid;
using Xamarin.Forms;
using DeathList.Persistence;
using System;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace DeathList.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}