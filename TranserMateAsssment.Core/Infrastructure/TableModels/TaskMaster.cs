using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TranserMateAsssment.Core.Common.Infrastructure.TableModels
{
    public class TaskMaster
    {
        public enum StatusMaster
        {
            YET_TO_START, IN_PROGRESS, COMPLETED,
        }
        [Key]
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public  int UserId { get; set; }
        public string Title { get; set; }
        public DateTime? Duedate { get; set; }
        public StatusMaster Status { get; set; }
        [JsonIgnore]
        public virtual UserMaster User { get; set; } =new UserMaster();

    }
}
