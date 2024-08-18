using AutoMapper;
using GeekShopping.ProductApi.Models.Context;
using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductVO, Product>().ReverseMap();
        });
        return mappingConfig;
    }
}