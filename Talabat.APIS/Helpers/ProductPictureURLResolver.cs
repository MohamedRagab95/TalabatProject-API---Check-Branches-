using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Talabat.APIS.DTOs;
using Talabat.Core.Entities;

namespace Talabat.APIS.Helpers
{
    public class ProductPictureURLResolver : IValueResolver<Product, ProductDtO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureURLResolver(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        public string Resolve(Product source, ProductDtO destination, string destMember, ResolutionContext context)
        {
            if(!source.PictureUrl.IsNullOrEmpty())
            { return $"{_configuration["BaseApiUrl"]}/{source.PictureUrl}"; }

            return string.Empty ;
        }   
    }
}
