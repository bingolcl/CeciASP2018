using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Author Name: Harpreet Parmar
 * Date: 15 January.2018
 * Purpose Of Application:Creating user friendy website for travel experts
 */
namespace TravelExperts_fileVersion_
{
    public class PackageProductSupplier
    {
        public int PackageId { get; set; }
        public int ProductSupplierId { get; set; }
        public string PkgName { get; set; }
        public string ProdName { get; set; }
        public string SupName { get; set; }

        public PackageProductSupplier()
        {
            PackageId = -1;
            ProductSupplierId = -1;
            PkgName = "";
            ProdName = "";
            SupName = "";
        }

        public PackageProductSupplier(int id, int psid, string pkn, string pdn, string spn)
        {
            PackageId = id;
            ProductSupplierId = psid;
            PkgName = pkn;
            ProdName = pdn;
            SupName = spn;

        }

        public PackageProductSupplier(string pkn, string pdn, string spn)
        {
            PkgName = pkn;
            ProdName = pdn;
            SupName = spn;

        }

        public override string ToString()
        {
            return PkgName + "\t"
                    + ProdName + "\t"
                    + SupName;
        }
    }
}
