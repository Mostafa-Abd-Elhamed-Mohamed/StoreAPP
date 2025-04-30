using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithBrandsAndTypesSpecifications : BaseSpecifications<Product,int>
    {
        public ProductWithBrandsAndTypesSpecifications(int id): base(p => p.Id == id)
        {
            ApplyIncludes();
        }

        public ProductWithBrandsAndTypesSpecifications(ProductSpecificationsParameters specParams) : base(
            
            P=>
             (string.IsNullOrEmpty(specParams.Search) || P.Name.ToLower().Contains(specParams.Search.ToLower())) &&
            (!specParams.BrandId.HasValue||P.BrandId== specParams.BrandId) &&
            (!specParams.TypeId.HasValue || P.TypeId== specParams.TypeId)
            
            )
        {
            ApplyIncludes();

            ApplySorting(specParams.Sort);

            ApplayPagination(specParams.PageIndex, specParams.PageSize);




        }

        private void ApplyIncludes()
        {
            
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }


        private void ApplySorting(string? sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "namedesc":
                        AddOrderByDescending(P => P.Name);
                        break;
                    case "priceasc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "pricedesc":
                        AddOrderByDescending(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(P => P.Name);

            }
        }
    }
}
