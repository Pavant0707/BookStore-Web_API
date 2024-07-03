using Bussiness.IuserBL;
using ModelLayer.FeedBackModel;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.USERbl
{
    public class FeedBackBL : IFeedBackBL
    {
        private readonly IFeddBackRLcs feedBackRL;

        public FeedBackBL(IFeddBackRLcs feedBackRL)
        {
            this.feedBackRL = feedBackRL;
        }

        public FeedBackModelcs AddFeedBack(FeedBackModelcs feedbackModel)
        {
          return feedBackRL.AddFeedBack(feedbackModel);
        }

        public object DeleteFeedBack(int FEEDBACKID)
        {
            return feedBackRL.DeleteFeedBack(FEEDBACKID);
        }

        public object GetAll()
        {
            return feedBackRL.GetAll();
        }

        public object UpdateFeedback(UpdateFeed model)
        {
            return feedBackRL.UpdateFeedback(model);
        }
    }
}
