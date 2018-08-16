using DataAccess.Interface;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    class GetResponseService
    {
        public static Object HandleResponse(HttpResponseMessage response,IDaoConvertible toObject ,bool isArray)
        {
            String stringResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                if (stringResult != null && toObject != null)
                {
                    if (isArray)
                    {
                        var result = JArray.Parse(stringResult);
                        return result.Children().Select(t => toObject.ToObjectDao(t).ToObjectModel()).ToList();

                    }
                    else
                    {
                        var result = JObject.Parse(stringResult);
                        return toObject.ToObjectDao(result).ToObjectModel();
                    }
                }
                else
                {
                    return null;
                }


            }

            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        try
                        {
                            var rawError = JArray.Parse(stringResult);
                            IEnumerable<Error> errors = rawError.Children().Select(e => new Error()
                            {
                                Code = e["code"].Value<String>(),
                                Description = e["description"].Value<String>()
                            });
                            throw new Model.ModelException.BadRequestException("Bad request", errors);
                        }
                        catch (JsonReaderException)
                        {
                            IEnumerable<Error> errors = new List<Error>()
                                { new Error()
                                    {
                                        Code = "442",
                                        Description = "Data cannot be processed"
                                    }
                                };

                            throw new Model.ModelException.BadRequestException("Bad request", errors);
                        }

                    case HttpStatusCode.GatewayTimeout:
                        throw new TimeoutException("Server not responding in time");

                    case HttpStatusCode.InternalServerError:
                        throw new Model.ModelException.ServerException("Server Error", "500 " + response.ReasonPhrase);;

                    default:
                        throw new Model.ModelException.ServiceException("Unhandled Error", "Unhandled Error (" + response.StatusCode + ")" + response.ReasonPhrase);
                }
            }
        }
    }
}
