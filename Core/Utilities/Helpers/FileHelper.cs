using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourceFile = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourceFile, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var result = NewPath(file);
            File.Move(sourceFile, result);
            return result;
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo info = new FileInfo(file.FileName);
            string fileExtension = info.Extension;

            string filePath = Environment.CurrentDirectory + @"\wwwroot\images";
            var newPath = Guid.NewGuid().ToString() + fileExtension;
            string result = $@"{filePath}\{newPath}";
            return result;
        }

        public static string Update(string sourceFile, IFormFile file)
        {
            var result = NewPath(file);
            try
            {
                if (sourceFile.Length > 0)
                {
                    using (var stream = new FileStream(result, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                //File.Delete(sourceFile);
            }
            catch (Exception e)
            {
                return e.Message;
            }

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
    }
}
