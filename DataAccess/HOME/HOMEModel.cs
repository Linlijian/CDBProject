
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.HOME
{
    [Serializable]
    public class HOMEModel : StandardModel
    {
        [Required]
        [Display(Name = "Id")]
        public string ID { get; set; } //W
        [Display(Name = "Data")]
        public string DATA { get; set; } //H
        public string ALL_SPP { get; set; } //S
        public string ALL_DEPLOYMENT_IT { get; set; } //I
        public string ALL_DEPLOYMENT_DATE { get; set; } //D
        public string CLIENT_ID { get; set; }
        public string YYYY { get; set; }
        public string MM { get; set; }
        public string DD { get; set; }
        public string FILE_EXCEL { get; set; }
        public string FLAG { get; set; }
        public string REMARK { get; set; }

       

        
        public IEnumerable<DDLCenterModel> APP_CODE_MODEL { get; set; }

        public System.Data.DataSet ds { get; set; }
    }
    
}