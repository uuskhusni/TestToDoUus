using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TestToDoUus.Models;
using TestToDoUus.Utility;

namespace TestToDoUus.Translators
{
    public static class UserTranslator
    {
        public static Todo TranslateAsTodo(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Todo();
            if (reader.IsColumnExists("idtable"))
                item.idtable = SqlHelper.GetNullableInt32(reader, "idtable");

            if (reader.IsColumnExists("dateexpire"))
                item.dateexpire = SqlHelper.GetNullableDate(reader, "dateexpire");

            if (reader.IsColumnExists("title"))
                item.title = SqlHelper.GetNullableString(reader, "title");

            if (reader.IsColumnExists("description"))
                item.description = SqlHelper.GetNullableString(reader, "description");

            if (reader.IsColumnExists("complete"))
                item.complete = SqlHelper.GetNullableDecimal(reader, "complete");

           
            return item;
        }

        public static List<Todo> TranslateAsTodosList(this SqlDataReader reader)
        {
            var list = new List<Todo>();
            while (reader.Read())
            {
                list.Add(TranslateAsTodo(reader, true));
            }
            return list;
        }
    }
}
