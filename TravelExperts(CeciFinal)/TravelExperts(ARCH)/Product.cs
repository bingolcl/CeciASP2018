using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Author Riley Hobberstad

namespace TravelExperts_fileVersion_
{//get and set the variables for products
    public class Product
    {
        public int ProductId { get; set; }
        public string ProdName { get; set; }


        public Product()
        {
            ProductId = -1;
            ProdName = null;
        }

        public Product(int id, string pn)
        {
            ProductId = id;
            ProdName = pn;
        }

        public Product(string pn)
        {
            ProdName = pn;
        }

        public override string ToString()
        {
            return ProdName;
        }

    }
}
