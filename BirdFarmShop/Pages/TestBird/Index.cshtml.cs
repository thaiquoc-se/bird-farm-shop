using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepository;
using Repositories.Repository;

namespace BirdFarmShop.Pages.TestBird
{
    public class IndexModel : PageModel
    {
        private readonly IBirdRepository _birdRepository;

        public IndexModel(IBirdRepository birdRepository)
        {
           _birdRepository = birdRepository;
        }

        public IList<Bird> Bird { get;set; } = default!;

        public void OnGet()
        {
            Bird = _birdRepository.GetAllBirds();    
        }
    }
}
