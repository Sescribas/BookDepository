using BookDepository.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDepository.DB.Repository
{
	public class ApplicationDbContext1 : DbContext
	{

		public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> options) : base(options) 
		{

		}

		public DbSet<Category> Categories { get; set; }
	}
}
