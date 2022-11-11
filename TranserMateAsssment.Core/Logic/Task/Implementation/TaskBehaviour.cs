using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TranserMateAsssment.Core.Common;
using TranserMateAsssment.Core.Common.Infrastructure.TableModels;
using TranserMateAsssment.Core.Logic.Task;
using TranserMateAsssment.Core.Messages;
using TranserMateAsssment.Core.Task.Interfaces;
using TransfermateAssesment.Infrastructure.Task.Interfaces;

namespace TranserMateAsssment.Core.Task.Implementation
{
    public class TaskBehaviour : ITask
    {
        private readonly ITaskDAL _taskDAL;

        public TaskBehaviour(ITaskDAL taskDAL)
        {
            _taskDAL = taskDAL;
        }
        public Responce<TaskMaster> CreateTask(TaskModelDto taskdto, int userId)

        {
            var responce = new Responce<TaskMaster>();

            try
            {
                var task = new TaskMaster() { UserId = userId,Duedate=taskdto.Duedate,Title=taskdto.Title,Status=taskdto.Status };
                
                var IsDuplicateExist = _taskDAL.IsDuplicateExist(task);
                if(IsDuplicateExist)
                {
                    responce.Message = UserMessages.DuplicateTaskError;
                    return responce;
                }
                responce.Data = _taskDAL.CreateTask(task);
            }
            catch (Exception ex)
            {
                responce.Message = UserMessages.InternalServerError;
                throw ex;
            }
            return responce;
        }

        public Responce<TaskMaster> EditTask(TaskModelDto taskdto, int userId)
        {
            var responce = new Responce<TaskMaster>();

            try
            {
                var task = new TaskMaster() { UserId = userId, Duedate = taskdto.Duedate, Title = taskdto.Title, Status = taskdto.Status };

                var IsTaskExist = _taskDAL.IsDuplicateExist(task);
                if (!IsTaskExist)
                {
                    responce.Message = UserMessages.NoTaskFound;
                    return responce;
                }
                responce.Data = _taskDAL.EditTask(task);
            }
            catch (Exception ex)
            {
                responce.Message = UserMessages.InternalServerError;
                throw ex;
            }
            return responce;
        }

        public Responce<List<TaskMaster>> GetOverdueTasks(int UserId)
        {
            var responce = new Responce<List<TaskMaster>>();

            try
            {
                responce.Data=_taskDAL.GetOverdueTasks(UserId);

                if(responce.Data.Count==0)
                {
                    responce.Message = UserMessages.NoTaskFound;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return responce;
        }

        public Responce<List<TaskMaster>> GetPendingTasks(int UserId)
        {
            var responce = new Responce<List<TaskMaster>>();

            try
            {
                responce.Data = _taskDAL.GetPendingTasks(UserId);

                if (responce.Data.Count == 0)
                {
                    responce.Message = UserMessages.NoTaskFound;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return responce;
        }
    }
}
