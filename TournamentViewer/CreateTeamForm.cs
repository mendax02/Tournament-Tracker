using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TournamentViewer
{
    public partial class CreateTeamForm : Form
    {
        public object Global { get; private set; }

        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void tournamentNameValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void teamNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel personModel = new PersonModel();
                personModel.FirstName = firstNameValue.Text;
                personModel.LastName = lastNameValue.Text;
                personModel.Email = emailValue.Text;
                personModel.CellphoneNumber = cellPhoneValue.Text;
                GlobalConfig.Connection.CreatePerson(personModel);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellPhoneValue.Text = "";
            }
            else
                MessageBox.Show("You need to fill all the fields");
        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
                return false;

            if (lastNameValue.Text.Length == 0)
                return false;

            if (emailValue.Text.Length == 0)
                return false;

            if (cellPhoneValue.Text.Length == 0)
                return false;

            return true;
        }
    }
}
