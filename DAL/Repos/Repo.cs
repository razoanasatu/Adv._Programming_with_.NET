using DAL.EF;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Repo
    {
        internal EContext db;
        internal Repo() {
            db = new EContext();
        
        }
    }
}
