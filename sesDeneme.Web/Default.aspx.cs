using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Timers;
using System.IO;


namespace sesDeneme.Web
{
    public partial class Default : System.Web.UI.Page
    {

        #region Degiskenler
        static SpeechRecognitionEngine recKay = new SpeechRecognitionEngine();
        static SpeechSynthesizer ss = new SpeechSynthesizer();
        static bool devam = true, kontrol = true;
        static int say = 0 , sayac = 0;
        static SesProjeDbEntities sesContext = new SesProjeDbEntities();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void StartRecognition()
        {
            // imgdeneme.ImageUrl = "images/Listen.gif";
            recKay.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(RecKay_SpeechRecognized);
            //recKay.SetInputToDefaultAudioDevice();
            recKay.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recKay_SpeechDetected);
            recKay.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(recKay_SpeechRecognitionRejected);
            recKay.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(recKay_RecognizeCompleted);
            //recKay.InitialSilenceTimeout += new EventHandler<RecognizeCompletedEventArgs>(RecKay_InitialSilenceTimeout);
            // recognizer.SetInputToDefaultAudioDevice() Bu metotun bir Thread içinde çalıştırılması gerekmektedir!
            // Ses tanıma işlemini başlatıyoruz.
            Thread t1 = new Thread(delegate ()
            {
                try
                {
                    recKay.SetInputToDefaultAudioDevice();
                }
                catch (Exception)
                {

                    throw;
                }
                recKay.RecognizeAsync(RecognizeMode.Multiple);
            });
            t1.Start();
        }

        public static void LoadGrammer()
        {

            Choices cmd = new Choices();
            //string[] tercihler = { "merhaba", "ismimi yaz", "ismin nedir", "stop" , "what time is it",  "what day is it", "whats the date" , "whats todays date" , "run google" };
            var tercihler2 = sesContext.Commands.Select(s => s.command1).ToList();
            string[] tercihler = new string[tercihler2.Count()];
            int i = 0;
            foreach (var item in tercihler2)
            {
                tercihler[i] = item;
                i++;
            }
            cmd.Add(tercihler);
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(cmd);
            Grammar grammer = new Grammar(gbuilder);

            recKay.LoadGrammarAsync(grammer);
        }
        private void recKay_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            //imgdeneme.ImageUrl = "images/Listen.gif";
            // txtbxgelen.Text = "Ses Tanınıyor";
        }

        private void recKay_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            // txtbxgelen.Text = "Ses Tanıma İşlemi Başarısız.";
            imgdeneme.ImageUrl = "images/problem.gif";
        }
        private void recKay_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            // imgdeneme.ImageUrl = "images/Process.gif";
            // recKay.RecognizeAsync();
        }
        private void RecKay_InitialSilenceTimeout(object sender, RecognizeCompletedEventArgs e)
        {
            ss.Speak("Time Out");
            recKay.RecognizeAsync();
        }
     
        public static void RecKay_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //Image1.ImageUrl = "images/Listen.gif";
           // imgdeneme.ImageUrl = "images/Listen.gif"; ;
            if (e.Result.Text == "Started")
            {
                devam = true;
                kontrol = true;
            }
            if (devam)
            {
                List<Command> commandList = sesContext.Commands.ToList();
                int sayac = 0;
                
                while (kontrol)
                {
                    if (sayac > commandList.Count - 1)
                    {
                        sayac = 0;
                        kontrol = false;
                    }
                    else
                    {
                        if (e.Result.Text == commandList[sayac].command1.ToString())
                        {

                            //ss.Resume();
                            if (commandList[sayac].command1 == "stop")
                            {
                                //recKay.RecognizeAsyncStop();
                                ss.Speak("I stopped");
                                devam = false;
                                kontrol = false;
                                say = 0;
                                break;
                            }
                            else
                            {
                                if (commandList[sayac].speak == true)
                                {
                                    
                                   // imgdeneme.ImageUrl = "images/Listen.gif";
                                    ss.Speak(commandList[sayac].response);
                                }
                                if (commandList[sayac].action != "NULL")
                                {
                                    System.Diagnostics.Process.Start(commandList[sayac].action);
                                }

                            }

                            break;
                        }
                    }

                 
                    sayac++;
                }

            }


            #region case methods
            //if (devam)
            //{
            //    switch (e.Result.Text)
            //    {
            //        case "merhaba":
            //            ss.Speak("seni seviyorum ");
            //            devam = false;
            //            break;
            //        case "ismimi yaz":
            //            txtbxgelen.Text += "\n goktug";
            //            ss.Speak("Hoş geldin goktug");
            //            devam = false;
            //            break;
            //        case "ismin nedir":
            //            txtbxgelen.Text += "\n Benim ismim JACK";
            //            devam = false;
            //            break;
            //        case "stop":
            //            recKay.RecognizeAsyncStop();
            //            devam = false;
            //            break;
            //        case "run google":
            //            System.Diagnostics.Process.Start("https://www.google.com/");

            //            break;
            //        case "what time is it":
            //            DateTime now = DateTime.Now;
            //            string time = now.GetDateTimeFormats('t')[0];
            //            ss.Speak(time);
            //            break;
            //        case "what day is it":
            //            ss.Speak(DateTime.Today.ToString("dddd"));
            //            break;
            //        case "whats the date":
            //        case "whats todays date":
            //            ss.Speak(DateTime.Today.ToString("dd-MM-yyyy"));
            //            break;
            //    }
            //}
            #endregion


        }


        protected void btnSesAc_Click(object sender, EventArgs e)
        {
            if (say == 0)
            {
                ss.Resume();
                LoadGrammer();
                StartRecognition();
                kontrol = true;
                devam = true;
                imgdeneme.ImageUrl = "images/Listen.gif";
                say++;
            }
            //recKay.UnloadAllGrammars();
            //if (say == 0)
            //{
            //    StartRecognition();
            //    say++;
            //}
            //ss.Speak(txtbxOku.Text);
            // recKay.RecognizeAsync(RecognizeMode.Multiple);
            //recKay.Recognize(RecognizeMode.Single);
            // btnSesKapa.Visible = true;
            // Response.Redirect("/");
        }

        protected void btnYonlendir_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
            recKay.RecognizeAsyncStop();
        }

        protected void btnSesKapa_Click(object sender, EventArgs e)
        {
            say = 0;
            imgdeneme.ImageUrl = "images/Process.gif";
            devam = false;
            recKay.RecognizeAsyncStop();
            ss.Pause();
            // Response.Redirect("~/Default.aspx");
            // btnSesKapa.Visible = false;
        }


    }
}