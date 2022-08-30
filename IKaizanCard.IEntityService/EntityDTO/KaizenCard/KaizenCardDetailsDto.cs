using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class KaizenCardDetailsDto
    {
        public int KaizenCardDetailsID { get; set; }
        public int KaizanCardHeaderID { get; set; }
        public string BeforUploadFileName { get; set; }
        public string DescriptionOfProplem { get; set; }
        public string CauseOfProplem { get; set; }
        public string AfterUploadFileName { get; set; }
        public string CountMeasuers { get; set; }
        public string ResultAndBenfits { get; set; }
        public string CostSavingDiscription { get; set; }
        public long TotalCostSaveingPervation { get; set; }
        public int FinanceVerificationStatus { get; set; }
        public string CostSavingUploadFileName { get; set; }


    }
}
