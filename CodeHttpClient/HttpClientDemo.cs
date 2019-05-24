using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeHttpClient
{
    public partial class HttpClientDemo : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags,
            int dx, int dy, uint data, UIntPtr extraInfo);

        [Flags]
        enum MouseEventFlag : uint
        {
            MOUSEEVENTF_MOVE = 0x0001,//; 移动鼠标
            MOUSEEVENTF_LEFTDOWN = 0x0002,//; 模拟鼠标左键按下
            MOUSEEVENTF_LEFTUP = 0x0004,//; 模拟鼠标左键抬起
            MOUSEEVENTF_RIGHTDOWN = 0x0008,//; 模拟鼠标右键按下
            MOUSEEVENTF_RIGHTUP = 0x0010,//; 模拟鼠标右键抬起
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,//; 模拟鼠标中键按下
            MOUSEEVENTF_MIDDLEUP = 0x0040,//; 模拟鼠标中键抬起
            MOUSEEVENTF_ABSOLUTE = 0x8000//,; 标示是否采用绝对坐标
        }


        public void DoClick(int x, int y)
        {
            SetCursorPos(x, y);
            // mouse_event(MouseEventFlag.MOUSEEVENTF_ABSOLUTE | MouseEventFlag.MOUSEEVENTF_MOVE, x, y, 0, UIntPtr.Zero);

            mouse_event(MouseEventFlag.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
        }
        public HttpClientDemo()
        {
            InitializeComponent();

        }

        public void LoadResult(string result)
        {
            StringBuilder sbresult = new StringBuilder();

            HtmlAgilityPack.HtmlDocument docs = new HtmlAgilityPack.HtmlDocument();//忽略此类，这个类是其他DLL提供的，与NHtmlUnit无关
            docs.LoadHtml(result);

            sbresult.AppendLine("已经正确加载结果 .............");

            var table = docs.DocumentNode.SelectSingleNode("//*[@class=\"table table-hover text-middle table-bordered footable\"]");
            var trs = table.SelectSingleNode("tbody").SelectNodes("tr");
            List<SXClass> list = new List<SXClass>();
            trs.ToList().ForEach(item =>
            {
                var tds = item.SelectNodes("td");
                SXClass sx = new SXClass()
                {
                    InvestTime = (tds[0].InnerText).ToDateTime().AddHours(12),
                    OrderNumber = (tds[1].InnerText).ToStringExtension().Trim(),
                    JuHao = (tds[2].InnerText).ToStringExtension().Trim(),
                    ChangeCi = (tds[3].InnerText).ToStringExtension().Trim(),
                    GameType = (tds[4].InnerText).ToStringExtension().Trim(),
                    ZhuoHao = (tds[5].InnerText).ToStringExtension().Trim(),
                    Result = (tds[6].InnerText).ToStringExtension().Trim(),
                    InvestMoney = (tds[7].InnerText).ToStringExtension().Trim().ToDecimal(),
                    ValidMoney = (tds[8].InnerText).ToStringExtension().Trim().ToDecimal(),
                    WinMoney = (tds[9].InnerText).ToStringExtension().Trim().ToDecimal(),
                    Remark = (tds[10].InnerText).ToStringExtension().Trim(),
                };
                list.Add(sx);
            });

            if (list.Count > 0)
            {
                sbresult.AppendLine("找到数据.......");
                var last = list.OrderByDescending(x => x.InvestTime).FirstOrDefault();
                decimal money = 0;
                decimal yuer = 0;
                bool isGameOver = last.Remark.IndexOf("/") > 0;
                if (isGameOver)
                {
                    yuer = isGameOver  ?  last.Remark.Split('/')[1].ToDecimal() : last.Remark.ToDecimal();
                    money = last.InvestMoney.ToDecimal();
                    // todo
                    if (last.WinMoney > 0)
                    {
                        sbresult.AppendLine($"上一把投了：{last.InvestMoney}元，赢了:{last.WinMoney}元");
                        money -= 1;
                    }
                    if (last.WinMoney == 0)
                    {
                        sbresult.AppendLine("上一把和局.............");
                    }
                    if (last.WinMoney < 0)
                    {
                        sbresult.AppendLine($"上一把投了：{last.InvestMoney}元，输了:{last.WinMoney}元");
                        money += 1;
                    }

                    if (money < 10)
                        money = 10;

                    if (yuer < money)
                    {
                        // send Email
                        sbresult.AppendLine($"这把预计投{money}元,剩余:{yuer}元，余额不足.....");
                        timers.Stop();
                    }
                    if (yuer >= tGoodValue.Text.ToDecimal())
                    {
                        // send Email
                        sbresult.AppendLine($"这把预计投{money}元,剩余:{yuer}元， 已经ok.....");
                        timers.Stop();
                    }

                    // 点击1
                    int x = tMins.Text.Split(',')[0].ToInt32();
                    int y = tMins.Text.Split(',')[1].ToInt32();
                    DoClick(x, y);

                    // 点击闲
                    for (var i = 0; i < money; i++)
                    {
                        int xianx = tXian.Text.Split(',')[0].ToInt32();
                        int xiany = tXian.Text.Split(',')[1].ToInt32();
                        DoClick(xianx, xiany);
                    }

                    //// 点击确定
                    int okx = toks.Text.Split(',')[0].ToInt32();
                    int oky = toks.Text.Split(',')[1].ToInt32();
                    DoClick(okx, oky);

                }
                else
                {
                    sbresult.AppendLine($"在等待结果返回。。。。。。。。");
                }

               
            }

            tmessages.AppendText(sbresult.ToString());

        }


        public void GetSearchResult()
        {
            try
            {
                string firstDate = DateTime.Now.ToShortDateString();
                var url = "https://videoley.com/";
                string searchurl = $"{url}/game/betrecord_search/kind3?BarID=1&GameKind=3&date_start={ DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") }&date_end={DateTime.Now.ToString("yyyy-MM-dd")}&GameType=3001&State=-1&Limit=100&Sort=DESC";


                CookieContainer cookieContainer = new CookieContainer();
                string cooks = string.IsNullOrEmpty(tCookes.Text) ? @"_ga=GA1.2.1517511795.1541006194; 
             SESSION_ID=721a3e9776f829d3e65a52a357fa6f78888e0b57; 
             domain=K2V1WFRENDh3Z3RMZEhMSXN4Q3lZMFNRaEJTS0YyR09ZTkcrZlhkMm94dz06Ojaf9Db%2BCCXrO2J0w1vbZTk%3D; 
             hallid=V0pmd0VaQ204UEtmQ2UycjVzekhDQT09OjpBBptcxp%2Bm1hw0aIDGMDwD; 
             lang=cn; T0_IPL_AVRbbbbbbbbbbbbbbbb=NMODPBGCCDFIOJKKKGNLJKAOEPNEEBHMDCJADNOMCNLGEDEBKBDHLNHMBPEJIKPLDLENOGLBHIJDKBCIFFNFBECNBHDAIHKLHEFODJFGHDDOIBDFIPMNGOHCAKIGIMFD" : tCookes.Text;

                cooks.Split(';').ToList<string>().ForEach(x =>
                {
                    var k = x.Trim().Split('=')[0].ToString();
                    var v = x.Trim().Split('=')[1].ToString();
                    cookieContainer.Add(new Cookie(k, v, "/", ".videoley.com"));
                });
                //cookieContainer.Add(new Cookie("test", "0"));   // 加入Cookie
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    AllowAutoRedirect = true,
                    UseCookies = true
                };

                HttpClient httpClient = new HttpClient(httpClientHandler);

                httpClient.DefaultRequestHeaders.Add("Method", "Post");
                httpClient.DefaultRequestHeaders.Add("KeepAlive", "false");   // HTTP KeepAlive设为false，防止HTTP连接保持
                httpClient.DefaultRequestHeaders.Add("UserAgent",
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");


                var response = httpClient.GetAsync(searchurl);

                Task<string> reString = response.Result.Content.ReadAsStringAsync();
                reString.Wait();

                LoadResult(reString.Result);
            }
            catch (Exception ex)
            {
                tmessages.AppendText(ex.Message);
            }

        }

        private void bStarts_Click(object sender, EventArgs e)
        {
            timers.Interval = tIntevers.Text.ToInt32() * 1000;
            timers.Enabled = true;
            timers.Start();
        }

        private void bCloses_Click(object sender, EventArgs e)
        {
            timers.Enabled = false;
            timers.Stop();
        }

        private void timers_Tick(object sender, EventArgs e)
        {
            GetSearchResult();
        }

        private void timerpoints_Tick(object sender, EventArgs e)
        {
            this.Text = "X=" + MousePosition.X.ToString() + " " + "Y=" + MousePosition.Y.ToString();
        }
    }
    public class SXClass
    {
        public DateTime InvestTime { get; set; }

        public string OrderNumber { get; set; }

        public string JuHao { get; set; }

        public string ChangeCi { get; set; }

        public string GameType { get; set; }

        public string ZhuoHao { get; set; }

        public string Result { get; set; }

        public decimal InvestMoney { get; set; }

        public decimal ValidMoney { get; set; }

        public decimal WinMoney { get; set; }

        public string Remark { get; set; }
    }
}
