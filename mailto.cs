using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using UnityEngine.UI;

public class mailto : MonoBehaviour {

    public InputField mainInputField;
    public Button validationButton;

    public void Start() {
        mainInputField.placeholder.GetComponent<Text>().text = "Entrez votre email ici"; // Input placeholder text
        validationButton.onClick.AddListener(email_send);
    }

   private void Update() {

    }

    private void email_send() {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("yourmail@gmail.com"); // can only use gmail
        mail.To.Add(mainInputField.text);
        mail.Subject = "Mail - 1";
        mail.Body = "mail with attachment";

        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(@"C:\Pictures\img.png"); // Image or whatever you want to attach
        mail.Attachments.Add(attachment);

        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("yourmail@gmail.com", "yourpasswordhere"); // Your gmail credentials. email should be same as the mail.From email
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
        Debug.Log("email sent");
    }
}
