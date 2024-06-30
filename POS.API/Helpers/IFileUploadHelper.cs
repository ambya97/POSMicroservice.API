namespace POS.API.Helpers
{
    public interface IFileUploadHelper
    {
        string GetUniqueFileName(string fileName);

        string GetUsersFolderPath(bool isAbsolutePath);
    }
}
