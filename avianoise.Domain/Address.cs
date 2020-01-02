using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Domain
{
	public class Address
	{
		[Key]
		public int Id { get; set; }

		public string SearchLine { get; set; }

		public string AddressJson { get; set; }

		public double Lat { get; set; }

		public double Lng { get; set; }

		public DateTime AddedDate { get; set; }
	}
}
