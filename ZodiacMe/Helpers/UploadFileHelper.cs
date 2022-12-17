using ZodiacMe.BD.ViewModels;

namespace ZodiacMe.Helpers
{
    public class UploadFileHelper
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public UploadFileHelper(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> SubirImagen(IFormFile formFile)
        {
            try
            {
                //guarda la imagen
                string wwwRoot = _hostEnvironment.WebRootPath;
                string extension = Path.GetExtension(formFile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
                fileName = fileName + extension;
                string path = Path.Combine(wwwRoot + "/images/uploads", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
                return fileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
