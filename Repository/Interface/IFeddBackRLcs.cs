using ModelLayer.FeedBackModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IFeddBackRLcs
    {
        public FeedBackModelcs AddFeedBack(FeedBackModelcs feedbackModel);
        public object UpdateFeedback(UpdateFeed feed);
        public object DeleteFeedBack(int FEEDBACKID);
        public object GetAll();
        
    }
}
