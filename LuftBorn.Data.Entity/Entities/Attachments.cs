using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class Attachments
    {
        public int Attachmentsid { get; set; }
        public string Attachmentsname  { get; set; }
        public string Uploadfile { get; set; }
        public string AddNewRow { get; set; }


        [ForeignKey("MrWorkStandard")]
        public int MrWorkStandardId { get; set; }
        public virtual WorkStandard MrWorkStandard { get; set; }
    }
}
