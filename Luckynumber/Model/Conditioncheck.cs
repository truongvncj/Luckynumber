using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arconfirmationletter.Model
{
    class Conditioncheck
    {

        public static bool Iswrongmessage(string message , string material)
        {
            #region // kiem tra xem co sai mesage

            string connection_string = Utils.getConnectionstr();

            var db = new LinqtoSQLDataContext(connection_string);

            var rs = from p in db.tbl_CTKMs
                     where p.Mã_SP_KM == material
                     && message.IndexOf(p.PO_Message) > 0
                     select p;

            if (rs.Count()>0)
            {
                return true;
            }

            // s1.IndexOf(s2)
            // / string.Compare



            return false;
            #endregion

        }


    }
}
