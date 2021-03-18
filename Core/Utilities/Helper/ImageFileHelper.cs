using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helper
{
    public class ImageFileHelper : FileHelper
    {
        private static string carImagePath = Environment.CurrentDirectory + @"\Uploads\CarImages";
        public static string carNewImageName = "";

        public static string CarAdd(IFormFile file)
        {
            string savePath = CarImageNewName(file);
            Add(file, savePath);
            return carNewImageName;
        }

        public static string CarUpdate(string sourcePath, IFormFile file)
        {
            string savePath = CarImageNewName(file);
            sourcePath = carImagePath + @"\" + sourcePath;
            var result = Update(sourcePath, savePath, file);
            return carNewImageName;
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

            carNewImageName = Guid.NewGuid() + fileExtension;
            string result = $@"{carImagePath}\{carNewImageName}";
            return result;
        }
    }
}