using System;
using System.Collections.ObjectModel;
using System.IO;

using PictureGetter.Model;

namespace PictureGetter.Helper
{
    public static class Utility
    {        
        public static ObservableCollection<MediaFile> GetFileListFromDirectory(DirectoryInfo directoryInfo, ObservableCollection<MediaFile> sourceMediaFiles)
        {
            FileInfo[] fileInfo = directoryInfo.GetFiles();

            foreach (var file in fileInfo)
            {
                if (sourceMediaFiles == null)
                {
                    sourceMediaFiles = new ObservableCollection<MediaFile>();
                }

                MediaFile record = new MediaFile(file.DirectoryName, file.Name, file.Extension, file.CreationTime);
                if (record.IsValidType()) sourceMediaFiles.Add(record);
            }

            DirectoryInfo[] subs = directoryInfo.GetDirectories();
            foreach (var directory in subs)
            {
                GetFileListFromDirectory(directory, sourceMediaFiles);
            }

            return sourceMediaFiles;
        }
    }
}
