using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Author Name: Harpreet Parmar
 * 
 */

namespace TravelExperts_fileVersion_
{
    public class ProductSupplier
    {
        public int ProductSupplierId { get; set; } //getter and setter for ProductSupplierId       
        public int ProductId { get; set; } //getter and setter for ProductId 
        public int SupplierId { get; set; } //getter and setter for SupplierId 
        public string Deleted { get; set; } //getter and setter for Deleted 

        public ProductSupplier()
        {
            ProductSupplierId = -1;
            ProductId = -1;
            SupplierId = -1;
        }

        public ProductSupplier(int psid, int pid, int sid)
        {
            ProductSupplierId = psid;//ProductSupplierId equal to psid
            ProductId = pid;//ProductId equal to pid
            SupplierId = sid;//SupplierId equal to sid
        }

        public ProductSupplier(int pid, int sid)
        {
            ProductId = pid;//ProductId equal to pid
            SupplierId = sid;//SupplierId equal to sid
        }

        public override string ToString()
        {
            return ProductId.ToString() + "," + SupplierId.ToString();
        }

    }
}
