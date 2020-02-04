using avianoise.SL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL
{
    public interface IKadastrMapSL : IBaseSL
    {
        KadastrNumber GetNumberByXyz(double x, double y, int zoom);

        KadastrNumber GetNumberByLatLng(double lat, double lng);

        KadastrInfo GetInfoByNumber(KadastrNumber number);

        XyArea GetAreaByNumber(KadastrNumber number);
    }
}
