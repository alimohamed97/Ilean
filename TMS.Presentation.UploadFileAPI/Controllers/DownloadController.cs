using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Core.Common.File;
using Presentation.UploadFileAPI;
using static Core.Enum.UploadEnum;
using Presentation.UploadFileAPI.Setting;

namespace Presentation.UploadFileAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        #region CTRS
        private IFileHelper FileHelper { get; }
        private UploadSetting UploadSetting { get; }
        public DownloadController(IFileHelper fileHelper, UploadSetting uploadSetting)
        {
            FileHelper = fileHelper;
            UploadSetting = uploadSetting;
        }
        #endregion

        [HttpGet]
        [Route("{uploadType}/{fileName}")]
        public async Task<IActionResult> DownloadFile(int uploadType, string fileName)
        {
            string filePath = string.Empty;

            switch (uploadType)
            {
                case (int)UploadFileType.System:
                    filePath = Path.Combine(UploadSetting.SystemUploadPath, fileName);
                    break;
                case (int)UploadFileType.UserProfile:
                    filePath = Path.Combine(UploadSetting.UserProfileUploadPath, fileName);
                    break;
                case (int)UploadFileType.LocalizationImage:
                    filePath = Path.Combine(UploadSetting.LocalizationImageUploadPath, fileName);
                    break;
                case (int)UploadFileType.OrganizationImage:
                    filePath = Path.Combine(UploadSetting.OrganizationImageUploadPath, fileName);
                    break;
                case (int)UploadFileType.AppImage:
                    filePath = Path.Combine(UploadSetting.AppImageUploadPath, fileName);
                    break;
                case (int)UploadFileType.APKFile:
                    filePath = Path.Combine(UploadSetting.UploadApplicationAPKPath, fileName);
                    break;
                case (int)UploadFileType.AppIcon:
                    filePath = Path.Combine(UploadSetting.UploadApplicationIconPath, fileName);
                    break;
                case (int)UploadFileType.Device:
                    filePath = Path.Combine(UploadSetting.UploadDeviceImagePath, fileName);
                    break;
                case (int)UploadFileType.Model:
                    filePath = Path.Combine(UploadSetting.UploadModelImagePath, fileName);
                    break;
            }

            return File(await FileHelper.GetFileStream(filePath), FileHelper.GetContentType(filePath), Path.GetFileName(filePath));
        }
    }
}