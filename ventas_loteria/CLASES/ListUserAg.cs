using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ventas_loteria
{
    public  class ListUserAg
    {
       

        public List<UserAg> _UserAg()
        {
            List<UserAg> _UserAg = new List<UserAg>
                {
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.10 Safari/605.1.1" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.3" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.3" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.3" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Trailer/93.3.8652.5" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Edg/134.0.0." },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Edg/134.0.0." },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36 Edg/131.0.0." },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36 OPR/117.0.0." },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36 Edg/132.0.0." },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 Edge/18.1958" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 Edge/18.1958" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.3" },

                    new UserAg { cdUserAg = "Mozilla/5.0 (Linux; Android 12; ABR-LX9; HMSCore 6.15.0.312; GMSCore 0.3.7.250932) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/114.0.5735.196 HuaweiBrowser/15.0.10.302 Mobile Safari/537.36" },

                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/58.0.1562.1902 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/41.0.7075.1637 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/59.0.3412.1281 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/55.0.8948.1291 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/52.0.3433.1416 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/48.0.8482.1069 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/129.0.0.0 Mobile Safari/537.36" },

                    new UserAg { cdUserAg = "Mozilla/5.0 (Linux; Android 12; ABR-LX9; HMSCore 6.15.0.312; GMSCore 0.3.7.250932) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/114.0.5735.196 HuaweiBrowser/15.0.10.302 Mobile Safari/537.36" },

                    new UserAg { cdUserAg = "Mozilla/5.0 (Ubuntu; Linux i686; versión:121.0) Gecko/20100101 Firefox/121.0" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Kubuntu; Linux x86_64; versión:126.0) Gecko/20100101 Firefox/126.0" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/67.0.3396.99 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (iPhone; CPU iPhone OS 18_3_2 como Mac OS X) AppleWebKit/605.1.15 (KHTML, como Gecko) GSA/352.0.715618234 Mobile/15E148 Safari/604.1" },

                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/58.0.1562.1902 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/51.0.6574.1619 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/41.0.7075.1637 Safari/537.36" },
                    new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, como Gecko) Chrome/59.0.3412.1281 Safari/537.36" },

                    //23/10/2025

                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.3" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.10 Safari/605.1.1" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.3" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.3" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Trailer/93.3.8652.5" },
                     
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Edg/134.0.0." },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36 Edg/131.0.0." },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36 OPR/117.0.0." },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36 Edg/132.0.0." },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 Edge/18.1958" },

                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.3" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Edg/134.0.3124.85" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; Xbox; Xbox One) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Edge/44.18363.8131" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:136.0) Gecko/20100101 Firefox/136.0" },

                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:128.0) Gecko/20100101 Firefox/128.0" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 OPR/118.0.0.0" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Windows NT 10.0; WOW64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 OPR/118.0.0.0" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Edg/134.0.3124.85" },

                     new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 14.7; rv:136.0) Gecko/20100101 Firefox/136.0" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 14.7; rv:128.0) Gecko/20100101 Firefox/128.0" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 14_7_4) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/18.3 Safari/605.1.15" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (Macintosh; Intel Mac OS X 14_7_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 OPR/118.0.0.0" },
                     new UserAg { cdUserAg = "" },

                     new UserAg { cdUserAg = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (X11; Linux i686; rv:136.0) Gecko/20100101 Firefox/136.0" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (X11; Linux x86_64; rv:136.0) Gecko/20100101 Firefox/136.0" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (X11; Ubuntu; Linux i686; rv:136.0) Gecko/20100101 Firefox/136.0" },
                     new UserAg { cdUserAg = "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:136.0) Gecko/20100101 Firefox/136.0" }

                };

            return _UserAg;
        }
    }
}
