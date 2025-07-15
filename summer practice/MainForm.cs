using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace summer_practice
{
    public partial class MainForm : Form
    {
        private readonly PlanetRenderer renderer = new();
        private string currentAddType = "Tree";
        private Cursor defaultCursor;

        public MainForm()
        {
            InitializeComponent();
            defaultCursor = this.Cursor;

            pictureBoxPlanet.Paint += pictureBoxPlanet_Paint;
            pictureBoxPlanet.MouseClick += pictureBoxPlanet_MouseClick;

            btnAddTree.Click += (s, e) => SetCurrentAddType("Tree");
            btnAddHouse.Click += (s, e) => SetCurrentAddType("House");
            btnAddFlag.Click += (s, e) => SetCurrentAddType("Flag");
            btnAddAntenna.Click += (s, e) => SetCurrentAddType("Antenna");

            btnDeleteLast.Click += btnDeleteLast_Click;
            btnClearAll.Click += btnClear_Click;
            btnChangeColor.Click += btnColor_Click;
            btnSaveState.Click += btnSave_Click;
            btnLoadState.Click += btnLoad_Click;
        }

        private void SetCurrentAddType(string type)
        {
            currentAddType = type;
            this.Cursor = new Cursor(new MemoryStream(Properties.Resources.cursor));
        }
        private void pictureBoxPlanet_Paint(object sender, PaintEventArgs e)
        {
            renderer.Draw(e.Graphics, pictureBoxPlanet.Size);
        }

        private void pictureBoxPlanet_MouseClick(object sender, MouseEventArgs e)
        {
            var obj = ObjectFactory.Create(currentAddType, e.Location);
            if (obj != null)
            {
                renderer.Objects.Add(obj);
                pictureBoxPlanet.Invalidate();
                UpdateLabels();
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                renderer.PlanetColor = colorDialog1.Color;
                pictureBoxPlanet.Invalidate();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            renderer.Objects.Clear();
            pictureBoxPlanet.Invalidate();
            UpdateLabels();
        }

        private void btnDeleteLast_Click(object sender, EventArgs e)
        {
            if (renderer.Objects.Count > 0)
                renderer.Objects.RemoveAt(renderer.Objects.Count - 1);

            pictureBoxPlanet.Invalidate();
            UpdateLabels();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var data = renderer.Objects
                    .Select(o => new ObjectData { Type = o.ObjectType, Position = o.Position })
                    .ToList();

                File.WriteAllText(saveFileDialog1.FileName, JsonSerializer.Serialize(data));
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var json = File.ReadAllText(openFileDialog1.FileName);
                var data = JsonSerializer.Deserialize<ObjectData[]>(json);

                renderer.Objects.Clear();
                foreach (var d in data)
                    renderer.Objects.Add(ObjectFactory.Create(d.Type, d.Position));

                pictureBoxPlanet.Invalidate();
                UpdateLabels();
            }
        }

        private void radioAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                currentAddType = rb.Tag.ToString();
                this.Cursor = new Cursor(new MemoryStream(Properties.Resources.cursor));
            }
            else
            {
                this.Cursor = defaultCursor;
            }
        }

        private void UpdateLabels()
        {
            lblTree.Text = $"Trees: {renderer.Objects.Count(o => o.ObjectType == "Tree")}";
            lblHouse.Text = $"Houses: {renderer.Objects.Count(o => o.ObjectType == "House")}";
            lblFlag.Text = $"Flags: {renderer.Objects.Count(o => o.ObjectType == "Flag")}";
            lblAntenna.Text = $"Antennas: {renderer.Objects.Count(o => o.ObjectType == "Antenna")}";
        }
    }
}
