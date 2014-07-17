using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Davang.Utilities.Helpers
{
    public class StorageHelper
    {
        public static async Task<Stream> OpenStreamForWriteAsync(string fileName, bool createBackup = true)
        {
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            if (createBackup && CheckLocalFileExist(fileName))
            {
                StorageFile localFile = null;
                localFile = await localFolder.GetFileAsync(fileName);

                if (localFile != null)
                    await localFile.RenameAsync(fileName + ".bak", NameCollisionOption.ReplaceExisting);
            }

            var newLocalFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            return await newLocalFile.OpenStreamForWriteAsync();
        }

        public static async Task<Stream> OpenStreamForReadAsync(string fileName, bool tryBackup = true)
        {
            var finalFile = fileName;

            if (!CheckLocalFileExist(fileName) && tryBackup)
            {
                if (CheckLocalFileExist(fileName + ".bak"))
                    finalFile = fileName + ".bak";
                else
                    return null;
            }

            var storageFile = await OpenFileForReadAsync(finalFile);
            return await storageFile.OpenStreamForReadAsync();
        }

        private static async Task<StorageFile> OpenFileForReadAsync(string fileName)
        {
            StorageFile storageFile = null;
            try
            {
                storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/" + fileName));
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }

            return storageFile;
        }

        public static bool CheckLocalFileExist(string filePath)
        {
            return IsolatedStorageFile.GetUserStoreForApplication().FileExists(filePath);
        }

        public static string[] GetLocalFilesStartWith(string pattern)
        {
            return IsolatedStorageFile.GetUserStoreForApplication().GetFileNames(pattern + "*");
        }

        public static Stream GetFileStream(string filePath)
        {
            if (IsolatedStorageFile.GetUserStoreForApplication().FileExists(filePath))
                return IsolatedStorageFile.GetUserStoreForApplication().OpenFile(filePath, FileMode.Truncate, FileAccess.ReadWrite);
            else
                return IsolatedStorageFile.GetUserStoreForApplication().OpenFile(filePath, FileMode.CreateNew, FileAccess.ReadWrite);
        }

        /// <summary>
        /// For now just igonre .bak file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="alsoBackup"></param>
        /// <returns></returns>
        public static async Task DeleteAsync(string fileName, bool alsoBackup = true)
        {
            StorageFile storageFile = null;
            try
            {
                storageFile = await Windows.Storage.StorageFile
                    .GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/" + fileName));

                await storageFile.DeleteAsync();
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }

        public static bool DeleteFile(string fileName)
        {
            if (IsolatedStorageFile.GetUserStoreForApplication().FileExists(fileName))
            {
                IsolatedStorageFile.GetUserStoreForApplication().DeleteFile(fileName);
                return true;
            }

            return false;
        }

        public static bool CopyFile(string sourceFile, string destFile)
        {
            try
            {

                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isoStore.FileExists(destFile))
                        isoStore.DeleteFile(destFile);

                    isoStore.CopyFile(sourceFile, destFile, true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteDownloadedStream(string fileName)
        {
            try
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isoStore.FileExists(fileName))
                        isoStore.DeleteFile(fileName);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool MoveFile(string sourceFile, string destinationFile)
        {
            try
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isoStore.FileExists(destinationFile))
                        isoStore.DeleteFile(destinationFile);

                    isoStore.MoveFile(sourceFile, destinationFile);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveConfig(string key, object value)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
                IsolatedStorageSettings.ApplicationSettings.Remove(key);
            IsolatedStorageSettings.ApplicationSettings.Add(key, value);
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        public static object LoadConfig(string key)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
                return IsolatedStorageSettings.ApplicationSettings[key];

            return null;
        }

        public static bool EnoughSpace(int mbToStore = 1)
        {
            return IsolatedStorageFile.GetUserStoreForApplication().AvailableFreeSpace / (1024 * 1024) > mbToStore;
        }
    }
}
