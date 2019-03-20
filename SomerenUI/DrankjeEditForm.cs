using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenLogic;

namespace SomerenUI
{
    public partial class DrankjeEditForm : Form
    {
        SomerenUI summonedBy;
        public DrankjeEditForm(ListViewItem t, SomerenUI summonedBy)
        {
            InitializeComponent();
            this.summonedBy = summonedBy;
            this.DrinkIDInfoItem.Text = t.SubItems[0].Text;
            this.DrinkNaamInfoItem.Text = t.SubItems[1].Text;
            this.VerkochtInfoItem.Text = t.SubItems[2].Text;
            this.VerkoopPrijsInfoItem.Text = t.SubItems[3].Text;
            this.VoorraadInfoItem.Text = t.SubItems[4].Text.Split(' ')[0];
            this.AlcoholInfoItem.Text = t.SubItems[5].Text;
            this.BTWInfoItem.Text = t.SubItems[6].Text;
            this.SaveButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory editedItem = new Inventory()
                {
                    DrankjeID = int.Parse(DrinkIDInfoItem.Text),
                    Naam = DrinkNaamInfoItem.Text,
                    Verkocht = int.Parse(VerkochtInfoItem.Text),
                    Verkoopprijs = double.Parse(VerkoopPrijsInfoItem.Text),
                    Voorraad = int.Parse(VoorraadInfoItem.Text),
                    Alcohol = AlcoholInfoItem.Text.ToLower() == "false" ? false : true,
                    BTW = double.Parse(VerkoopPrijsInfoItem.Text) * 0.21
                };

                Inventory_Service service = new Inventory_Service();
                service.UpdateRow(editedItem);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
            }
            finally
            {
                summonedBy.Show();
                summonedBy.UpdateInventoryListView();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DrankjeEditForm_Load(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            summonedBy.Show();
            this.Close();
        }

        private void VoorraadInfoItem_TextChanged(object sender, EventArgs e)
        {
            this.SaveButton.Enabled = true;
        }

        private void VerkoopPrijsInfoItem_TextChanged(object sender, EventArgs e)
        {
            this.SaveButton.Enabled = true;
        }

        private void DrinkNaamInfoItem_TextChanged(object sender, EventArgs e)
        {
            this.SaveButton.Enabled = true;
        }
    }
}
