using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TranserMateAsssment.Core.Common.Infrastructure.TableModels
{
    public class UserMaster
    {

        public UserMaster()
        {
            Tasks=new HashSet<TaskMaster>();
        }
        [Key]
        [JsonIgnore]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<TaskMaster> Tasks { get; set; }
    }
}
