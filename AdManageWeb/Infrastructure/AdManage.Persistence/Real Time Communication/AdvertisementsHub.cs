using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace AdManage.Persistence.Real_Time_Communication
{
    public class AdvertisementsHub : Hub
    {
        public async Task SendMessage(string advertisementId, string newContent) //TODO REAL TIME COMMUNICATION - CHAT APP USAGE 1
        {
            await Clients.All.SendAsync("ReceiveMessage", advertisementId, newContent);
        }
    }

}
