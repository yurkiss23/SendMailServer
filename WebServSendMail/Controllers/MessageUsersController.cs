using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using WebServSendMail.Models;
using WebServSendMail.ViewModels;

namespace WebServSendMail.Controllers
{
    public class MessageUsersController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MessageUsersController()
        {
            _context = new ApplicationDbContext();
        }

        public List<MessageUserViewModel> Get()
        {
            var model = _context.SendMailMessages.Select(m => new MessageUserViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Body = m.Body,
                ReceiverEmail = m.ReceiverEmail,
                SenderEmail = m.SenderEmail,
                SenderName = m.SenderName
            }).ToList();
            return model;
        }

        public IHttpActionResult Post(MessageMailViewModel model)
        {
            MailMessage mail = new MailMessage("proba.edu.tmp@gmail.com", model.ReceiverEmail);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("proba.edu.tmp@gmail.com", "321ewq654");
            client.Host = "smtp.gmail.com";
            mail.Subject = model.Title;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;
            client.Send(mail);

            _context.SendMailMessages.Add(new DAL.Entities.SendMailMessages
            {
                SenderEmail = mail.From.ToString(),
                SenderName = mail.From.ToString().Split('@')[0],
                ReceiverEmail = model.ReceiverEmail,
                Title = model.Title,
                Body = model.Body
            });
            _context.SaveChanges();

            return Ok();
        }
    }
}
