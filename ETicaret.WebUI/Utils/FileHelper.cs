namespace ETicaret.WebUI.Utils
{
    public class FileHelper//Logo ve reismleri yüklemek için metot
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile,string filePath="/Img/")
        {
             string filename = "";
            if (formFile != null && formFile.Length>0) { 
                filename = formFile.FileName.ToLower();
                string directory=Directory.GetCurrentDirectory() + "/wwwroot" +filePath + filename;
                using var stream=new FileStream (directory,FileMode.Create);
                await formFile.CopyToAsync (stream);
            }
            return filename;
                
        }
        public static bool FileRemover(string fileName, string filePath = "/Img/")
        {
            string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
            if (File.Exists(directory)) { 
             File.Delete(directory);
                return true;
            }
            return false;
        }
    }
}
