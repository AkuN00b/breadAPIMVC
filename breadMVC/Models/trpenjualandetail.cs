using System.ComponentModel.DataAnnotations;

namespace breadMVC.Models
{
    public class trpenjualandetail
    {
        [Key]
        public int pde_id { get; set; }
        public int pen_id { get; set; }
        public int oba_id { get; set; }
        public string pde_kode { get; set; }
        public string pde_nama { get; set; }
        public int pde_harga { get; set; }
        public int pde_quantity { get; set; }
    }
}
