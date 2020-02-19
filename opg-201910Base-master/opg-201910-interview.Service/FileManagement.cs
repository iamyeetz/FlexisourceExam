using opg_201910_interview.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace opg_201910_interview.Service
{
    public class FileManagement : IFileManagement
    {
        public FileManagement()
        {
        }

        public List<string> getFiles(Files files)
        {


            if (files.ClientId <= 0)
                throw new ArgumentOutOfRangeException("ClientId declared in appsettings should not be less than or equal to zero");
            if (String.IsNullOrEmpty(files.FileFormat))
                throw new ArgumentOutOfRangeException("File Format declared in appsettings should not be null or Empty");
            if (String.IsNullOrEmpty(files.FilePath))
                throw new ArgumentOutOfRangeException("File Path declared in appsettings should not be null or Empty");
            if (String.IsNullOrEmpty(files.FileOrder))
                throw new ArgumentOutOfRangeException("File Order declared in appsettings should not be null or Empty");

            string[] fileOrderSplit = files.FileOrder.Split(',');

            List<string> savedFiles;
            try
            {
                savedFiles = new DirectoryInfo(Directory.GetCurrentDirectory() + "/" + files.FilePath).GetFiles().Select(x => x.Name).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Invalid file path declared in appsettings");
            }

            List<string> toReturn = new List<string>();

            foreach (var a in fileOrderSplit)
            {
                var fileList = (from x in savedFiles.Where(x => x.Contains(a)).AsEnumerable()
                                orderby
                                DateTime.Parse(DateTime.ParseExact(
                                                     x.Replace(a, "").Replace("_", "").Replace(files.FileFormat, "").Replace("-", "").Replace(".", "")
                                                     , "yyyyMMdd"
                                                     , CultureInfo.InvariantCulture)
                                                     .ToString("yyyy-MM-dd"))

                                ascending
                                select x).ToList();

                toReturn.AddRange(fileList);
            }
            return toReturn;
        }
    }
}
