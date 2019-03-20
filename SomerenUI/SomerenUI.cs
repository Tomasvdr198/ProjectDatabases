using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_rooms.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();
                pnl_rooms.Hide();
                // show students
                pnl_Students.Show();



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Items.Clear();

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
                    listViewStudents.Items.Add(li);
                }

            }
            else if (panelName == "Teachers")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_rooms.Hide();
                // show 
                pnl_Teachers.Show();


                // fill the students listview within the students panel with a list of students
                SomerenLogic.Teacher_Service teacherService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = teacherService.GetTeachers();

                // clear the listview before filling it again
                listViewTeacher.Items.Clear();

                foreach (SomerenModel.Teacher t in teacherList)
                {

                    ListViewItem li = new ListViewItem(t.Name);
                    listViewTeacher.Items.Add(li);
                }

            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_Verkoop.Hide();

                // show 
                pnl_rooms.Show();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();

                // clear the listview before filling it again
                listViewRooms.Items.Clear();

                foreach (SomerenModel.Room t in roomList)
                {


                    string type = "student";
                    if (t.Type)
                    {
                        type = "student";
                    }
                    else
                    {
                        type = "teacher";
                    }
                    ListViewItem li = new ListViewItem(t.Number.ToString() + " " + t.Capacity.ToString() + " " + type);

                    listViewRooms.Items.Add(li);
                }
            }
            else if (panelName == "Verkoop")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_rooms.Hide();

                // show 
                pnl_Verkoop.Show();
                UpdateInventoryListView();
            }
        }

        public void UpdateInventoryListView()
        {
            // fill the students listview within the students panel with a list of students
            SomerenLogic.Inventory_Service InventoryService = new SomerenLogic.Inventory_Service();
            List<Inventory> InventoryList = InventoryService.GetInventory();

            // clear the listview before filling it again
            ListViewInventory.Items.Clear();
            ListViewInventory.Columns.Clear();
            ListViewInventory.View = View.Details;
            ListViewInventory.Columns.Add("DrankjeID", 100, HorizontalAlignment.Left);
            ListViewInventory.Columns.Add("Naam", 100, HorizontalAlignment.Left);
            ListViewInventory.Columns.Add("Verkocht", 100, HorizontalAlignment.Left);
            ListViewInventory.Columns.Add("Verkoopprijs", 100, HorizontalAlignment.Left);
            ListViewInventory.Columns.Add("Voorraad", 150, HorizontalAlignment.Left);
            ListViewInventory.Columns.Add("Alcohol", 100, HorizontalAlignment.Left);
            ListViewInventory.Columns.Add("BTW", 80, HorizontalAlignment.Left);
            foreach (SomerenModel.Inventory i in InventoryList)
            {
                string[] buffer = new string[]{
                        i.DrankjeID.ToString(),
                        i.Naam,
                        i.Verkocht.ToString(),
                        i.Verkoopprijs.ToString(),
                        i.Voorraad > 10 ? i.Voorraad.ToString() + " Voldoende voorraad " : i.Voorraad.ToString() + " Onvoldoende voorraad ",
                        i.Alcohol.ToString(),
                        i.BTW.ToString()
                    };
                ListViewItem li = new ListViewItem(buffer);
                ListViewInventory.Items.Add(li);
            }

            ListViewInventory.LabelEdit = true;
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }
        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_Students_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void pnl_rooms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewInventory.SelectedIndices.Count == 0)
                return;
            int i = ListViewInventory.SelectedIndices[0];
            var l = ListViewInventory.Items[i];
            this.Hide();
            DrankjeEditForm edit = new DrankjeEditForm(l, this);
            edit.Show();
        }

        private void pnl_Verkoop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Verkoop");
        }


    }
}
