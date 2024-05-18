using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class QuestionAnswerDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

            public static QA ToFeature(QuestionAnswerDto dto)
            {
                QA questionAnswer = new QA()
                {
                    Id = dto.Id,
                    Question = dto.Question,
                    Answer = dto.Answer,
                };

                return questionAnswer;
            }
        
    }
}
