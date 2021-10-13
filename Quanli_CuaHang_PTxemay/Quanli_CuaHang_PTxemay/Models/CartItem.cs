using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanli_CuaHang_PTxemay.Models
{
    [Serializable]
    public class CartItem
    {
        public PHUTUNGXE ProductID { get; set; }
        public int Quantity { get; set; }
    }
}