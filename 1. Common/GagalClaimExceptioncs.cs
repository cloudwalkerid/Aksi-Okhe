using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akhi_Okhee._1._Common
{
    public class GagalClaimExceptioncs : Exception
    {
        /*blok_i Blok_i;*/
        public GagalClaimExceptioncs()
        {

        }

        public GagalClaimExceptioncs(blok_i bloki)
            : base(String.Format("Gagal klaim dokumen usaha: {0} dientri oleh user {1}", bloki.R109.Data, bloki.Lock_user.Data))
        {
            /*Blok_i = bloki;*/
        }
    }
}
