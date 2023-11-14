using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.IO;


namespace MailRefuerzo
{
    class Program
    {

       
        static void Tetinastres()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(),System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());
            
            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();

            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=1", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------

            SqlCommand cmdmail = new SqlCommand(script,connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
           // SqlDataReader drmail = cmdmail.ExecuteReader();
                   
            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    //Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    // Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR1.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub1"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 1 enviado correctamente a:"+ strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 1 a:"+ strMail);
                    }
                    //dfdfgffgfg

                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            connLocal.Close();
        }

        static void Tetinaseis()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());
           
            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();

            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=2", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------

            SqlCommand cmdmail = new SqlCommand(script,connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
            // SqlDataReader drmail = cmdmail.ExecuteReader();

            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    // Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    //Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR2.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub2"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 2 enviado correctamente a:"+ strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 2 a:"+ strMail);
                    }
                    //dfdfgffgfg
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            connLocal.Close();
        }

        static void Vajilla()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());
           
            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();

            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=3", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------

            SqlCommand cmdmail = new SqlCommand(script,connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
            // SqlDataReader drmail = cmdmail.ExecuteReader();

            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    // Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    //Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR3.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub3"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 3 enviado correctamente a:"+ strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 3 a:"+ strMail);
                    }
                    //dfdfgffgfg
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            connLocal.Close();
        }

        static void Asiento()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());
            
            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();

            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=4", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------

            SqlCommand cmdmail = new SqlCommand(script,connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
            // SqlDataReader drmail = cmdmail.ExecuteReader();

            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    // Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    //Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR4.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub4"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 4 enviado correctamente a:"+strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 4 a:"+ strMail);
                    }
                    //dfdfgffgfg
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            connLocal.Close();
        }

        static void Vaceni()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());
           
            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();

            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=5", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------

            SqlCommand cmdmail = new SqlCommand(script,connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
            // SqlDataReader drmail = cmdmail.ExecuteReader();

            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    //Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    //Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR5.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub5"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 5 enviado correctamente a:"+ strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 5 a:"+ strMail);
                    }
                    //dfdfgffgfg
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            connLocal.Close();
        }

        static void Rodillo()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());
           
            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();

            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=6", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------

            SqlCommand cmdmail = new SqlCommand(script,connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
            // SqlDataReader drmail = cmdmail.ExecuteReader();

            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    //Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    //Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR6.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub6"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 6 enviado correctamente a:"+ strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 6 a:"+ strMail);
                    }
                    //dfdfgffgfg
                }
                catch (Exception ex) { Console.WriteLine(ex); }

            }
            connLocal.Close();
        }

        static void Seguridad()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());
           
            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();

            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=7", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------


            SqlCommand cmdmail = new SqlCommand(script, connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
            // SqlDataReader drmail = cmdmail.ExecuteReader();

            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    // Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    //Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR7.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub7"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 7 enviado correctamente a:"+ strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 7 a:"+ strMail);
                    }
                    //dfdfgffgfg
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            connLocal.Close();
        }

        static void Encuesta()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());
                               
                        
            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();
           
            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=8", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------
            
            SqlCommand cmdmail = new SqlCommand(script, connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
            // SqlDataReader drmail = cmdmail.ExecuteReader();

            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    //Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    //Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR8.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub8"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 8 enviado correctamente a:"+ strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 8 a:"+strMail);
                    }
                    //dfdfgffgfg
                }
                catch (Exception ex) { Console.WriteLine(ex); }

            }
            connLocal.Close();

        }

        static void Esenciales()
        {
            //---------------
            SmtpClient client = new SmtpClient();
            client.Host = System.Configuration.ConfigurationSettings.AppSettings["Host"].ToString();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["NCuser"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["NCPass"].ToString());
            //  --------------

            SqlConnection connLocal = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConexionSQL"].ToString());


            SqlCommand selEmail = new SqlCommand();
            selEmail.Connection = connLocal;
            connLocal.Open();

            //------
            SqlCommand cmdscript = new SqlCommand(@" 
            SELECT  script_mail
            FROM [informes].[dbo].[Mail_Refuerzo]
            where id=9", connLocal);
            SqlDataAdapter adpscript = new SqlDataAdapter(cmdscript);
            DataTable dt = new DataTable();
            adpscript.Fill(dt);
            DataRow drs = dt.Rows[0];
            string script = drs["script_mail"].ToString();
            //----------

            SqlCommand cmdmail = new SqlCommand(script, connLocal);
            DataSet dsmail = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmdmail);
            adp.Fill(dsmail);
            // SqlDataReader drmail = cmdmail.ExecuteReader();


            foreach (DataRow dtr in dsmail.Tables[0].Rows)
            {
                try
                {
                    string strNombre = dtr["NOMBRE_SOCIA"].ToString();
                    //Console.WriteLine(strNombre);
                    string strApellido = dtr["APELLIDO_SOCIA"].ToString();
                    //Console.WriteLine(strApellido);
                    string strMail = dtr["DESCRIPCION_DIRECCION"].ToString();
                    //Console.WriteLine(strMail);

                    //reererer
                    MailAddress FromEmail = new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["MAfrom"].ToString(), System.Configuration.ConfigurationSettings.AppSettings["MAnombre"].ToString());
                    MailAddress ToEmail = new MailAddress(strMail);

                    string gpsc = System.IO.File.ReadAllText(@"C:\HTML\MR9.txt");
                    string dd = strNombre + ' ' + strApellido;
                    string html = gpsc.Replace("{contactfield=firstname}", dd);
                    string htmlBody = html;

                    MailMessage Message = new MailMessage();

                    Message.From = FromEmail;
                    Message.Subject = System.Configuration.ConfigurationSettings.AppSettings["Sub9"].ToString();
                    Message.Body = htmlBody;
                    Message.IsBodyHtml = true;
                    Message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                    Message.To.Add(ToEmail);
                    //Message.Attachments.Add(new Attachment("C:/HTML/AAA.pdf"));
                    try
                    {
                        client.Send(Message);
                        Console.WriteLine("Mail 9 enviado correctamente a:"+ strMail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error de envio 9 a:"+ strMail);
                    }
                    //dfdfgffgfg
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }


            connLocal.Close();

        }

        static void Main(string[] args)
        {

            string Act1 = System.Configuration.ConfigurationSettings.AppSettings["Activo1"].ToString();
            string Act2 = System.Configuration.ConfigurationSettings.AppSettings["Activo2"].ToString();
            string Act3 = System.Configuration.ConfigurationSettings.AppSettings["Activo3"].ToString();
            string Act4 = System.Configuration.ConfigurationSettings.AppSettings["Activo4"].ToString();
            string Act5 = System.Configuration.ConfigurationSettings.AppSettings["Activo5"].ToString();
            string Act6 = System.Configuration.ConfigurationSettings.AppSettings["Activo6"].ToString();
            string Act7 = System.Configuration.ConfigurationSettings.AppSettings["Activo7"].ToString();
            string Act8 = System.Configuration.ConfigurationSettings.AppSettings["Activo8"].ToString();
            string Act9 = System.Configuration.ConfigurationSettings.AppSettings["Activo9"].ToString();

            if (string.Equals(Act1, "S")){ 
              Tetinastres();
            }

            if (string.Equals(Act2, "S"))
            {
               Tetinaseis();
            }
            if (string.Equals(Act3, "S"))
            {
               Vajilla();
            }
            if (string.Equals(Act4, "S"))
            {
               Asiento();
            }
            if (string.Equals(Act5, "S"))
            {
              Vaceni();
            }
            if (string.Equals(Act6, "S"))
            {
                 Rodillo();
            }
            if (string.Equals(Act7, "S"))
            {
              Seguridad();
            }
            if (string.Equals(Act8, "S"))
            {
              Encuesta();
            }
            if (string.Equals(Act9, "S"))
            {
                Esenciales();
            }
        }


    }
}
