﻿using Microsoft.AspNetCore.Mvc;
using StudentCalendarAdmin.IServices;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace StudentCalendarAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        public async Task<IActionResult> Index()
        {
            var groups = await _groupService.GetGroupsAsync();
            return View(groups);
        }
        [HttpGet]
        public IActionResult CreateGroup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGroup(Group group)
        {
            if(!await _groupService.CreateGroup(group))
                return RedirectToAction("Error","Home");
            return RedirectToAction("Index");
        }
    }
}
