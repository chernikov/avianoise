using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class FeedbackFileBL : IFeedbackFileBL
    {
        private readonly IFeedbackFileRepository feedbackFileRepository;

        public FeedbackFileBL(IFeedbackFileRepository feedbackFileRepository)
        {
            this.feedbackFileRepository = feedbackFileRepository;
        }


        public FeedbackFile Create(FeedbackFile entry)
        {
            return feedbackFileRepository.Create(entry);
        }

        public List<FeedbackFile> GetList()
        {
            return feedbackFileRepository.Get().ToList();
        }

        public void Clear()
        {
            feedbackFileRepository.Clear();
        }

    }
}
