using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle11g.Connection;
using System.Xml;

namespace Oracle11g
{
    public partial class InsertForm : Form
    {
        Form1 frm1;
        public InsertForm()
        {
            InitializeComponent();
            setListBox();
        }

        public InsertForm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            frm1 = form1;
            setListBox();
        }

        DBConnection[] conn = null;
        private Form1 form1;

        void setListBox()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("C:\\Users\\admin\\documents\\visual studio 2015\\Projects\\Oracle11g\\Oracle11g\\Connection\\DataList.xml");
            XmlNodeList xmllist_SCHEMAS = xml.GetElementsByTagName("SCHEMAS");
            XmlNodeList xmllist_SCHEMA = xml.GetElementsByTagName("SCHEMA");
            ListViewItem[] listItem = new ListViewItem[xmllist_SCHEMA.Count];

                foreach (XmlNode xn in xmllist_SCHEMAS)
                {
                    
                    conn = new DBConnection[xmllist_SCHEMA.Count];
                    
                    for (int i = 0 ; i < xmllist_SCHEMA.Count ; i++)
                    {
                        conn[i] = new DBConnection(xmllist_SCHEMA[i]["name"].InnerText, xmllist_SCHEMA[i]["host"].InnerText, xmllist_SCHEMA[i]["port"].InnerText, xmllist_SCHEMA[i]["id"].InnerText, xmllist_SCHEMA[i]["password"].InnerText, xmllist_SCHEMA[i]["tabledirectory"].InnerText);

                        ListViewItem li = new ListViewItem(xmllist_SCHEMA[i]["name"].InnerText);
                        li.SubItems.Add(xmllist_SCHEMA[i]["host"].InnerText);
                        li.SubItems.Add(xmllist_SCHEMA[i]["port"].InnerText);
                        li.SubItems.Add(xmllist_SCHEMA[i]["id"].InnerText);
                        listItem[i] = li;
                    }
                }
                listView1.View = View.Details;
                listView1.Columns.Add("name", 120);        //컬럼추가
                listView1.Columns.Add("host", 100);
                listView1.Columns.Add("port", 100);
                listView1.Columns.Add("id", 170);

                listView1.BeginUpdate();
                foreach (ListViewItem vli in listItem)
                {
                    listView1.Items.Add(vli);
                }
                listView1.EndUpdate();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Global.selectedDatabase = null;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            Global.selectedDatabase = null;
            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                ListViewItem lvItem = items[0];
                string selectedItemName = lvItem.SubItems[0].Text;
                foreach(DBConnection dbconn in conn)
                {
                    if(dbconn.DB_name == selectedItemName)
                    {
                        Global.selectedDatabase = dbconn;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("다시선택하세요");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection.setm_ConnectionString(Global.selectedDatabase);
            //MessageBox.Show("선택 DB는 " + Global.selectedDatabase.DB_name + " " + Global.selectedDatabase.DB_id);
            DBConnection.InitDB(Global.selectedDatabase);
            frm1.setCombobox();
            new MakeTableData().getData();
            Close();
        }
    }
}
