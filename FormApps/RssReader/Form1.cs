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
        public Form1() {
            InitializeComponent();
        }

        private void btGetUrl_Click(object sender, EventArgs e) {
            items = null;
            lbRssTitle.Items.Clear();

            using (var wc = new WebClient()) {
                
                var url = wc.OpenRead(tbUrl.Text);

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
            wbBrowser.Navigate(items.ToArray()[lbRssTitle.SelectedIndex].Link);
        }
    }
}
