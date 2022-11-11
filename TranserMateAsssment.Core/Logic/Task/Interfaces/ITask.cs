using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranserMateAsssment.Core.Common;
using TranserMateAsssment.Core.Common.Infrastructure.TableModels;
using TranserMateAsssment.Core.Logic.Task;

namespace TranserMateAsssment.Core.Task.Interfaces
{
    public interface ITask
    {
        Responce<List<TaskMaster>> GetPendingTasks(int UserId);
        Responce<TaskMaster> CreateTask(TaskModelDto task, int userId);
        Responce<TaskMaster> EditTask(TaskModelDto task, int userId);
        Responce<List<TaskMaster>> GetOverdueTasks(int UserId);
    }
}
