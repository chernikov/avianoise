using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
	public class AddressDto
	{
		public int Id { get; set; }

		public string SearchLine { get; set; }

		public string AddressJson { get; set; }

		public double Lat { get; set; }

		public double Lng { get; set; }

		public DateTime AddedDate { get; set; }
	}
}
