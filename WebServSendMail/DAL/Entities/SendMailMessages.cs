using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServSendMail.DAL.Entities
{
    [Table("WSSM_SendMail")]
    public class SendMailMessages
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string SenderEmail { get; set; }
        [Required, StringLength(255)]
        public string SenderName { get; set; }
        [Required, StringLength(255)]
        public string ReceiverEmail { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
        [Required, StringLength(4000)]
        public string Body { get; set; }
    }
}