using DAL;
using DesktopApp.Movies;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Employees
{
    public partial class EmployeeMenu : Form
    {
        private Button currentButton;
        private Form activeform;
        private readonly EmployeeController empController;
        IEmployeeDAL iEmployeeDAL;
        List<Employee> allEmployees;
        public EmployeeMenu()
        {
            InitializeComponent();
            iEmployeeDAL = new EmployeeDAL();
            empController = new EmployeeController(iEmployeeDAL);

            lblWarning.Text = "";
            string[] orderOptions = new string[]
            {
                "Ascending by id",
                "Descending by id",
                "Ascending by title",
                "Descending by title"
            };
            foreach (string option in orderOptions)
            {
                comboBoxOrder.Items.Add(option);
            }

            listBoxViewEmpoyees.Items.Clear();
            allEmployees = new List<Employee>();
            try
            {
                if (empController.GetAll() == null)
                {

                    lblWarning.Text = "No employees in the system.";
                }
                else
                {
                    foreach (Employee emp in empController.GetAll())
                    {
                        allEmployees.Add(emp);
                    }
                }

                if (allEmployees.Count > 0)
                {
                    foreach (Employee emp in allEmployees)
                    {
                        listBoxViewEmpoyees.Items.Add(emp.ToString());
                    }
                }
                else
                {
                    lblWarning.Text = "No employees in the system.";
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error: {ex.Message}";
            }
            
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(0, 71, 102);
                    currentButton.ForeColor = Color.FromArgb(145, 190, 222);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousButton in panel1.Controls)
            {
                if (previousButton.GetType() == typeof(Button))
                {
                    previousButton.BackColor = Color.FromArgb(145, 190, 222);
                    previousButton.ForeColor = Color.White;
                }
            }
        }

        private void OpenChildForm(Form childform, object btnSender)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            ActivateButton(btnSender);
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childform);
            this.panelDesktop.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        { }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            ActivateButton(sender);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddEmployee(), sender);
        }

        private void buttonMoreInfo_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            try
            {
                if (listBoxViewEmpoyees.SelectedItem != null)
                {
                    string selectedEmp = listBoxViewEmpoyees.SelectedItem.ToString();
                    foreach (Employee emp in empController.GetAll())
                    {
                        if (selectedEmp == emp.ToString())
                        {
                            MoreInfoEmp empMoreInfo = new MoreInfoEmp(emp);
                            empMoreInfo.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error: {ex.Message}";
            }
}

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            try
            {
                listBoxViewEmpoyees.Items.Clear();

                List<Employee> allEmployees = new List<Employee>();
                if (textBoxEmpName.Text != null || textBoxEmpName.Text == "" && textBoxEMpID.Text != null || textBoxEMpID.Text == "")
                {
                    foreach (Employee emp in empController.GetAll())
                    {

                        if (emp.FirstName.Contains(textBoxEmpName.Text) || emp.LastName.Contains(textBoxEmpName.Text))
                        {
                            string empID = emp.GetId().ToString();
                            if (empID == textBoxEMpID.Text)
                            {
                                allEmployees.Add(emp);
                            }
                        }

                    }
                }
                else
                {
                    foreach (Employee emp in empController.GetAll())
                    {
                        allEmployees.Add(emp);
                    }
                }


                foreach (Employee emp in allEmployees)
                {
                    listBoxViewEmpoyees.Items.Add(emp.ToString());
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error: {ex.Message}";
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        { }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (listBoxViewEmpoyees.SelectedIndex != -1)
                    {
                        int selected_emp_id = Int32.Parse(listBoxViewEmpoyees.SelectedItem.ToString().Split('-')[0]);
                        Employee selectedEMp = empController.GetEmployeeByID(selected_emp_id);
                        if (selectedEMp != null)
                        {
                            lblWarning.Text = empController.DeleteEmployee(selectedEMp);
                        }
                        else
                        {
                            lblWarning.Text = "No data found.";
                        }
                        listBoxViewEmpoyees.Items.Clear();
                        foreach (Employee emp in empController.GetAll())
                        {
                            listBoxViewEmpoyees.Items.Add(emp.ToString());
                        }
                    }
                    else
                    {
                        lblWarning.Text = "There is no employee selected!";

                    }
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"An unexpected error occurred: {ex.Message}";
            }

        }
    }
}
