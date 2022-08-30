using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities.Qrm
{
    public class QrmImprovment 
    {
        [Key]
        public int ImprovmentID { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UploadFile { get; set; }
        public string DownloadFile { get; set; }
        [ForeignKey("QrmHeader")]
        public int QrmHeaderId { get; set; }

        //NavigationProperty
        public virtual QrmHeader QrmHeader { get; set; }
    }
}
