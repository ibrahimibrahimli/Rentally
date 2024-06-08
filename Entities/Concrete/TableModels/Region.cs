using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }
        public string PostalCode { get; set; }
    }
}
