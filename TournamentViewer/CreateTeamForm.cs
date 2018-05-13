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
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();


        public CreateTeamForm()
        {
            InitializeComponent();
            // SampleData();
            WireUpLists();
        }

        private void SampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Siddharth", LastName = "Rawat" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Bholu", LastName = "Rawat" });
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
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
                personModel = GlobalConfig.Connection.CreatePerson(personModel);
                selectedTeamMembers.Add(personModel);
                WireUpLists();

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

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;
            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }

        }

        private void deleteSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();
            if (teamNameValue.Text != string.Empty)
            {
                t.TeamName = teamNameValue.Text;
                t.TeamMembers = selectedTeamMembers;
                t = GlobalConfig.Connection.CreateTeam(t);
            }
            else
                MessageBox.Show("Please enter Team Name");

        }
    }
}
