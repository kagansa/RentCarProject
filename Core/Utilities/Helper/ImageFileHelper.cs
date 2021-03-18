using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helper
{
    public class ImageFileHelper : FileHelper
    {
        private static string _carImagePath = Environment.CurrentDirectory + @"\Uploads\CarImages";
        public static string CarNewImageName = "";
        public static string[] AcceptImageExtension = { ".jpg", ".jpeg", ".png", ".gif" };

        public static string CarAdd(IFormFile file)
        {
            string savePath = CarImageNewName(file);
            if (savePath == null) return null;
            Add(file, savePath);
            return CarNewImageName;
        }

        public static string CarUpdate(string sourcePath, IFormFile file)
        {
            string savePath = CarImageNewName(file);
            if (savePath == null) return null;
            sourcePath = $@"{_carImagePath}\{sourcePath}";
            Update(sourcePath, savePath, file);
            return CarNewImageName;
        }

        public static IResult CarDelete(string sourcePath)
        {
            var result = Delete(sourcePath);
            return result;
        }

        public static string CarImageNewName(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            //Extension Control
            foreach (var item in AcceptImageExtension)
            {
                if (item == ff.Extension)
                {
                    CarNewImageName = Guid.NewGuid().ToString("N") + fileExtension;
                    string result = $@"{_carImagePath}\{CarNewImageName}";
                    return result;
                }
            }
            return null;
        }
    }
}