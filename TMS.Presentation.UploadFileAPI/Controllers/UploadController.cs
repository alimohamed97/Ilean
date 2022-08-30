using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Common.File;
using Presentation.UploadFileAPI.Models;
using Presentation.UploadFileAPI.Setting;
using static Core.Enum.UploadEnum;
using Core.Common.Dto.Response;
using Resources;

namespace Presentation.UploadFileAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UploadController : ControllerBase
    {
        #region CTRS
        private IFileHelper FileHelper { get; }
        private UploadSetting UploadSetting { get; }
        public UploadController(IFileHelper fileHelper, UploadSetting uploadSetting)
        {
            FileHelper = fileHelper;
            UploadSetting = uploadSetting;
        }
        #endregion

        
        [HttpPost]
        public async Task<IActionResult> UploadImageFile()
        {
            var file = Request.Form.Files[0];
            string result = await FileHelper.SaveFileAsync(file, UploadSetting.OrganizationImageUploadPath);

            UploadResponse uploadResponse = new UploadResponse
            { Url = $"{UploadSetting.ContentServerUrl}{(int)UploadFileType.OrganizationImage}/{result}", FileName = result };
            return Ok(uploadResponse);
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadGeneralFile()
        {
            var file = Request.Form.Files[0];
            string result = await FileHelper.SaveFileAsync(file, UploadSetting.OrganizationImageUploadPath);

            UploadResponse uploadResponse = new UploadResponse
            { Url = $"{UploadSetting.ContentServerUrl}{(int)UploadFileType.OrganizationImage}/{result}", FileName = result };
            return Ok(uploadResponse);
        }

        [HttpPost, DisableRequestSizeLimit]
    
        public async Task<IActionResult> UploadFile()
        {
            var file = Request.Form.Files[0];
            string result = await FileHelper.SaveFileAsync(file, UploadSetting.OrganizationImageUploadPath);

            UploadResponse uploadResponse = new UploadResponse
            { Url = $"{UploadSetting.ContentServerUrl}{(int)UploadFileType.OrganizationImage}/{result}", FileName = result };

            ResponseDto<UploadResponse> _uploadResponse = new ResponseDto<UploadResponse>();
            _uploadResponse.ReturnSuccess(uploadResponse, "File Succeded Upload");
 
            return Ok(_uploadResponse);
        }


    }
}