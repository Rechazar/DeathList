using System;
using System.Collections.Generic;
using System.Text;

namespace DeathList.Persistence
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
