using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HMS.Library.DAL
{
	public class DbContextFactory : IDesignTimeDbContextFactory<HMSdb>
	{
		public HMSdb CreateDbContext(string[] args)
		{
			var optionBuilder = new DbContextOptionsBuilder();
			optionBuilder.UseSqlServer("");
			return new HMSdb(optionBuilder.Options);
		}
	}
}
