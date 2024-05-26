namespace CHWDotNetCore.PizzaApi.Queries
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery = 
            @"SELECT po.*, p.Pizza, p.Price FROM [dbo].[Tbl_PizzaOrder] po
            inner join Tbl_Pizza p on p.PizzaId = po.PizzaId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";

        public static string PizzaOrderDetailQuery =
            @"SELECT pod.*, pe.PizzaExtraName, pe.Price FROM [dbo].[Tbl_PizzaOrderDetail] pod
            inner join Tbl_PizzaExtra pe on pod.PizzaExtraId = pe.PizzaExtraId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
    }
}
