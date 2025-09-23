using AutoMapper;
using IntelliCareManagement.Core.DTOs; // Adjust if your DTOs are in a different namespace
using IntelliCareManagement.Domain.Entities;

namespace IntelliCareManagement.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<PatientProfile, PatientDto>().ReverseMap();
            CreateMap<UserSecurity, UserSecurityDto>().ReverseMap();
            CreateMap<Prescription, PrescriptionDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<Document, DocumentDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Consultation, ConsultationDto>().ReverseMap();
        }
    }
}
