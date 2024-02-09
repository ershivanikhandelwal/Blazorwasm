using AutoMapper;
using EmployeeManagementModel;
using EmployeeManagementWeb.Models;

namespace EmployeeManagementWeb.Mapping
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(des => des.ConfirmEmail,
                opt => opt.MapFrom(src => src.Email));
            CreateMap<EditEmployeeModel, Employee>();
            CreateMap<Users, UsersModel>();
            CreateMap<UsersModel, Users>();
        }
    }
}
