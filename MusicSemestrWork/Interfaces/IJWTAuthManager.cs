using System;
using MusicSemestrWork.Models;

namespace MusicSemestrWork.Interfaces
{
    public interface IJWTAuthManager
    {
        string Authenticate(User user);
    }
}
