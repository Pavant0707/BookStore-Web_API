using ModelLayer.FeedBackModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IuserBL
{
    public interface IFeedBackBL
    {
        public FeedBackModelcs AddFeedBack(FeedBackModelcs feedbackModel);
        public object UpdateFeedback(UpdateFeed model);
        public object DeleteFeedBack(int FEEDBACKID);
        public object GetAll();
    }
}
