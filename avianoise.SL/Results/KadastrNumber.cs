using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL.Results
{
    public class KadastrNumber
    {
        public long Koatuu { get; set; }

        public int Zone { get; set; }

        public int Kvartal { get; set; }

        public int Parcel { get; set; }

        public override string ToString()
        {
            return $"{Koatuu:d10}:{Zone:d2}:{Kvartal:d3}:{Parcel:d4}";
        }

        public static KadastrNumber Parse(string wholeNumber)
        {
            var parts = wholeNumber.Split(":");
            return new KadastrNumber()
            {
                Koatuu = long.Parse(parts[0]),
                Zone = int.Parse(parts[1]),
                Kvartal = int.Parse(parts[2]),
                Parcel = int.Parse(parts[3]),
            };
        }

        public static bool TryParse(string wholeNumber, out KadastrNumber number)
        {
            var parts = wholeNumber.Split(":");
            try
            {
                number = new KadastrNumber()
                {
                    Koatuu = long.Parse(parts[0]),
                    Zone = int.Parse(parts[1]),
                    Kvartal = int.Parse(parts[2]),
                    Parcel = int.Parse(parts[3]),
                };
                return true;
            }
            catch
            {
                number = null;
                return false;
            }
        }
    }
}
