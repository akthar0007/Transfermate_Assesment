using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TranserMateAsssment.Core.Common.Infrastructure.TableModels.TaskMaster;

namespace TranserMateAsssment.Core.Logic.Task
{
    public class TaskModelDto
    {
   
        public string Title { get; set; }
        public DateTime? Duedate { get; set; }
        public StatusMaster Status { get; set; }
    }
}
