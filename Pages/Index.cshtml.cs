using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFDemo.Data;
using EFDemo.Models;
using EFDemo.Services;
using ContosoUniversity;
using EFDemo.Interfaces;
using EFDemo.ViewModels.Person;

namespace EFDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IPersonService _personService;
        public ListPersonForListVM Records { get; set; }

        public IndexModel(IConfiguration configuration, IPersonService personService)
        {
            _configuration = configuration;
            _personService = personService;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Person> Person { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            Records = _personService.GetPeopleForList();
            /*
            switch (sortOrder)
            {
                case "Date":
                    Records = Records.OrderBy(s => s.Created).ToList();
                    break;
                case "date_desc":
                    people = people.OrderByDescending(s => s.Created).ToList();
                    break;
                default:
                    people = people.OrderByDescending(s => s.Created).ToList();
                    break;
            }

            var peopleQueryable = people.AsQueryable();
            var pageSize = _configuration.GetValue<int>("PageSize", 4);
            Person = await PaginatedList<Person>.CreateAsync(people, pageIndex ?? 1, pageSize);
            */
        }
    }
}
