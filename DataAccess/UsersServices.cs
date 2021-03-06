﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;
using DataAccess.Dao;
using Model.ModelException;

namespace DataAccess
{
    public class UsersServices
    {
        public UsersServices()
        {
        }

        public async Task<bool> AddUser(User user)
        {
            HttpContent postContent = new StringContent(JObject.FromObject(user).ToString());

            postContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var wc = new AuthHttpClient();
            try
            {
                var response = await wc.PostAsync(await ApiAccess.GetRessource(ApiAccess.URL.USERS), postContent);
                GetResponseService.HandleResponse(response, new UserDAO(), false);
                return true;
            }
            catch (HttpRequestException)
            {
                throw new GetDataException();
            }
        }

        public async Task<List<User>> GetUsers()
        {
            var wc = new AuthHttpClient();
            try
            {
                var reponse = await wc.GetAsync(await ApiAccess.GetRessource(ApiAccess.URL.USERS));
                var usersDao = GetResponseService.HandleResponse(reponse, new UserDAO(), true);
                return ((List<Object>)usersDao).Cast<User>().ToList();
            }
            catch (HttpRequestException)
            {
                throw new GetDataException();
            }
        }
        public async Task<List<User>> GetUsersWithAccount()
        {
            var wc = new AuthHttpClient();
            try
            {
                var reponse = await wc.GetAsync(await ApiAccess.GetRessource(ApiAccess.URL.USER_ACCOUNT));
                var usersDAO = GetResponseService.HandleResponse(reponse, new UserDAO(), true);
                return ((List<object>)usersDAO).Cast<User>().ToList();
            }
            catch (HttpRequestException)
            {
                throw new GetDataException();
            }
        }
    }
}
