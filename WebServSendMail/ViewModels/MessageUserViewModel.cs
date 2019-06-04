using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServSendMail.ViewModels
{
    public class MessageUserViewModel
    {
        public int Id { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string ReceiverEmail { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class MessageMailViewModel
    {
        public string ReceiverEmail { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}