using Microsoft.AspNetCore.SignalR;
using MockTalksAPI.Models;
using MockTalksAPI.Services;

namespace MockTalksAPI.Hubs
{
    public class MT_ChatHubs : Hub
    {
        private readonly MT_MessagingConnectService _shared;

        public MT_ChatHubs(MT_MessagingConnectService shared) => _shared = shared;

        public async Task JoinChat(MT_MessagingConnect conn)
        {
            await Clients.All
                .SendAsync("ReceiveMessage", "admin", $"{conn.Usersname} has joined");
        }

        public async Task JoinSpecificChatRoom(MT_MessagingConnect conn)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);

            _shared.connections[Context.ConnectionId] = conn;

            // await Clients.Group(conn.ChatRoom).SendAsync("JoinSpecificChatRoomMsg", "admin", $"{conn.Usersname} has joined {conn.ChatRoom}");
            // await Clients.Group(conn.ChatRoom).SendAsync("RecieveSpecificMessage", "admin", $"{conn.Usersname} has joined {conn.ChatRoom}");
        }

        public async Task SendMessage(string msg)
        {
            if (_shared.connections.TryGetValue(Context.ConnectionId, out MT_MessagingConnect conn))
            {
                await Clients.Group(conn.ChatRoom).SendAsync("RecieveSpecificMessage", conn.Usersname, msg);
            }
        }
    }
}