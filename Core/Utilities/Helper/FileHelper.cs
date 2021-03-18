using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        public static string Add(IFormFile file, string savePath)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }

            File.Move(sourcepath, savePath);
            return savePath;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string Update(string sourcePath, string savePath, IFormFile file)
        {
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);
            return savePath;
        }
    }
}