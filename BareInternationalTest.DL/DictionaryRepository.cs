using BareInternationalTest.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BareInternationalTest.DL
{
    public class DictionaryRepository
    {
        private readonly Connection _connection;

        public DictionaryRepository(Connection connection)
        {
            _connection = connection;
        }

        public TranslateModelViewModel ConvertLanguage(Translate request)
        {
            string procedure_name = "sp_TranslateFromEnglishToHungarian";
            TranslateModelViewModel responseText = null;
            using (IDbConnection conn = _connection.CreateConnection())
            {
                var multi = conn.QueryMultiple(procedure_name, new
                {
                    requestData = request.requestText
                }, commandType: CommandType.StoredProcedure);
                responseText.translate = multi.Read<Translate>().SingleOrDefault();
                responseText.translateModel = multi.Read<TranslateModel>().SingleOrDefault();
                /*response.responseStatus = multi.Read<ResponseStatusModel>().SingleOrDefault();*/
            }
            return responseText;
        }

    }
}
