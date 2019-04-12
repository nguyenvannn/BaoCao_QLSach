using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Taikhoan
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; }
        public int UserId { get; set; }
        public DTO_Taikhoan(int id, string username, string password, int userid)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.UserId = userid;


        }
    }
}
