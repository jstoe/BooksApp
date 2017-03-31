using Microsoft.AspNet.SignalR.Client;
using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BooksApp.Data.Services
{
    public class PortableChat
    {
        private IHubProxy m_ChatHubProxy = null;
        private TaskScheduler m_Scheduler;

        public event Action<string> Receive;

        public async Task<bool> Connect(string url)
        {
            try
            {
                m_Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
                var hubConnection = new HubConnection(url);
                m_ChatHubProxy = hubConnection.CreateHubProxy("DemoHub");
                m_ChatHubProxy.On<string>("Receive", OnReceive);
                await hubConnection.Start();
                return true;
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.Message);
                return false;
            };
        }

        private void OnReceive(string message)
        {
            Task.Factory.StartNew(() => Receive?.Invoke(message), CancellationToken.None,
                                        TaskCreationOptions.None, m_Scheduler);
        }

        public async Task<bool> Send(string message)
        {
            try
            {
                await m_ChatHubProxy.Invoke("Send", message);
                return true;
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.ToString());
                return false;
            };
        }
    }
}
