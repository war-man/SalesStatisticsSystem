﻿using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SalesStatisticsSystem.Contracts.Core.DataTransferObjects;
using SalesStatisticsSystem.Contracts.DataAccessLayer.Repositories;
using SalesStatisticsSystem.DataAccessLayer.Repositories.Abstract;
using SalesStatisticsSystem.Entity;

namespace SalesStatisticsSystem.DataAccessLayer.Repositories
{
    public class CustomerRepository : GenericRepository<CustomerDto, Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesInformationEntities context, IMapper mapper) : base(context, mapper)
        {
        }

        public void AddUniqueCustomerToDatabase(CustomerDto customerDto)
        {
            Expression<Func<CustomerDto, bool>> predicate = x =>
                x.LastName == customerDto.LastName && x.FirstName == customerDto.FirstName;

            if (Find(predicate).Any()) return;

            Add(customerDto);
        }

        public int? GetId(string customerFirstName, string customerLastName)
        {
            Expression<Func<CustomerDto, bool>> predicate = x =>
                x.FirstName == customerFirstName && x.LastName == customerLastName;

            return Find(predicate).First().Id;
        }
    }
}