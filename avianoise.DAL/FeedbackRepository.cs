using avianoise.Data;
using avianoise.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class FeedbackRepository : BaseRepository, IFeedbackRepository
    {
        public FeedbackRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public Feedback Create(Feedback feedback) =>
            Query(context =>
            {
                var newEntry = new Feedback()
                {
                    AddedDate = DateTime.Now,
                    Email = feedback.Email,
                    Message = feedback.Message,
                    Name = feedback.Name
                };
                context.Feedbacks.Add(newEntry);
                context.SaveChanges();
                foreach (var file in feedback.FeedbackFiles)
                {
                    var savedEntry = context.FeedbackFiles.Find(file.Id);
                    savedEntry.FeedbackId = newEntry.Id;
                }
                context.SaveChanges();
                return newEntry;
            });


        public List<Feedback> GetByPage(int page, int pageSize, out int total)
        {
            total = this.context.Feedbacks.Count();
            if (total % pageSize == 0)
            {
                total = total / pageSize;
            }
            else
            {
                total = total / pageSize + 1;
            }
            return this.context.Feedbacks.OrderByDescending(p => p.AddedDate).Skip(pageSize * page).Take(pageSize)
                .Include(p => p.FeedbackFiles)
                .ToList();
        }

        public void Delete(int id) =>
            Query(context =>
            {
                var entry = context.Feedbacks.Find(id);
                if (entry != null)
                {
                    context.Feedbacks.Remove(entry);
                    context.SaveChanges();
                }
            });

        public void DeleteAll() =>
            Query(context =>
            {
                context.Feedbacks.RemoveRange(context.Feedbacks);
                context.SaveChanges();
            });
    }
}
