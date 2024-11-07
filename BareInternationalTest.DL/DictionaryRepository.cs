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
            TranslateModelViewModel response=new TranslateModelViewModel();
            using (IDbConnection conn = _connection.CreateConnection())
            {
                using (var multi = conn.QueryMultiple(procedure_name, new
                {
                    requestData = request.requestText
                }, commandType: CommandType.StoredProcedure))
                {
                    // Read the first result set (Translate data)
                    response.translate = multi.Read<Translate>().SingleOrDefault();

                    // Check if the first result set is null or empty
                    if (response.translate == null)
                    {
                        response.translateModel = new TranslateModel
                        {
                            status = "error",
                            errorMsg = "No translation found"
                        };
                    }
                    else
                    {
                        // Read the second result set (TranslateModel data)
                        response.translateModel = multi.Read<TranslateModel>().SingleOrDefault();
                    }
                }

                // If the second result set (TranslateModel) is null, set default values
                if (response.translateModel == null)
                {
                    response.translateModel = new TranslateModel
                    {
                        status = "error",
                        errorMsg = "Error in fetching status"
                    };
                }
            }

            return response;
        }

    }
}
