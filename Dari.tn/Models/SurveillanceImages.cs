namespace Dari.tn.Models
{
    public class SurveillanceImages
    {
        public int idImage { get; set; }
        public byte[] content { get; set; }
        public int? contractId { get; set; }
        public Contract contract { get; set; }
    }
}