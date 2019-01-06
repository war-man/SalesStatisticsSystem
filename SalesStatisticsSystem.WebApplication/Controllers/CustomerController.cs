﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using SalesStatisticsSystem.Contracts.Core.DataTransferObjects;
using SalesStatisticsSystem.Core.Services;
using SalesStatisticsSystem.WebApplication.Models;

namespace SalesStatisticsSystem.WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;

        private readonly IMapper _mapper;

        public CustomerController()
        {
            _mapper = Support.AutoMapper.CreateConfiguration().CreateMapper();

            _customerService = new CustomerService();
        }

        public async Task<ActionResult> Index()
        {
            var customersDto = await _customerService.GetAllAsync();

            var customersViewModels = _mapper.Map<IEnumerable<CustomerViewModel>>(customersDto);

            return View(customersViewModels);
        }

        public ActionResult Details(int id)
        {
            // TODO: Make additional fields (Address, Email, Phone number)

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            try
            {
                _customerService.Add(_mapper.Map<CustomerDto>(customer));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var customerDto = _customerService.GetAsync(id);

            var customerViewModel = _mapper.Map<CustomerViewModel>(customerDto);

            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            try
            {
                _customerService.Update(_mapper.Map<CustomerDto>(customer));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _customerService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}