using Repository_Lab_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Infrastructure.Repositories
{
    public class AuctionRepository
    {
        private AppDbContext _context;

        public AuctionRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
