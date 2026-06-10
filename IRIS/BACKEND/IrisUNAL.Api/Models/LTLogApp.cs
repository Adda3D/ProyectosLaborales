using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("ltlogapp", Schema = "public")]
    public class LTLogApp
    {
        [Key]
        public long idlogapp { get; set; }
        public string type { get; set; }
        public string guid { get; set; }
        public string appname { get; set; }
        public string webservicename { get; set; }
        public string methodname { get; set; }
        public string methodnameui { get; set; }
        public string username { get; set; }
        public string usermachineinfo { get; set; }
        public string serverip { get; set; }
        public string data { get; set; }
        public string errormessage { get; set; }
        public string source { get; set; }
        public string method { get; set; }
        public string errortype { get; set; }
        public string trace { get; set; }
        public DateTime? creationdate { get; set; }
    }
}