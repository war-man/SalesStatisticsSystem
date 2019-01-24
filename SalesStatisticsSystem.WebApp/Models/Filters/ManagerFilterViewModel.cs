﻿using SalesStatisticsSystem.WebApp.Models.Filters.Abstract;

namespace SalesStatisticsSystem.WebApp.Models.Filters
{
    public class ManagerFilterViewModel : PagedListParameterViewModel
    {
        public string LastName { get; set; } = null;
    }
}