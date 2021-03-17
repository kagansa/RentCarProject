using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        private const string carImagePath = @"\Uploads\CarImages";
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }

            var result = NewPath(file);
            File.Move(sourcepath, result);
            return result;
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

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);
            return result;
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\Uploads\CarImages";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }


        public static string AddCarImage(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }

            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + carImagePath;
            var fileName = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{fileName}";

            File.Move(sourcepath, result);


            result = fileName;
            return result;
        }

        public static IResult DeleteCarImage(string path)
        {
            try
            {
                path = Environment.CurrentDirectory + carImagePath + @"\" + path;
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string UpdateCarImage(string sourcePath, IFormFile file)
        {
            string oldimg = sourcePath;
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }

            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + carImagePath;
            var fileName = Guid.NewGuid() + fileExtension;

            string result = $@"{path}\{fileName}";

            File.Move(sourcepath, result);
            
            string deleteimg = $@"{path}\{oldimg}";
            File.Delete(deleteimg);

            result = fileName;
            return result;
        }

    }
}