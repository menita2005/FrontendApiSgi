namespace SGIMVC.Models.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoriaId { get; set; }
        public double Precio { get; set; }
        public double Cantidad { get; set;}
        public int ProveedoreId { get; set; }
        }
    }

