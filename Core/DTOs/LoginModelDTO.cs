using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record LoginModelDTO
    {
        [Required(ErrorMessage = "O usuário é obrigatório")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Password { get; set; }
    }
}
