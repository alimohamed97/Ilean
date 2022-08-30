using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Core.Common.File
{
    public interface IFileHelper
    {
        FileStream GetFileStream(string filePath, string directory);
        void SaveFile(string base64FileContent, string directory, string fileName);
        Task<string> SaveFileAsync(IFormFile formFile, string directory, string subDirectory = null);

        Task<MemoryStream> GetFileStream(string filePath);
        string GetContentType(string fileExtention);
    }
}
