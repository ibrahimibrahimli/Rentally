using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class QuestionAnswerCreateDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public static QA ToFeature(QuestionAnswerDto dto)
        {
            QA questionAnswer = new QA()
            {
                Question = dto.Question,
                Answer = dto.Answer,
            };

            return questionAnswer;
        }
    }
}
