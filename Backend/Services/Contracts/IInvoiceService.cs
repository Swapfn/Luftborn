using Models.Models;

namespace Services.Contracts
{
    public interface IInvoiceService
    {
        ICollection<InvoiceDTO> GetInvoices();
        ICollection<InvoiceDTO> GetInvoices(int pageNumber, int pageSize);
        InvoiceDTO GetInvoice(int id);
        InvoiceDTO AddInvoice(InvoiceDTO model);
        InvoiceDTO UpdateInvoice(InvoiceDTO model);
        void DeleteInvoice(int id);
    }
}
