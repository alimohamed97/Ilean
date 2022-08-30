using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Entities
{
    public class A3details 
    {
        [Key]
        public int A3detailId { get; set; }

        [ForeignKey("A3header")]
        public int A3headerId { get; set; }
        public string BackgroundDes { get; set; }
        public string BackgroundUpload { get; set; }
        public string CurrentStateDes { get; set; }
        public string CurrentStateUpload { get; set; }
        public string FutureStateDes { get; set; }
        public string FutureStateUpload { get; set; }
        public string AnalysisAndRootCauseRcupload { get; set; }
        public string AnalysisAndRootCauseRcDes { get; set; }

        public string CountermeasuresCmdes { get; set; }
        public string CountermeasuresCmupload { get; set; }
        public string AssuranceDes { get; set; }
        public string AssuranceUpload { get; set; }
        public string StandardizationDes { get; set; }
        public string StandardizationUpload { get; set; }
        public string FiveMiniteReviewUpload { get; set; }
        public string FiveMiniteReviewDes { get; set; }
        public virtual A3header A3header { get; set; }
    }
}
