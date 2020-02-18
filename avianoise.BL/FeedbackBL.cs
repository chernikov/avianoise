using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IFeedbackRepository feedbackRepository;

        public FeedbackBL(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }
        public Feedback Create(Feedback entry)
        {
            return feedbackRepository.Create(entry);
        }

        public List<Feedback> GetByPage(int page, int pageSize, out int total)
        {
            return feedbackRepository.GetByPage(page, pageSize, out total);
        }
    }
}
