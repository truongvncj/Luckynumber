using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arconfirmationletter.Model
{
    class L_Gfbl5nnew
    {
        public IQueryable L_Gfbl5nnew_selectall()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tblFBL5Nnew in db.tblFBL5Nnews
                     select tblFBL5Nnew;

            return rs;

        }



    }
}
