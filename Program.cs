﻿using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("From test mail",
            "info@raovatvietmy.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Tuan Tran",
            "tuantrankim@gmail.com");
            message.To.Add(to);

            message.Subject = "Testing email from tuan";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
            bodyBuilder.TextBody = "Hello World!";
            
            //bodyBuilder.Attachments.Add(env.WebRootPath + "\\file.png");

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("email-smtp.us-west-2.amazonaws.com", 465, true);

            //Update username and password to run testing
            client.Authenticate("username", "password");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            
            Console.WriteLine("Done.");
        }
    }
}
