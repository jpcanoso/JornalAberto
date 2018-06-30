using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JornalAberto2019.Models
{
    public class UserViewModel
    {
        public UserViewModel() { }

        public UserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Name = user.Nome;
            Pontos = user.Pontos;
            Foto = user.Foto;
            Email = user.Email;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int? Pontos { get; set; }
        public string Foto   { get; set; }
        public string Email { get; set; }
    }
}