using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Mohammad Adam Butt


namespace TravelExperts_fileVersion_
{
    public class Supplier
    {
        //accessors for supplier object properties
        public int SupplierId { get; set; }
        public string SupName { get; set; }

        //default constructor
        public Supplier()
        {
            SupplierId = -1;
            SupName = null;
        }

        public Supplier(int id, string pn)
        {
            SupplierId = id;
            SupName = pn;
        }

        public Supplier(string pn)
        {
            SupName = pn;
        }

        public override string ToString()
        {
            return SupName;
        }
    }
}

