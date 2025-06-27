using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailCliente, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From =new MailAddress("programationiii@gmail.com");
            email.To.Add("rferrer42@gmail.com");
            email.Subject = asunto;
            email.Body =$"Correo del cliente{emailCliente}\n\n{cuerpo}";
            email.ReplyToList.Add(emailCliente);
        }

        public void enviarEmail()
        {
            server.Send(email);
        }
    }
}