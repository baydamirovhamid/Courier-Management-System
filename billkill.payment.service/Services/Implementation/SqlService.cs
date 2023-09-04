using billkill.payment.service.Services.Interface;

namespace billkill.payment.service.Services.Implementation
{
    public class SqlService : ISqlService
    {
        public string GetInvoiceTypes()
        {
            return "SELECT * FROM \"INVOICE_TYPE\"";
        }
    }
}
