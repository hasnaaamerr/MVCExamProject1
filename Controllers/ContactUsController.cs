﻿using Microsoft.AspNetCore.Mvc;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;

namespace MVCExamProject.Controllers
{
	public class ContactUsController : Controller
	{
		private IContactUsRepository contactUsRepository;

		public ContactUsController(IContactUsRepository contactUsRepo)
		{
			contactUsRepository
				 = contactUsRepo;
		}

		public IActionResult Index()

		{
			return View("~/Views/ContactUs/ContactUs.cshtml");
		}

		//////////////////// Saving Submit
		[HttpPost]
		public IActionResult Index(ContactUs contact)
		{
			if (ModelState.IsValid == true)
			{
				contactUsRepository.Insert(contact);
			return View("~/Views/Home/Index.cshtml");
			}
			return View("~/Views/ContactUs/ContactUs.cshtml", contact);
		}

	}

}
