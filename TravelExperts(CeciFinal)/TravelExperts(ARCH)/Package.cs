using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Travel Experts
 * Date: Jan 22, 2017
 * Author: Cecilia Zhang
 * Purpose: Define package class.
 */

namespace TravelExperts_fileVersion_
{
    public class Package : ICloneable // implements interface for clone
    {
        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime? PkgStartDate { get; set; }
        public DateTime? PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public decimal? PkgAgencyCommission { get; set; }

        public Package()
        {
            PackageId = -1;
            PkgName = "";
            PkgDesc = "";
            PkgBasePrice = 0;
            PkgAgencyCommission = 0;
        }

        public Package(int id, string pn, DateTime? sd, DateTime? ed, string pd, decimal pb, decimal? pc)
        {
            PackageId = id;
            PkgName = pn;
            PkgStartDate = sd;
            PkgEndDate = ed;
            PkgDesc = pd;
            PkgBasePrice = pb;
            PkgAgencyCommission = pc;
        }

        public Package(string pn, DateTime? sd, DateTime? ed, string pd, decimal pb, decimal? pc)
        {
            PackageId = -1;
            PkgName = pn;
            PkgStartDate = sd;
            PkgEndDate = ed;
            PkgDesc = pd;
            PkgBasePrice = pb;
            PkgAgencyCommission = pc;
        }

        public override string ToString()
        {
            return PkgName + "\t"
                    + PkgStartDate + "\t"
                    + PkgEndDate + "\t"
                    + PkgDesc + "\t"
                    + PkgBasePrice.ToString("c") + "\t"
                    + (PkgAgencyCommission.HasValue ? PkgAgencyCommission.Value.ToString("c") : string.Empty); 
        }

        public object Clone()
        {
            return new Package(this.PackageId, this.PkgName, this.PkgStartDate, this.PkgEndDate, this.PkgDesc, this.PkgBasePrice, this.PkgAgencyCommission);
        }
    }
}

