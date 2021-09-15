using System;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.User.Queries.GetDetails
{
    public class UserDetailsVm:IMapWith<Domain.User>
    {
        public String FIO { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public DateTime LastLogin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.User, UserDetailsVm>()
                .ForMember(userVm => userVm.FIO,
                    opt => opt.MapFrom(user => user.FIO))
                .ForMember(userVm => userVm.Phone,
                    opt => opt.MapFrom(user => user.Phone))
                .ForMember(userVm => userVm.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.LastLogin,
                    opt => opt.MapFrom(user => user.LastLogin));
        }
    }
    
}