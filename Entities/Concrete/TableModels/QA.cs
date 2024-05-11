using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class QA : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }

}
