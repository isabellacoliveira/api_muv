using AutoMapper;
using portoApplicationV1.DTOs.Container;
using setorPortuario.Models;

namespace portoApplicationV1.Profiles;

public class ContainerProfile : Profile
{
    public ContainerProfile()
    {
        CreateMap<CreateContainerDTO, Container>(); 
        CreateMap<Container, CreateContainerDTO>(); 
        CreateMap<UpdateContainerDTO, Container>(); 
        CreateMap<Container, UpdateContainerDTO>(); 
        CreateMap<ContainerResponseDTO, Container>(); 
        CreateMap<Container, ContainerResponseDTO>(); 
    }
}