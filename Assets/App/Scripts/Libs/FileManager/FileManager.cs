using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace App.Scripts.Libs.FileManager
{
    public static class FileManager
    {
        private static readonly Dictionary<string, Object> _fileAndDataPairs = new();

        public static T GetFile<T>(string path) where T : Object
        {
            var isFileCached = _fileAndDataPairs.TryGetValue(path, out var data);

            if (!isFileCached)
            {
                data = CacheFile(path);
            }
            return data as T;
        }

        private static Object CacheFile(string path)
        {
            Object? data = Resources.Load(path);
            if (data is null)
            {
                return null;
            }
            _fileAndDataPairs[path] = data;
            return data;
        }

        public static void ClearCache()
        {
            _fileAndDataPairs.Clear();
        }
    }
}