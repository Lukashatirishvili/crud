﻿using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    public class ItemsController : Controller
    {
        private readonly CrudContext _context;

        public ItemsController(CrudContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _context.Items.ToListAsync();


            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Name", "Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }
    }
}
