namespace WinFormsUI;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dataGridView;
    private Button btnAdd, btnEdit, btnDelete;
    private Button btnSaveJson, btnLoadJson, btnSaveXml;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel statusLabel;
    private Panel panelTop;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        Text = "Expense Tracker";
        Size = new Size(900, 560);
        StartPosition = FormStartPosition.CenterScreen;

        panelTop = new Panel { Dock = DockStyle.Top, Height = 45, Padding = new Padding(5) };

        btnAdd = MakeButton("Add", Color.FromArgb(46, 139, 87));
        btnEdit = MakeButton("Edit", Color.FromArgb(70, 130, 180));
        btnDelete = MakeButton("Delete", Color.FromArgb(178, 34, 34));
        btnSaveJson = MakeButton("Save JSON", Color.FromArgb(105, 105, 105));
        btnLoadJson = MakeButton("Load JSON", Color.FromArgb(105, 105, 105));
        btnSaveXml = MakeButton("Save XML", Color.FromArgb(105, 105, 105));

        int x = 5;
        foreach (var btn in new[] { btnAdd, btnEdit, btnDelete, btnSaveJson, btnLoadJson, btnSaveXml })
        {
            btn.Location = new Point(x, 6);
            panelTop.Controls.Add(btn);
            x += btn.Width + 5;
        }

        dataGridView = new DataGridView
        {
            Dock = DockStyle.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            Font = new Font("Segoe UI", 9)
        };

        statusStrip = new StatusStrip();
        statusLabel = new ToolStripStatusLabel { Text = "Ready", Spring = true, TextAlign = ContentAlignment.MiddleLeft };
        statusStrip.Items.Add(statusLabel);

        Controls.AddRange(new Control[] { dataGridView, panelTop, statusStrip });

        btnAdd.Click += btnAdd_Click;
        btnEdit.Click += btnEdit_Click;
        btnDelete.Click += btnDelete_Click;
        btnSaveJson.Click += btnSaveJson_Click;
        btnLoadJson.Click += btnLoadJson_Click;
        btnSaveXml.Click += btnSaveXml_Click;
    }

    private static Button MakeButton(string text, Color color) =>
        new Button
        {
            Text = text,
            Width = 100,
            Height = 30,
            BackColor = color,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9)
        };
}