using System;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudioPlaza.Web.Templates.Items;
using StudioPlaza.Web.Templates.Web.UI;
using StudioPlaza.Web.Templates.Web.UI.WebControls;
using N2.Web.UI.WebControls;
using N2.Web.Mail;
using N2;

namespace StudioPlaza.Web.Templates.UI.Parts
{
	public partial class Form : TemplateUserControl<ContentItem, Items.Form>
    {
        protected MultiView mv;
        protected Zone zq;

        protected void btnSubmit_Command(object sender, CommandEventArgs args)
        {
			Page.Validate("Form");
			if (!Page.IsValid)
				return;
			
            StringBuilder sb = new StringBuilder(CurrentItem.MailBody);
            foreach (Control c in zq.Controls)
            {
                IQuestionControl q = c as IQuestionControl;
                if (q != null)
                {
                    sb.AppendFormat("{0}: {1}{2}", q.Question, q.AnswerText, Environment.NewLine);
                }
            }
            MailMessage mm = new MailMessage(CurrentItem.MailFrom, CurrentItem.MailTo);
            mm.Subject = CurrentItem.MailSubject;
            mm.Body = sb.ToString();

            Engine.Resolve<IMailSender>().Send(mm);

            mv.ActiveViewIndex = 1;
        }
    }
}