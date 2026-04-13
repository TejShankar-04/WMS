using Microsoft.EntityFrameworkCore;

namespace PO.Models
{
    [Index(nameof(purchaseID), IsUnique = true)]
    public class PurchaseHeader
    {

        public int Id { get; set; }

        public int purchaseID { get; set; }

        public string No { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int IsDeleted { get; set; }
    }
}
