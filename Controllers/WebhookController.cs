using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using BotfolioChatBotSDK;

namespace ExampleChatBot.Controllers
{
    public class WebhookController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="locationMessage"></param>
        /// <param name="imageMessage"></param>
        /// <param name="videoMessage"></param>
        /// <param name="voiceMessage"></param>
        /// <param name="postbackMessage"></param>
        /// <returns></returns>
        /// 
        [Route("webhook/example_chatbot")]
        public async Task MessageReceived(BotfolioChatBotSDK.Webhook.TextMessage textMessage, BotfolioChatBotSDK.Webhook.LocationMessage locationMessage, BotfolioChatBotSDK.Webhook.ImageMessage imageMessage, BotfolioChatBotSDK.Webhook.VideoMessage videoMessage, BotfolioChatBotSDK.Webhook.VoiceMessage voiceMessage, BotfolioChatBotSDK.Webhook.PostBackMessage postbackMessage)
        {
            ///Get your botApiToken from developers.botfol.io
            var chatBotService = new ChatService("YOUR_CHAT_BOT_API_TOKEN");

            switch (textMessage.message_type)
            {
                case "text":
                    {
                        switch (textMessage.attachment.text.ToLower())
                        {
                            case "image":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.ImageMessage() { content_type ="image/png", url = "http://botfol.io/Content/images/logo.png", user_id = textMessage.user_id });
                                    break;
                                }
                            case "video":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.VideoMessage()
                                    {
                                        thumb_url = "http://s2.dmcdn.net/dsXeX.jpg",
                                        content_type = "video/mp4",
                                        url = "http://proxy-099.dc3.dailymotion.com/sec(b646daba73e2078a3987a9064185c3e3)/frag(4)/video/635/028/301820536_mp4_h264_aac_hq_1.ts",
                                        user_id = videoMessage.user_id
                                    });
                                    break;
                                }
                            case "voice":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.VoiceMessage() { content_type = "audio/wav", url = "http://www.wavsource.com/snds_2016-06-26_4317323406379653/people/comedians/allen_arrogh.wav", user_id = textMessage.user_id });
                                    break;
                                }
                            case "contact":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.ContactMessage() { first_name = "Burhan", last_name = "Çetinkaya", phone_number = "+14158005959", user_id = textMessage.user_id });
                                    break;
                                }
                            case "location":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.LocationMessage() { latitude = 37.773972F, longitude = -122.431297F, title = "Facebook HQ", address = "1 Hacker WayMenlo Park, California", user_id = textMessage.user_id });
                                    break;
                                }
                            case "document":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.DocumentMessage() { url = "http://www.pdf995.com/samples/pdf.pdf", content_type = "application/pdf", title = "Sample pdf",  user_id = textMessage.user_id });
                                    break;
                                }
                            case "buttonlist":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.ButtonListMessage()
                                    {
                                        text = "Did you like botfolio?",
                                        buttons = new List<BotfolioChatBotSDK.Parameters.PayloadButton> {
                                            new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "postback",   title = "Yes!", payload = "I love you." },
                                            new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "postback", title = "So so", payload = "Thanks." },
                                            new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "postback", title = "Nope!!", payload = "Ok, i see..." }
                                        },
                                        user_id = textMessage.user_id
                                    });

                                    break;
                                }
                            case "password":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me your password", required_input_type =  BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.password , user_id = textMessage.user_id });
                                    break;
                                }
                            case "number":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a number", required_input_type =  BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.number , user_id = textMessage.user_id });
                                    break;
                                }
                            case "tel":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a tel number", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.tel, user_id = textMessage.user_id });
                                    break;
                                }
                            case "email":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me an email", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.email, user_id = textMessage.user_id });
                                    break;
                                }
                            case "decimal":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a decimal number", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.@decimal, user_id = textMessage.user_id });
                                    break;
                                }
                            case "date":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a date", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.date, user_id = textMessage.user_id });
                                    break;
                                }
                            case "datetime":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a date time", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.datetime, user_id = textMessage.user_id });
                                    break;
                                }
                            case "time":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a time", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.time, user_id = textMessage.user_id });
                                    break;
                                }
                            case "send photo":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a photo", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.photo, user_id = textMessage.user_id });
                                    break;
                                }
                            case "send video":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a video", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.video, user_id = textMessage.user_id });
                                    break;
                                }
                            case "send location":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "Send me a location", required_input_type = BotfolioChatBotSDK.Parameters.BotMessage.RequiredInputTypes.location, user_id = textMessage.user_id });
                                    break;
                                }
                            case "quickreply":
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage()
                                    {
                                        user_id = textMessage.user_id,
                                        text = "How may i help you?",
                                        quick_replies = new List<BotfolioChatBotSDK.Parameters.MessageQuickReply>
                                        {
                                            new BotfolioChatBotSDK.Parameters.MessageQuickReply() { title = "Find a product", payload = "FIND_PRODUCT" },
                                            new BotfolioChatBotSDK.Parameters.MessageQuickReply() { title = "Buy a product", payload = "BUY_PRODUCT_1467476" }
                                        }
                                    });
                                    break;
                                }
                            case "generic":
                                {


                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.GenericMessage()
                                    {

                                        user_id = textMessage.user_id,
                                        elements = new List<BotfolioChatBotSDK.Parameters.GenericMessageElement>() {

                                              new BotfolioChatBotSDK.Parameters.GenericMessageElement {
                                                    title     = "Black Rivet Mens Hooded Chevron Puffy",
                                                    sub_title = "US $37.50",
                                                    image_url = "http://mc2-ii.aws.marketlive.com/fcgi-bin/iipsrv.fcgi?FIF=/images/wilsonsleather//source/BK6AN843_bk6an843c98af.tif&wid=1000&cvt=jpeg",
                                                    buttons   =    new List<BotfolioChatBotSDK.Parameters.PayloadButton> {
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "web_url",   title = "Buy", url = "http://www.ebay.com/itm/Black-Rivet-Mens-Hooded-Chevron-Puffy-/272410931908" },
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "phone_number", title = "Call Store", payload = "+14158005959" },
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "postback", title = "Delete", payload = "DELETE_PRODUCT" }
                                                    },
                                              },
                                              new BotfolioChatBotSDK.Parameters.GenericMessageElement {
                                                    title     = "Mens Ultralight Hooded Duck Down Puffer Jacket",
                                                    sub_title = "US $28.49",
                                                    image_url = "http://i.ebayimg.com/images/g/yDMAAOSwzLlXh20m/s-l1600.jpg",
                                                    buttons   =    new List<BotfolioChatBotSDK.Parameters.PayloadButton> {
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "web_url",   title = "Buy", url = "http://www.ebay.com/itm/Mens-Ultralight-Hooded-Duck-Down-Puffer-Jacket-Coat-Warm-Outwear-Packable-Parka/302079513672" },
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "phone_number", title = "Call Store", payload = "+14158005959" },
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "postback", title = "Delete", payload = "DELETE_PRODUCT" }
                                                    },
                                              },
                                              new BotfolioChatBotSDK.Parameters.GenericMessageElement {
                                                    title     = "Star Trek Beyond Brand New DVD",
                                                    sub_title = "US $16.90",
                                                    image_url = "http://i.ebayimg.com/images/g/~NsAAOSwXeJYEkth/s-l1600.jpg",
                                                        buttons   =    new List<BotfolioChatBotSDK.Parameters.PayloadButton> {
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "web_url",   title = "Buy", url = "http://www.ebay.com/itm/Star-Trek-Beyond-Brand-New-DVD-/162222495186" },
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "phone_number", title = "Call Store", payload = "+14158005959" },
                                                                new BotfolioChatBotSDK.Parameters.PayloadButton() { type = "postback", title = "Delete", payload = "DELETE_PRODUCT" }
                                                    },
                                              }
                                        }
                                    });
                                    break;
                                    
                                }
                            default:
                                {
                                    await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = textMessage.attachment.text, user_id = textMessage.user_id });
                                    break;
                                }
                        }
                        break;
                    }
                case "image":
                    {
                        await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.ImageMessage() {  content_type = imageMessage.attachment.content_type, url = imageMessage.attachment.url, user_id = imageMessage.user_id });
                        break;
                    }
                case "video":
                    {
                        await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.VideoMessage() { thumb_url = videoMessage.attachment.thumb_url, content_type = videoMessage.attachment.content_type, url = videoMessage.attachment.url, user_id = videoMessage.user_id });
                        break;
                    }
                case "voice":
                    {
                        await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.VoiceMessage() {  content_type = voiceMessage.attachment.content_type, url = voiceMessage.attachment.url, user_id = voiceMessage.user_id });
                        break;
                    }
                case "location":
                    {
                        await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.LocationMessage() {  latitude =  locationMessage.attachment.latitude , longitude = locationMessage.attachment.longitude , title = "New york", address = "New york city, 3th street", user_id = voiceMessage.user_id });
                        break;
                    }
                case "postback":
                    {
                        await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() {  text = "Your payload is " + postbackMessage.attachment.payload, user_id = voiceMessage.user_id });
                        break;
                    }
                default:
                    {
                        await chatBotService.SendMessageAsync(new BotfolioChatBotSDK.Parameters.TextMessage() { text = "I could not understand you.", user_id = textMessage.user_id });
                        break;
                    }
                 
            }

        }

    }
}
