namespace PO.Models
{
    public class Purchaseline
    {
        public int Id { get; set; }

        public int purchaseID { get; set; }

        public string ItemNo { get; set; }

        public decimal Qty { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int IsDeleted { get; set; }
    }
}
