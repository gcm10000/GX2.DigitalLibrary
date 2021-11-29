using GX2.DigitalLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(DateTime expires, string role, string username);
        string GenerateToken(string secret, DateTime expires, string username, string role);
    }
}
