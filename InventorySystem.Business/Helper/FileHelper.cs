using Microsoft.AspNetCore.Http;

namespace InventorySystem.Business.Helper
{
    public static class FileHelper
    {
        private static readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();

        public static string UploadFile(string folderName, IFormFile? file)
        {
            if (file is null) return null;
            try
            {
                //catch the folder Path and the file name in server
                // 1 ) Get Directory
                string folderPath = Directory.GetCurrentDirectory() + "/wwwroot/images/" + folderName; // Local E://Mohamed/folder/test.png


                //2) Get File Name
                string fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);

                var imageUrl = $"/images/products/{fileName}";
                var fullUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{imageUrl}";
                //Guid => Word contain from 36 character

                // 3) Merge Path with File Name
                string finalPath = Path.Combine(folderPath, fileName);
                //combine put /

                //4) Save File As Streams "Data Overtime"
                using (var Stream = new FileStream(finalPath, FileMode.Create))
                {
                    file.CopyTo(Stream);
                }

                return fullUrl;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string DeleteFile(string folderName, string? fileName)
        {
            if (fileName is not null) return "No file match file name";
            try
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", folderName, fileName);

                if (File.Exists(directory))
                {
                    File.Delete(directory);
                    return "File Deleted";
                }

                return "File Not Deleted";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
