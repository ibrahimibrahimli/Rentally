using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Position : BaseEntity
    {
        public Position()
        {
            TeamBoards = new HashSet<TeamBoard>();
        }
        public string Name { get; set; }
        public ICollection<TeamBoard> TeamBoards { get; set; }
    }
}
