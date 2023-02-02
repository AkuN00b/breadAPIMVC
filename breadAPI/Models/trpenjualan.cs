using System.ComponentModel.DataAnnotations;


namespace breadAPI.Models
{
    public class trpenjualan
    {
        [Key]
        public int pen_id { get; set; }
        public string pen_no_invoice { get; set; }
        public DateTime pen_waktu { get; set; } = DateTime.Now;
        public int pen_bayar { get; set; }
        public int pen_kembali { get; set; }
    }
}
