using System;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// GeneralUtil.GeneralUtilTelegram.TelegramSendMessage
/// </summary>
namespace GeneralUtil
{
    public class GeneralUtilTelegram
    {

        public static string BOT_general_TOKEN = "2013048369:AAEulT49ssvnPnTEywXR2xWnB4hwAdI486A";
        public static string CHANNEL_general = "@Tasawuq";
        /*    public static string TelegramSendMessage(  string text)
            {
                try
                {
                    string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                    string apiToken = "2013048369:AAEulT49ssvnPnTEywXR2xWnB4hwAdI486A";
                     string chatId = "@Tasawuq";//working best
                  //  string chatId = "@tasawuqjed";
                    // string text = "https://www.tasawuq.org مرحباَّworld!"; 
                    urlString = String.Format(urlString, apiToken, chatId, text);
                    WebRequest request = WebRequest.Create(urlString);
                    Stream rs = request.GetResponse().GetResponseStream();
                    StreamReader reader = new StreamReader(rs); string line = "";
                    StringBuilder sb = new StringBuilder();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                            sb.Append(line);
                    }
                    string response = sb.ToString();
                    return response;
                    // Do what you want with response

                }
                catch (Exception)
                {
                    return "error";
                }
            }
    */

        /// <summary>
        /// send to channel
        /// </summary>
        /// <param name="text"></param>
        /// <param name="chatId"></param>
        /// <returns></returns>
        /*public static string TelegramSendMessage__NotUsed(  string text , string channelID)
        {
            try
            {
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "2013048369:AAEulT49ssvnPnTEywXR2xWnB4hwAdI486A";
                channelID = "@"+ channelID; //TasawuqTest
                urlString = String.Format(urlString, apiToken, channelID, text);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs); string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
                string response = sb.ToString();
                return response;
                // Do what you want with response

            }
            catch (Exception)
            {
                return "error";
            }
        }
*/



        public static string BOT_jeddah_TOKEN = "2013048369:AAEulT49ssvnPnTEywXR2xWnB4hwAdI486A";
        public static string CHANNEL_jeddah = "@tasawuqjed";

        public static string TelegramSendMessageJeddahBot(string text)
        {
            try
            {
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                urlString = String.Format(urlString, BOT_jeddah_TOKEN, CHANNEL_jeddah, text);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs); string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
                string response = sb.ToString();
                return response;
                // Do what you want with response
            }
            catch (Exception)
            {
                return "error";
            }
        }



        public static string BOT_SenderPbitest_bot_SenderTestBot_TOKEN = "5784372571:AAHsg9AQKTj8xDEImGeLG5S5sHh9aQpCxXk";
        public static string CHANNEL_مجتمعpowerbi_arpbitk = "@arpbitk";

        public static bool telegramTesting = true;
        public static string TelegramSendMessage_Any(string channel, string botToken, string message_text)
        {
            try
            {
                if (telegramTesting)
                {
                    botToken = BOT_SenderPbitest_bot_SenderTestBot_TOKEN;
                    channel = CHANNEL_مجتمعpowerbi_arpbitk;
                }
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                ///string apiToken = botToken;// "5784372571:AAHsg9AQKTj8xDEImGeLG5S5sHh9aQpCxXk";
                //string chatId = channel;// "@arpbitk";
                urlString = String.Format(urlString, botToken, channel, message_text);

                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs); string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
                string response = sb.ToString();
                return response;
                // Do what you want with response

            }
            catch (Exception)
            {
                return "error";
            }
        }






        /* 
         * 
         * jeddah bot not used
         Done! Congratulations on your new bot.
        You will find it at t.me/TasawuqJeddah_bot. You can now add a description, about section and profile picture for your bot, see /help for a list of commands. By the way, when you've finished creating your cool bot, ping our Bot Support if you want a better username for it. Just make sure the bot is fully operational before you do this.
Use this token to access the HTTP API:
2116922693:AAF56lhtZ5iO5zNHrFcV5ayK7QsM5qKRfBA
Keep your token secure and store it safely, it can be used by anyone to control your bot.

For a description of the Bot API, see this page: https://core.telegram.org/bots/api
         
         */

    }
}
