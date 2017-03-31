﻿using Honeywell.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.Portable.Services
{
    public class LoginService : ILoginService
    {
        private ISettingsService m_SettingsService;

        /// <summary>Initializes a new instance of the <see cref="LoginService"/> class.</summary>
        public LoginService(ISettingsService settingsService) // e.g. LoginService(IMyApiClient client)
        {
            this.m_SettingsService = settingsService;
            // this constructor would most likely contain some form of API Client that performs
            // the message creation, sending and deals with the response from a remote API
        }

        /// <summary>
        /// Gets a value indicating whether the user is authenticated.
        /// </summary>
        public bool IsAuthenticated { get; private set; }

        /// <summary>Gets the error message.</summary>
        /// <value>The error message.</value>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Attempts to log the user in using stored credentials if present
        /// </summary>
        /// <returns> <see langword="true"/> if the login is successful, false otherwise </returns>
        public bool Login()
        {
            // get the stored username from previous sessions
            // var username = Settings.UserName;
            var username = m_SettingsService.Get<string>("UserName");
            // force return of false just for demo purposes
            IsAuthenticated = !string.IsNullOrWhiteSpace(username);
            return IsAuthenticated;
        }

        /// <summary>The login method to retrieve OAuth2 access tokens from an API. </summary>
        /// <param name="userName">The user Name (email address) </param>
        /// <param name="password">The users <paramref name="password"/>. </param>
        /// <param name="scope">The required scopes. </param>
        /// <returns>The <see cref="bool"/>. </returns>
        public bool Login(string userName, string password, string scope)
        {
            try
            {
                //IsAuthenticated = _apiClient.ExchangeUserCredentialsForTokens(userName, password, scope);
            }
            catch (ArgumentException argex)
            {
                ErrorMessage = argex.Message;
                IsAuthenticated = false;
            }
            SaveIfAuthenticated(userName);
            return IsAuthenticated;
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The users password.</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            // this simply returns true to mock a real login service call
            IsAuthenticated = userName.Contains(password);
            SaveIfAuthenticated(userName);
            return IsAuthenticated;
        }

        private void SaveIfAuthenticated(string userName)
        {
            if (IsAuthenticated)
                m_SettingsService.Set("UserName", userName);
        }
    }

}