namespace PO.Shared.DTOs
{
    public class PurchaseHeaderDTO
    {
        public string No { get; set; }
        public List<PurchaselineDto> purchaseline { get; set; }


    }
    public class PurchaselineDto
    {

        public string ItemNo { get; set; }

        public decimal Qty { get; set; }


    }
}
