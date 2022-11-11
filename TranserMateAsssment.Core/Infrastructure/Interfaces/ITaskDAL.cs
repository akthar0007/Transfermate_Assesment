using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranserMateAsssment.Core.Common.Infrastructure.TableModels;

namespace TransfermateAssesment.Infrastructure.Task.Interfaces
{
    public interface ITaskDAL
    {
        List<TaskMaster> GetOverdueTasks(int userId);
        List<TaskMaster> GetPendingTasks(int userId);
        TaskMaster CreateTask(TaskMaster task);
        bool IsDuplicateExist(TaskMaster task);
        TaskMaster EditTask(TaskMaster task);
    }
}
