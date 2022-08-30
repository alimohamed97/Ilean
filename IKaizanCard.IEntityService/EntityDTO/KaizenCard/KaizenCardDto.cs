using Lean.Data.IEntityService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class KaizenCardDto
    {

        public int KaizanCardHeaderID { get; set; }
        public string Theme { get; set; }
        public string Number { get; set; }
        public int UnitAreaID { get; set; }
        public int CreatedbyUserId { get; set; }
        public int KaizenCardDetailsID { get; set; }
        public string AfterUploadFileName { get; set; }
        public string BeforUploadFileName { get; set; }
        public string DescriptionOfProplem { get; set; }
        public string CauseOfProplem { get; set; }
        
        public string CountMeasuers { get; set; }
        public string ResultAndBenfits { get; set; }
        public string CostSavingDiscription { get; set; }
        public string TotalCostSaveingPervation { get; set; }
        public string FinanceVerificationStatus { get; set; }
        public string CostSavingUploadFileName { get; set; }
        public int KaizanCardIssuerDetailsID { get; set; }
        public string StuffNumber { get; set; }
        public int IssuedByUserId { get; set; }
        public string ValidUntilDate { get; set; }
        public string issueddate { get; set; }
        public int ValidatedByUserID { get; set; }
        public int ChampionUserID { get; set; }

        public int CurrencyId { get; set; }
      
        public int StatusId { get; set; }    
        public string KaizenCardimprovment { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public int TeamCoachId { get; set; }
        public string AfterUploadFileNameUrl { get; set; }
        public string BeforUploadFileNameUrl { get; set; }
        public string UnitAreaTital { get; set; }
        public int FinanceVertificationId { get; set; }
     //   public string FinanceVertificationName { get; set; }

        public bool IsDraft { get; set; }

    }
}
