using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO.QrmDto
{
    public class QrmImprovmentDto
    {
        public int QrmImprovmenId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UploadFile { get; set; }
        public string DownloadFile { get; set; }
        public int QrmHeaderId { get; set; }
        public int QrmCategoreyServiceId { get; set; }
    }
}
