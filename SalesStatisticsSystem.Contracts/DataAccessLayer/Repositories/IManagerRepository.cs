﻿using SalesStatisticsSystem.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsSystem.Contracts.DataAccessLayer.Repositories
{
    public interface IManagerRepository : IGenericRepository<ManagerDto>
    {
        void AddUniqueManagerToDatabase(ManagerDto managerDto);

        int? GetId(string managerLastName);
    }
}