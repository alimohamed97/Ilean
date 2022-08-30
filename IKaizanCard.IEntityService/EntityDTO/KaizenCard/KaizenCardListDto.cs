using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class KaizenCardListDto
    {
        public int KaizanCardHeaderID { get; set; }
        public string Section { get; set; }
        public int StatusId { get; set; }
        public bool IsDraft { get; set; }
        public long StuffNumber { get; set; }
        public string TotalCostSaveingPervation { get; set; }
        public int UnitAreaID { get; set; }
        public DateTime? ValidUntilDate { get; set; }
        public string Serial { get; set; }
        public string CauseOfProplem { get; set; }
        public string ChampionUserName { get; set; }
        public int KaizenCardDetailsID { get; set; }
        public string KaizenCardimprovment { get; set; }
        public string ResultAndBenfits { get; set; }
        public int ChampionUserID { get; set; }
        public string UnitAreaTital { get; set; }
        public string Theme { get; set; }
        public string Issuedby { get; set; }
        public string IssuedByUserName { get; set; }
        public int ValidatedByUserID { get; set; }
        public string ValidatedByUserName { get; set; }
        public string Department { get; set; }
        public string CreatorUserName { get; set; }
        public string CountMeasuers { get; set; }
        public string CurrencyDesc { get; set; }
        public string CostSavingUploadFileName { get; set; }
        public string DescriptionOfProplem { get; set; }
        public string CostSavingDiscription { get; set; }
        public int CurrencyId { get; set; }
        public int StatuesId { get; set; }
        public string CurrencyName { get; set; }
        public string StatuesName { get; set; }
        public string UserName { get; set; }
        public string SearchText { get; set; }
        public int TeamCoachId { get; set; }
        public string TeamCoachName { get; set; }
        public string AfterUploadFileName { get; set; }
        public string AfterUploadFileNameUrl { get; set; }
        public int DeleteStatus { get; set; }
        public string  BeforUploadFileNameUrl { get; set; }
        public string Number { get; set; }
        public string BeforUploadFileName { get; set; }
        public int FinanceVertificationId { get; set; }
        public string FinanceVertificationName { get; set; }
        public int IssuedByUserId { get; set; }
        public DateTime? issueddate { get; set; }
        public int KaizanCardIssuerDetailsID { get; set; }

     


    }
}
