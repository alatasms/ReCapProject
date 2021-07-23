using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public static IResult Add(IFormFile file)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccesResult((_folderName + randomName + type).Replace("\\", "/"));



        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }

            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccesResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccesResult();
        }

        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccesResult();
            }
            return new ErrorResult("File doesn't exists.");
        }


        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Wrong file type.");
            }
            return new SuccesResult();
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }

        }
    }
}