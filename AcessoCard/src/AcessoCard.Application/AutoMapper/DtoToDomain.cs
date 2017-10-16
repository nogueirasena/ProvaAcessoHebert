using AcessoCard.Application.Dto;
using AcessoCard.Domain.Common;
using AcessoCard.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoCard.Application.AutoMapper
{
    public class DtoToDomain : Profile
    {
        protected override void Configure()
        {
            CreateMap<TwitterAuthenticationDto, TwitterAuthentication>();
            CreateMap<SearchDto, TwittCard>();
        }
    }
}
