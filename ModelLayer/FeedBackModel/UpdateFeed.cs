﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.FeedBackModel
{
    public class UpdateFeed
    {
        public int FEEDBACKID { get; set; }
        public int BOOKID { get; set; }
        public int USERID { get; set; }
        public string FULLNAME { get; set; }
        public int RATING { get; set; }
        public string REVIEW { get; set; }
    }
}
