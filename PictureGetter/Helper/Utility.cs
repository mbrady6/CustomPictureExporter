using System;
using System.Collections.ObjectModel;
using System.IO;

using PictureGetter.Model;

namespace PictureGetter.Helper
{
    public static class Utility
    {
        /*
        public static ObservableCollection<MediaFile> GetFilesAllDirectories(string directory)
        {
            ObservableCollection<MediaFile> fileList = new ObservableCollection<MediaFile>();

            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            foreach (var file in GetFileListFromDirectory(directoryInfo, fileList))
            {
                fileList.Add(file);
            }

            return fileList;
        }
        */

        public static ObservableCollection<MediaFile> GetFileListFromDirectory(DirectoryInfo directoryInfo, ObservableCollection<MediaFile> fileList)
        {
            if (fileList == null) fileList = new ObservableCollection<MediaFile>();

            FileInfo[] fileInfo = directoryInfo.GetFiles();

            foreach (var file in fileInfo)
            {
                MediaFile record = new MediaFile(file.DirectoryName, file.Name, file.Extension, file.CreationTime);
                if(record.IsValidType()) fileList.Add(record);
            }

            foreach(var directory in directoryInfo.GetDirectories())
            {
                GetFileListFromDirectory(directory, fileList);
            }

            if(fileList == null)
            {

            }

            return fileList;
        }
    }
}
