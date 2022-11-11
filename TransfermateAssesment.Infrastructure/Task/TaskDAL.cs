using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranserMateAsssment.Core.Common.Infrastructure.TableModels;
using TransfermateAssesment.Infrastructure.DatabaseContext;
using TransfermateAssesment.Infrastructure.Task.Interfaces;
using static TranserMateAsssment.Core.Common.Infrastructure.TableModels.TaskMaster;

namespace TransfermateAssesment.Infrastructure.Task
{
    public class TaskDAL : ITaskDAL
    {
        private readonly TaskContext _taskContext;

        public TaskDAL(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public TaskMaster CreateTask(TaskMaster task)
        {
            try
            {
                _taskContext.Tasks.Add(task);
                _taskContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return task;
            
        }

        public TaskMaster EditTask(TaskMaster task)
        {
            try
            {
                _taskContext.Tasks.Update(task);
                _taskContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return task;
        }

        public List<TaskMaster> GetOverdueTasks(int userId)
        {
            List<TaskMaster> tasks;
            var curruntTime = DateTime.UtcNow;

            try
            {
                tasks = _taskContext.Tasks.Where(ts => ts.Duedate > curruntTime && ts.Status != StatusMaster.COMPLETED &&ts.UserId==userId).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tasks;
        }

        public List<TaskMaster> GetPendingTasks(int userId)
        {
            List<TaskMaster> tasks;
            var curruntTime = DateTime.UtcNow;

            try
            {
                tasks = _taskContext.Tasks.Where(ts => ts.Duedate < curruntTime && ts.Status != StatusMaster.COMPLETED &&ts.UserId==userId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tasks;
        }

        public bool IsDuplicateExist(TaskMaster task)
        {
            var isDuplicateExist = false;

            if(_taskContext.Tasks.Any(s=>s.Title==task.Title&&s.UserId==task.UserId))
            {
                isDuplicateExist=true;
            }
            return isDuplicateExist;
        }
    }
}
