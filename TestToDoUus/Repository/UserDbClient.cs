using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TestToDoUus.Models;
using TestToDoUus.Utility;
using TestToDoUus.Translators;


namespace TestToDoUus.Repository
{
    public class UserDbClient
    {
        public List<Todo> GetAllToDo(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<Todo>>(connString,
                "GetAllToDo", r => r.TranslateAsTodosList());
        }

        public List<Todo> GetToDoByID(int idtable, string connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@idtable", idtable)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<Todo>>(connString,
                "GetAllToDoById", r => r.TranslateAsTodosList(), param);
        }

        public List<Todo> GetNextTodo(string today, string connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@today", today)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<Todo>>(connString,
                "GetNextTodo", r => r.TranslateAsTodosList(), param);
        }

        public string SaveTodo(Todo model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                //new SqlParameter("@Id",model.Id),
                new SqlParameter("@dataexpire",model.dateexpire),
                new SqlParameter("@title",model.title),
                new SqlParameter("@description",model.description),
                new SqlParameter("@complete",model.complete),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "CreateTodo", param);
            return (string)outParam.Value;
        }

        public string UpdateTodo(int idtable, Todo model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@idtable", idtable),
                new SqlParameter("@dataexpire",model.dateexpire),
                new SqlParameter("@title",model.title),
                new SqlParameter("@description",model.description),
                new SqlParameter("@complete",model.complete),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "UpdateTodo", param);
            return (string)outParam.Value;
        }

        public string UpdateTodoComplete(int idtable, Decimal complete, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@idtable", idtable),
                new SqlParameter("@complete", complete),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "UpdateTodoComplete", param);
            return (string)outParam.Value;
        }

        public string UpdateTodoDone(int idtable, int isdone, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@idtable",idtable),
                new SqlParameter("@isdone", isdone),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "UpdateTodoDone", param);
            return (string)outParam.Value;
        }

        public string DeleteTodo(int idtable, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@idtable",idtable),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "DeleteTodo", param);
            return (string)outParam.Value;
        }
    }
}
