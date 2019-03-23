﻿using AutoMapper;
using com.application.contracts.Common;
using com.application.entities;

namespace com.application.data.Mappers
{
    public class EntityMapper: IEntityMapper
    {

        private MapperConfiguration _config;


        private IMapper _mapper;

        public EntityMapper()
        {
            Configure();
            Create();
        }

        private void Configure()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<App_T_Employee, Employee>()
                .ForMember(t => t.DepartmentId, m => m.MapFrom(u => u.App_T_DepartmentId))
                .ReverseMap();

               
            });
        }

        private void Create()
        {
            _mapper = _config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}
