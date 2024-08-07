using System.Collections.Concurrent;
using MockTalksAPI.Models;

namespace MockTalksAPI.Services;
public class MT_MessagingConnectService
{
    private readonly ConcurrentDictionary<string, MT_MessagingConnect> _connections = new();

    public ConcurrentDictionary<string, MT_MessagingConnect> connections => _connections; 
}