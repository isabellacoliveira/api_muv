using AutoMapper;
using portoApplicationV1.DTOs.Movimentacao;
using portoApplicationV1.Models;

namespace portoApplicationV1.Profiles
{
    public class MovimentacaoProfile : Profile
    {
       public MovimentacaoProfile()
       {
            CreateMap<CreateMovimentacaoDTO, Movimentacao>(); 
            CreateMap<Movimentacao, CreateMovimentacaoDTO>(); 
            CreateMap<UpdateMovimentacaoDTO, Movimentacao>(); 
            CreateMap<Movimentacao, UpdateMovimentacaoDTO>(); 
            CreateMap<MovimentacaoResponseDTO, Movimentacao>(); 
            CreateMap<Movimentacao, MovimentacaoResponseDTO>(); 
        }
    }
}