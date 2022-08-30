
using Lean.Data.IEntityService.EntityDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.DTO
{

    public class A3SetDto
    {
       
        public int A3headerId { get; set; }
        public int A3number { get; set; }
        public int TeamLeadUserId { get; set; }
        public int TeamCoachId { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        public int A3detailId { get; set; }
        public string BackgroundDes { get; set; }
        public string BackgroundUpload { get; set; }
        public string CurrentStateDes { get; set; }
        public string CurrentStateUpload { get; set; }
        public string FutureStateDes { get; set; }
        public string FutureStateUpload { get; set; }

        //---------------------------------------------------------------

        public string AnalysisAndRootCauseRcupload { get; set; }
        public string CountermeasuresCmdes { get; set; }
        public string CountermeasuresCmupload { get; set; }
        public string AssuranceDes { get; set; }
        public string AssuranceUpload { get; set; }
        public string StandardizationDes { get; set; }
        public string StandardizationUpload { get; set; }
        public string FiveMiniteReviewUpload { get; set; }
        public int UserId { get; set; }
        public int StuffNumber { get; set; }
        public int IssuedByUserId { get; set; }
    }
    public class A3Dto
    {
        public int A3headerId { get; set; }
        public long A3number { get; set; }
        public int TeamLeadUserId { get; set; }
        public int TeamCoachId { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        public int A3detailId { get; set; }
        public string BackgroundDes { get; set; }
        public string CurrentStateDes { get; set; }
        public string FutureStateDes { get; set; }
        public string CountermeasuresCmdes { get; set; }
        public string AssuranceDes { get; set; }
        public string StandardizationDes { get; set; } 
        public int UserId { get; set; }
        public int StuffNumber { get; set; }
        public int IssuedByUserId { get; set; }      
        public DateTime IssuedDate { get; set; }     
        public int UserIdstuffNo { get; set; }   
        public int StatuesId { get; set; }
        public string FiveMiniteReviewDes { get; set; }
        public string TeamMembers { get; set; }
        public string AnalysisAndRootCauseRcDes { get; set; }
        
        public string AnalysisAndRootCauseRcupload { get; set; }
        public string CountermeasuresCmupload { get; set; }
        public string StandardizationUpload { get; set; }
        public string FiveMiniteReviewUpload { get; set; }
        public string FutureStateUpload { get; set; }
        public string CurrentStateUpload { get; set; }
        public string BackgroundUpload { get; set; }
        
        public string AssuranceUpload { get; set; }
    }

    public class A3RowDto
    {

        public int A3headerId { get; set; }
        public long A3number { get; set; }
        public int TeamLeadUserId { get; set; }
        public int TeamCoachId { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        public int A3detailId { get; set; }
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
        public int UserId { get; set; }
        public int StuffNumber { get; set; }
        public int IssuedByUserId { get; set; }
        public DateTime IssuedDate { get; set; }
        public int UserIdstuffNo { get; set; }
        public int StatuesId { get; set; }
        public List<A3ActionsPlanDtoList> A3ActionsPlanDto { get; set; }
        public string TeamMembers { get; set; }
        public string FiveMiniteReviewDes { get; set; }
        

    }

    public class UploadFileDto
    {
        public string AnalysisAndRootCauseRcupload { get; set; }
        public string CountermeasuresCmupload { get; set; }
        public string StandardizationUpload { get; set; }
        public string FiveMiniteReviewUpload { get; set; }
        public string FutureStateUpload { get; set; }
        public string CurrentStateUpload { get; set; }
        public string BackgroundUpload { get; set; }
        public string AssuranceUpload { get; set; }
        public int A3headerId { get; set; }

        public int UploadFlag { get; set; }

    }
}
