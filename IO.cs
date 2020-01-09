﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace MCC_Mod_Manager
{
    static class IO
    {
        public static bool DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }
        public static int CopyFile(string src, string dest, bool overwrite)
        {
            if (File.Exists(dest))
            {
                if (overwrite)
                {
                    if (!DeleteFile(dest))
                    {
                        return 2;   // fail - file in use
                    }
                }
                else
                {
                    return 1;   // success - not overwriting the existing file
                }
            }
            try
            {
                File.Copy(src, dest);
            }
            catch (IOException)
            {
                return 3;   // fail - file access error
            }
            return 0;   // success
        }
    }
}
