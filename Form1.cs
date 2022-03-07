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
    }
}
