﻿using AutoMapper;

namespace SuperChef.Web.Infrastructure.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ChefMappingProfile>();
            });
        }

    }
}