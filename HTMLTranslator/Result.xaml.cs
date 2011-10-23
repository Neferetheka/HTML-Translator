using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;

namespace HTMLTranslator
{
    public partial class Result : PhoneApplicationPage
    {
        public Result()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (IsolatedStorageSettings.ApplicationSettings["texte"] != null)
            {
                if (IsolatedStorageSettings.ApplicationSettings["index"].ToString() == "1")
                    TranslationLabel.Text = TextToHTML(IsolatedStorageSettings.ApplicationSettings["texte"].ToString());
                else
                    TranslationLabel.Text = HTMLTotext(IsolatedStorageSettings.ApplicationSettings["texte"].ToString());
            }
        }

        public string TextToHTML(string texte)
        {
            if (texte != null)
            {
                texte = texte.Replace("é", "&eacute;");
                texte = texte.Replace("è", "&egrave;");
                texte = texte.Replace("ê", "&ecirc;");

                texte = texte.Replace("à", "&agrave;");
                texte = texte.Replace("â", "&acirc;");

                texte = texte.Replace("î", "&icirc;");
                texte = texte.Replace("ô", "&ocirc;");
                texte = texte.Replace("û", "&ucirc;");
                texte = texte.Replace("ù", "&ugrave;");
                texte = texte.Replace("ç", "&ccedil;");
            }
            return texte;
        }

        public string HTMLTotext(string texte)
        {
            if (texte != null)
            {
                texte = texte.Replace("&eacute;", "é");
                texte = texte.Replace("&egrave;", "è");
                texte = texte.Replace("&ecirc;", "ê");

                texte = texte.Replace("&agrave;", "à");
                texte = texte.Replace("&acirc;", "â");

                texte = texte.Replace("&icirc;", "î");
                texte = texte.Replace("&ocirc;", "ô");
                texte = texte.Replace("&ucirc;", "û");
                texte = texte.Replace("&ugrave;", "ù");
                texte = texte.Replace("&ccedil;", "ç");
            }

            return texte;
        }

        private void AppBarBack(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AppBarAPropos(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/APropos.xaml", UriKind.Relative));
        }

        private void AppBarMail(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Body = TranslationLabel.Text + Environment.NewLine + Environment.NewLine + "Transformé par HTML Translator";
            emailComposeTask.Subject = "HTML Translation";
            emailComposeTask.Show();

        }

        private void AppBarSMS(object sender, EventArgs e)
        {
            SmsComposeTask smsComposeTask = new SmsComposeTask();
            smsComposeTask.Body = TranslationLabel.Text + Environment.NewLine + Environment.NewLine + "Transformé par HTML Translator";
            smsComposeTask.Show();
        }

        private void AppBarShare(object sender, EventArgs e)
        {
            ShareStatusTask status = new ShareStatusTask();
            status.Status = TranslationLabel.Text + Environment.NewLine + Environment.NewLine + "Transformé par HTML Translator";
            status.Show();
        }
    }
}