using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Mapping
{
    public class ActivityTaskDTOMapping : Profile
    {
        public ActivityTaskDTOMapping()
        {
            CreateMap<ActivityTask, ActivityTaskDTO>().ReverseMap();
        }
    }
}
