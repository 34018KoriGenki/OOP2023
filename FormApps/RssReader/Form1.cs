using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        IEnumerable<ItemData> items;
        string defaultSite = @"https://news.yahoo.co.jp/rss";
        Dictionary<string,string> categorys;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            var categorys = new Dictionary<string, string>();
            using (var wc = new WebClient()) {
                wc.Encoding = Encoding.UTF8;
                var url = wc.OpenRead(defaultSite);

                XDocument xdoc = XDocument.Load(url);
                var takes = xdoc.Root.Descendants("li").Descendants("a");
                foreach (var topic in takes) {
                    if (topic.FirstAttribute.Value.Contains(".xml")
                            && !cbCategory.Items.Contains(topic.Value)) {
                        cbCategory.Items.Add(topic.Value);
                        categorys.Add(topic.Value,topic.FirstAttribute.Value);
                    }
                }
                this.categorys = categorys;
                cbCategory.Text = cbCategory.Items[0].ToString();
                
            }
        }

        private void btGetUrl_Click(object sender, EventArgs e) {
            if (cbUrl.Text == "") return;
            items = null;
            lbRssTitle.Items.Clear();

            using (var wc = new WebClient()) {

                var url = wc.OpenRead(cbUrl.Text);

                XDocument xdoc = XDocument.Load(url);

                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData() {
                        Title = x.Element("title").Value,
                        Link = x.Element("link").Value,
                    });

                foreach (var item in items) {
                    lbRssTitle.Items.Add(item.Title);
                }
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex != -1) {
                wbBrowser.Navigate(items.ToArray()[lbRssTitle.SelectedIndex].Link);
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e) {
            var catUrl = categorys.ToArray()[cbCategory.SelectedIndex].Value;
            cbUrl.Text = catUrl;
        }
    }
}
