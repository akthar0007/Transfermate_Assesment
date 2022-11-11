using Microsoft.AspNetCore.Mvc;
using System.Net;
using TranserMateAsssment.Core.Common;
using TranserMateAsssment.Core.Common.Infrastructure.TableModels;
using TranserMateAsssment.Core.Logic.Task;
using TranserMateAsssment.Core.Messages;
using TranserMateAsssment.Core.Task.Interfaces;
using TranserMateAsssment.Core.UtilityObjects;

namespace TransfaerMate_Assesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
      
        private readonly ILogger<TaskController> _logger;
        private readonly ITask _task;
        private readonly HTTPHeader _header;

        public TaskController(ILogger<TaskController> logger , ITask task, HTTPHeader hTTPHeader)
        {
            _logger = logger;
            _task = task;
            _header = hTTPHeader;
        }

        [HttpGet("GetPedingTasks",Name = "GetPendingTasks")]
        public IActionResult GetPedingTasks()
        {
            Responce<List<TaskMaster>> responce = new Responce<List<TaskMaster>>();
            if (!ModelState.IsValid)
            {
                responce.Data = null;
                responce.Statuscode = HttpStatusCode.BadRequest.ToString();
                responce.Message = UserMessages.InputValidationError;
                return BadRequest(responce);
            }

            try
            {
                responce = _task.GetPendingTasks(_header.EndUserId);
                responce.Statuscode = HttpStatusCode.OK.ToString();
                return Ok(responce);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                responce.Statuscode = HttpStatusCode.InternalServerError.ToString();
                return Ok(responce);

            }
        }
        [HttpPost("CreateTask",Name = "CreateTask")]
        public IActionResult CreateTask([FromBody] TaskModelDto task)
        {
            Responce<TaskMaster> responce = new Responce<TaskMaster>();
            var userId = _header.EndUserId;
            if (!ModelState.IsValid)
            {
                responce.Data = null;
                responce.Statuscode = HttpStatusCode.BadRequest.ToString();
                responce.Message = UserMessages.InputValidationError; 
                return BadRequest(responce);
            }

            try
            {
                responce = _task.CreateTask(task, userId);
                responce.Statuscode = HttpStatusCode.OK.ToString();
                return Ok(responce);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                responce.Statuscode = HttpStatusCode.InternalServerError.ToString();
                return Ok(responce);

            }

        }
        [HttpPut("EditTask",Name = "EditTask")]
        public IActionResult EditTask([FromBody] TaskModelDto task)
        {
            Responce<TaskMaster> responce = new Responce<TaskMaster>();
            
            if (!ModelState.IsValid)
            {
                responce.Data = null;
                responce.Statuscode = HttpStatusCode.BadRequest.ToString();
                responce.Message = UserMessages.InputValidationError;
                return BadRequest(responce);
            }

            try
            {
                responce = _task.EditTask(task, _header.EndUserId);
                responce.Statuscode = HttpStatusCode.OK.ToString();
                return Ok(responce);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                responce.Statuscode = HttpStatusCode.InternalServerError.ToString();
                return Ok(responce);

            }

        }
        [HttpGet("GetOverdueTasks",Name = "GetOverdueTasks")]
        public IActionResult GetOverdueTasks()
        {
            Responce<List<TaskMaster>> responce =new Responce<List<TaskMaster>>();
            if (!ModelState.IsValid)
            {
                responce.Data = null;
                responce.Statuscode=HttpStatusCode.BadRequest.ToString();
                responce.Message = UserMessages.InputValidationError;
                return BadRequest(responce);
            }
             
            try
            {
                responce = _task.GetOverdueTasks(_header.EndUserId);
                responce.Statuscode = HttpStatusCode.OK.ToString();
                return Ok(responce);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                responce.Statuscode = HttpStatusCode.InternalServerError.ToString();
                return Ok(responce);

            }
            

        }
    }
}