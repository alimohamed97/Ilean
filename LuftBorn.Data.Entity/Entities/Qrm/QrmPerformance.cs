﻿using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities.Qrm
{
    public class QrmPerformance : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UploadFile { get; set; }
        public string DownloadFile { get; set; }
        public virtual QrmHeader QrmHeader { get; set; }

    }
}
