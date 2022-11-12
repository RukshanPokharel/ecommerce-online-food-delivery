using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DriverApplication.Models
{
    public class DriverTeam : BaseModel.BaseModelEntity
    {
        private int team_id;
        [Column("team_id")]
        [Key]
        [IgnoreDataMember]
        public int Team_id { get => team_id; set => team_id = value; }

        private string team_name;
        [Column("team_name")]
        [StringLength(255)]
        public string Team_name { get => team_name; set => team_name = value; }

        private string location_accuracy;
        [Column("location_accuracy")]
        [StringLength(50)]
        public string Location_accuracy { get => location_accuracy; set => location_accuracy = value; }

        private string status;
        [Column("status")]
        [StringLength(255)]
        public string Status { get => status; set => status = value; }

        [InverseProperty("DriverTeam1")]
        [JsonIgnore]
        public virtual ICollection<Driver> Drivers { get; set; }

        private ICollection<DriverTask> DriverTask;
        [JsonIgnore]
        public virtual ICollection<DriverTask> DriverTask1 { get => DriverTask; set => DriverTask = value; }

        private ICollection<BulkPush> BulkPush;
        [JsonIgnore]
        public virtual ICollection<BulkPush> BulkPush1 { get => BulkPush; set => BulkPush = value; }
    }
}