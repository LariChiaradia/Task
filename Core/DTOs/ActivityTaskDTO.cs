using Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    record class ActivityTaskDTO
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        [Required(ErrorMessage = "O titulo é obrigatório")]
        [StringLength(80)]
        public string? Title { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatório")]
        [StringLength(300)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "A prioridade é obrigatório")]
        public Priority Priority { get; set; }
        [Required(ErrorMessage = "A dificuldade é obrigatório")]
        public Difficulty Difficulty { get; set; }
    }
}
