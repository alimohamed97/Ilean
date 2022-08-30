using Data.Entity.Base;
using Data.Entity.Entities.KaizenCard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class KaizenCardDetails 
    {
        [Key]
        public int KaizenCardDetailsID { get; set; }

        [ForeignKey("KaizenCardHeader")]
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

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }


        [ForeignKey("FinanceVertification")]
        public int FinanceVertificationId { get; set; }

        [ForeignKey("Statues")]
        public int StatuesId { get; set; }
        public virtual FinanceVertification FinanceVertification {get; set;}
        public virtual KaizenCardHeader KaizenCardHeader { get; set; }
        public virtual Statues Statues { get; set; }
        public virtual Currency Currency { get; set; }


    }

}
