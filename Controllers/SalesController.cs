﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EHA_AspNetCore.Models.Sales;
using EHA_AspNetCore.Data;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore.Models.Payments;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace EHA_AspNetCore.Controllers
{
    public class SalesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISaleService _saleService;
        private readonly IPaymentConditionService _paymentConditionService;
        private List<ItemSale> _itemSaleList { get; set; }

        public SalesController(AppDbContext context, ISaleService saleService, IPaymentConditionService paymentConditionService)
        {
            _context = context;
            _saleService = saleService;
            _paymentConditionService = paymentConditionService;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Sales.Include(s => s.Customer).Include(s => s.PaymentCondition);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.PaymentCondition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name");

            var initialPayCondTask = _paymentConditionService.GetFirstOrDefaultPaymentCondition();
            var initialPayCond = await initialPayCondTask;
            var sale = new Sale();
            sale.PaymentCondition = initialPayCond;

            return View(sale);
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,PaymentConditionId,CancellationDate,CancellationMotive,Value,Id")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email", sale.CustomerId);
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", sale.PaymentConditionId);

            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email", sale.CustomerId);
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", sale.PaymentConditionId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,PaymentConditionId,CancellationDate,CancellationMotive,Value,Id")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email", sale.CustomerId);
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", sale.PaymentConditionId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.PaymentCondition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> GetPV(int id)
        {
            var paymentCondition = _paymentConditionService.PopulateFullObjectFromId(id);
            var x = await paymentCondition;
            //return Json(x);
            return PartialView("_PaymentConditionPV", x);
        }

        [HttpPost]
        public async Task<IActionResult> SetListItemSale(int id, int qtd, decimal discount)
        {
            if (id <= 0 || qtd <= 0 || discount < 0)
            {
                return null;
            }
            if (_itemSaleList == null)
            {
                _itemSaleList = new List<ItemSale>();
            }

            try
            {
                var itemSaleTask = _saleService.PopulateItemSaleProductFromId(id);
                var itemSale = await itemSaleTask;
                itemSale.Quantity = qtd;
                itemSale.Discount = discount;
                itemSale.ProductValue = itemSale.Product.Value;
                _itemSaleList.Add(itemSale);
                return PartialView("_SaleProductGridPV",_itemSaleList);
            }
            catch(Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AlterListItemSale(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            if (_itemSaleList == null)
            {
                _itemSaleList = new List<ItemSale>();
            }

            try
            {
                var item = _itemSaleList.First(x => x.Product.Id == id);
                _itemSaleList.Remove(item);
                return PartialView("_SaleProductGridPV", _itemSaleList);
            }
            catch(Exception ex)
            {
                return Json(ex);
            }
        }
    }
}
