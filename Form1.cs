using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part7part2
{
    public partial class ListBoxes : Form
    {
        List<int> numbers = new List<int>();
        List<string> heroes = new List<string>();
        Random gen = new Random();
        public ListBoxes()
        {
            InitializeComponent();
        }

        private void ListBoxes_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i += 1)
                numbers.Add(gen.Next(100));
            heroes.Add("Superman");
            heroes.Add("Batman");

            lstNumbers.DataSource = numbers;
            lstHeroes.DataSource = heroes;
        }

        private void btnSortNumbers_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            if (radDescending.Checked)
                numbers.Reverse();
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: numbers sorted";
        }

        private void btnSortHeroes_Click(object sender, EventArgs e)
        {
            heroes.Sort();
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status: heroes sorted";
        }

        private void btnNewNumbers_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            for (int i = 0; i < 30; i += 1)
                numbers.Add(gen.Next(100));
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: new numbers list";
        }

        private void btnNewHeroes_Click(object sender, EventArgs e)
        {
            heroes.Clear();
            heroes.Add("Superman");
            heroes.Add("Batman");
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status: new heroes list";
        }

        private void btnRemoveNumber_Click(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedIndex >= 0)
            {
                numbers.RemoveAt(lstNumbers.SelectedIndex);
                lstNumbers.DataSource = null;
                lstNumbers.DataSource = numbers;
                lblStatus.Text = "Status: number removed";
            }
        }

        private void btnRemoveAllNumbers_Click(object sender, EventArgs e)
        {
            int count = 0;
            while (numbers.Remove((Int32)lstNumbers.SelectedItem))
                count += 1;
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = $"Status: {count} numbers removed";
        }

        private void btnRemoveHero_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (string hero in heroes)
            {
                if (txtRemoveHero.Text.Trim().ToLower() == hero.ToLower())
                {
                    heroes.Remove(hero);
                    found = true;
                    break;
                }
            }
            if (found) {
                lstHeroes.DataSource = null;
                lstHeroes.DataSource = heroes;
                lblStatus.Text = "Status: hero removed succesfully";
            }
            else
            {
                lblStatus.Text = "Status: specified hero is not present";
            }

        }

        private void btnAddHero_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (string hero in heroes)
            {
                if (txtAddHero.Text.Trim().ToLower() == hero.ToLower())
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                lblStatus.Text = "Status: hero is already present";
            }
            else {
                if (txtAddHero.Text.Trim() != "")
                {
                    heroes.Add(txtAddHero.Text.Trim());
                    lstHeroes.DataSource = null;
                    lstHeroes.DataSource = heroes;
                    lblStatus.Text = "Status: hero added";
                }
            }
            txtAddHero.Clear();
        }

        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            numbers.Add(gen.Next(100));
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: number added";
        }
    }
}
