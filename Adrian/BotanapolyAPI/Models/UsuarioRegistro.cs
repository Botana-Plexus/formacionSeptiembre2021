using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class UsuarioRegistro
    {
        private string? email;
        public string? Email
        {
            get => email;
            set => email = value;
        }
        private string? nick;
        public string? Nick
        {
            get => nick;
            set => nick = value;
        }
        private string? pass;
        public string? Pass
        {
            get => pass;
            set => pass = value;
        }
        private DateTime? fechaNacimiento;
        public DateTime? FechaNacimiento
        {
            get => fechaNacimiento;
            set => fechaNacimiento = value;
        }
    }
}
