using AutoMapper;
using Data.Infrastructure;
using Data.Repositories.Contracts;
using Data.Repositories.Repositories;
using Models.Models;
using Services.Contracts;

namespace Services.Services
{
    public class InvoiceService(IUnitOfWork unitOfWork, IInvoiceRepository InvoiceRepository, IMapper mapper) : IInvoiceService
    {
        public InvoiceDTO AddInvoice(InvoiceDTO model)
        {
            Invoice Invoice = mapper.Map<Invoice>(model);
            InvoiceRepository.Add(Invoice);
            unitOfWork.SaveChanges();
            var x  = mapper.Map<InvoiceDTO>(Invoice);
            return x;
        }

        public void DeleteInvoice(int id)
        {
            Invoice Invoice = mapper.Map<Invoice>(InvoiceRepository.GetById(id));
            if (Invoice != null)
            {
                InvoiceRepository.Delete(Invoice);
                unitOfWork.SaveChanges();
            }
        }

        public InvoiceDTO GetInvoice(int id)
        {
            return mapper.Map<InvoiceDTO>(InvoiceRepository.GetById(id));

        }

        public ICollection<InvoiceDTO> GetInvoices()
        {
            return mapper.Map<List<InvoiceDTO>>(InvoiceRepository.GetAll());
        }
        public ICollection<InvoiceDTO> GetInvoices(int pageNumber, int pageSize)
        {
            return mapper.Map<List<InvoiceDTO>>(InvoiceRepository.GetAll(pageNumber, pageSize));
        }
        public InvoiceDTO UpdateInvoice(InvoiceDTO model)
        {
            Invoice Invoice = mapper.Map<Invoice>(model);
            InvoiceRepository.Update(Invoice);
            unitOfWork.SaveChanges();
            return mapper.Map<InvoiceDTO>(Invoice);
        }
    }
}
