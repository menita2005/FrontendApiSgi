using SGIMVC.Models.DTO;
using SGIMVC.Repository.Interfaces;

namespace SGIMVC.Repository
{
    public class ProductoRepository : Repository<ProductoDTO>, IProductoRepository
    {
        public ProductoRepository(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }
    }
}
