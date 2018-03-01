namespace EvolutionIT.Template.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EvolutionIT.Template.Application.Interfaces;
    using EvolutionIT.Template.Application.ViewModels;
    using EvolutionIT.Template.Domain.Interfaces;
    using EvolutionIT.Template.Domain.Models;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;

    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerAppService(IMapper mapper
            , ICustomerRepository repository
            , IUnitOfWork unitOfWork)             
        {
            _customerRepository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CustomerViewModel customerViewModel)
        {
            var customer = _mapper.Map<Customer>(customerViewModel);
            _customerRepository.Add(customer);
            _unitOfWork.Commit();
        }

        public bool Any(Func<CustomerViewModel, bool> func)
        {
            return _customerRepository.GetAll()
                .ProjectTo<CustomerViewModel>()
                .Any(func);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
            _unitOfWork.Dispose();
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _customerRepository.GetAll()
                .ProjectTo<CustomerViewModel>();
        }

        public CustomerViewModel GetById(int id)
        {
            var customer = _customerRepository.GetById(id);
            return _mapper.Map<CustomerViewModel>(customer);
        }

        public CustomerViewModel GetByIdNoTracking(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Detach(customer);
            return _mapper.Map<CustomerViewModel>(customer);
        }

        public void Remove(int id)
        {
            _customerRepository.Remove(id);
            _unitOfWork.Commit();
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var customer = _mapper.Map<Customer>(customerViewModel);
            _customerRepository.Update(customer);
            _unitOfWork.Commit();
        }
    }
}
