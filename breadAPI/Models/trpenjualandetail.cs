using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breadAPI.Models
{
    public class trpenjualandetail
    {
        [Key]
        public int pde_id { get; set; }
        [ForeignKey("trpenjualan")]
        public int pen_id { get; set; }
        [ForeignKey("msobat")]
        public int oba_id { get; set; }
        public string pde_kode { get; set; }
        public string pde_nama { get; set; }
        public int pde_harga { get; set; }
        public int pde_quantity { get; set; }
    }
}
