using System.ComponentModel.DataAnnotations;


namespace breadMVC.Models
{
    public class msobat
    {
        [Key]
        public int oba_id { get; set; }
        public string oba_kode { get; set; }
        public string oba_nama { get; set; }
        public int oba_harga { get; set; }
        public int oba_quantity { get; set; }
        public string? oba_status { get; set; } = "Ada";
    }
}
