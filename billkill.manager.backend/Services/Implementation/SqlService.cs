using billkill.manager.backend.Services.Interface;

namespace billkill.manager.backend.Services.Implementation
{
    public class SqlService : ISqlService
    {
        public string GetInvoiceTypes()
        {
            return "SELECT * FROM \"INVOICE_TYPE\"";
        }
    }
}
