using POS.Data.Common;

namespace POS.API.Helpers
{
    public class FileUploadHelper : IFileUploadHelper
    {
        #region Global Variables
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Ctor
        public FileUploadHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion
        public string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);

            return $"{Path.GetFileNameWithoutExtension(fileName)}" +
                    $"{DateTime.UtcNow:ddMMyyhhmmss}" +
                    $"{Path.GetExtension(fileName)}";
        }

        public string GetUsersFolderPath(bool isAbsolutePath)
        {
            if (isAbsolutePath)
            {
                return string.Format("{0}\\{1}\\{2}",
                    _webHostEnvironment.ContentRootPath,
                    StaticValues.UploadFolder,
                    StaticValues.UsersFolder);
            }
            else
            {
                return string.Format("{0}/{1}",
                    _webHostEnvironment.WebRootPath,
                    StaticValues.UsersFolder);
            }
        }
    }
}
