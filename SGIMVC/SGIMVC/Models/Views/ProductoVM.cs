using Microsoft.AspNetCore.Mvc.Rendering;
using SGIMVC.Models.DTO;

namespace SGIMVC.Models.Views
{
    public class ProductoVM
    {
        public IEnumerable<SelectListItem> ListProductos {  get; set; }
        public ProductoDTO Producto { get; set; }

    }
}
