using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestToDoUus.Models;
using TestToDoUus.Repository;
using TestToDoUus.Utility;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TestToDoUus.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    [ApiController]

    public class TodoController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public TodoController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        //Get All Todo
        [HttpGet]
        [Route("GetAllToDo")]
        public IActionResult GetAllToDo()
        {
            var data = DbClientFactory<UserDbClient>.Instance.GetAllToDo(appSettings.Value.DbConn);
            return Ok(data);
        }

        //Get Todo By ID
        [HttpGet]
        [Route("GetToDoByID/{idtable}")]
        public IActionResult GetToDoByID(int idtable)
        {
            var data = DbClientFactory<UserDbClient>.Instance.GetToDoByID(idtable, appSettings.Value.DbConn);
            return Ok(data);
        }

        //Get Next Todo
        [HttpGet]
        [Route("GetToDoByID/{today}")]
        public IActionResult GetNextTodo(string today)
        {
            var data = DbClientFactory<UserDbClient>.Instance.GetNextTodo(today, appSettings.Value.DbConn);
            return Ok(data);
        }

        //Save Todo
        [HttpPost]
        [Route("SaveTodo")]
        public IActionResult SaveTodo([FromBody]Todo model)
        {
            var msg = new Message<Todo>();
            var data = DbClientFactory<UserDbClient>.Instance.SaveTodo(model, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Todo saved successfully";
                //if (model.Id == 0)
                //    msg.ReturnMessage = "User saved successfully";
                //else
                //    msg.ReturnMessage = "User updated successfully";
            }

            return Ok(msg);
        }

        //Update Todo
        [HttpPut]
        [Route("UpdateTodo/{idtable}")]
        public IActionResult UpdateTodo(int idtable, [FromBody]Todo model)
        {
            var msg = new Message<Todo>();
            var data = DbClientFactory<UserDbClient>.Instance.UpdateTodo(idtable, model, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Todo updated successfully";
            }
            return Ok(msg);
        }


        //Update Todo Complete
        [HttpPut]
        [Route("UpdateTodo/{idtable}/{complete}")]
        public IActionResult UpdateTodoComplete(int idtable, Decimal complete)
        {
            var msg = new Message<Todo>();
            var data = DbClientFactory<UserDbClient>.Instance.UpdateTodoComplete(idtable, complete, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Todo Set Complete successfully";
            }
            return Ok(msg);
        }

        //Update Todo Is Done
        [HttpPut]
        [Route("UpdateTodo/{idtable}/{isdone}")]
        public IActionResult UpdateTodoDone(int idtable, int isdone)
        {
            var msg = new Message<Todo>();
            var data = DbClientFactory<UserDbClient>.Instance.UpdateTodoDone(idtable, isdone, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Todo Set Is Done successfully";
            }
            return Ok(msg);
        }

        //Delete Todo
        [HttpPost]
        [Route("DeleteTodo")]
        public IActionResult DeleteUser([FromBody]Todo model)
        {
            var msg = new Message<Todo>();
            var data = DbClientFactory<UserDbClient>.Instance.DeleteTodo(model.idtable, appSettings.Value.DbConn);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "User Deleted";
            }
            else if (data == "C203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Invalid record";
            }
            return Ok(msg);
        }
    }
}