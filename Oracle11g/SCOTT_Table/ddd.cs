using Oracle.ManagedDataAccess.Client;
using Oracle11g.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle11g.Table
{
    class ORDER_ITEMS : DataService<ORDER_ITEMS>
    {
        public string ORDER_ID { get; set; }
        public string LINE_ITEM_ID { get; set; }
        public string PRODUCT_ID { get; set; }
        public string UNIT_PRICE { get; set; }
        public string QUANTITY { get; set; }

        public ORDER_ITEMS(string ORDER_ID
, string LINE_ITEM_ID
, string PRODUCT_ID
, string UNIT_PRICE
, string QUANTITY
)
        {
            this.ORDER_ID = ORDER_ID;
            this.LINE_ITEM_ID = LINE_ITEM_ID;
            this.PRODUCT_ID = PRODUCT_ID;
            this.UNIT_PRICE = UNIT_PRICE;
            this.QUANTITY = QUANTITY;
        }
        public ORDER_ITEMS(string[] splitresult)
        {
            this.ORDER_ID = splitresult[0];
            this.LINE_ITEM_ID = splitresult[1];
            this.PRODUCT_ID = splitresult[2];
            this.UNIT_PRICE = splitresult[3];
            this.QUANTITY = splitresult[4];
        }
        public void clear()
        {
            this.ORDER_ID = null;
            this.LINE_ITEM_ID = null;
            this.PRODUCT_ID = null;
            this.UNIT_PRICE = null;
            this.QUANTITY = null;
        }

    }
}
