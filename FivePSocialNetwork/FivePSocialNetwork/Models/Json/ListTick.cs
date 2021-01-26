using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FivePSocialNetwork.Models.Json
{
    public class ListTick
    {
        public int tickQuestion_id { get; set; }
        public Nullable<int> question_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string tickQuestion_dateCreate { get; set; }
        public Nullable<bool> tickQuestion_recycleBin { get; set; }
        public string question_content { get; set; }
        public string question_title { get; set; }

    }
}