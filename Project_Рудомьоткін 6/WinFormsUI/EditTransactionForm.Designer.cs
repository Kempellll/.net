namespace WinFormsUI;

partial class EditTransactionForm
{
    private System.ComponentModel.IContainer components = null;

    private TextBox txtTitle, txtNote;
    private NumericUpDown numAmount;
    private DateTimePicker dtpDate;
    private CheckBox chkIsExpense;
    private Button btnOk, btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        Size = new Size(370, 280);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false; MinimizeBox = false;

        int labelX = 10, fieldX = 120, y = 15, rowH = 35;
        Font f = new Font("Segoe UI", 9);

        Label MakeLabel(string text) =>
            new Label { Text = text, Location = new Point(labelX, y + 3), AutoSize = true, Font = f };

        Controls.Add(MakeLabel("Title:"));
        txtTitle = new TextBox { Location = new Point(fieldX, y), Width = 200, Font = f };
        Controls.Add(txtTitle); y += rowH;

        Controls.Add(MakeLabel("Amount:"));
        numAmount = new NumericUpDown
        {
            Location = new Point(fieldX, y),
            Width = 120,
            Font = f,
            Minimum = 0,
            Maximum = 9999999,
            DecimalPlaces = 2
        };
        Controls.Add(numAmount); y += rowH;

        Controls.Add(MakeLabel("Date:"));
        dtpDate = new DateTimePicker
        {
            Location = new Point(fieldX, y),
            Width = 160,
            Font = f,
            Format = DateTimePickerFormat.Short
        };
        Controls.Add(dtpDate); y += rowH;

        Controls.Add(MakeLabel("Is Expense:"));
        chkIsExpense = new CheckBox { Location = new Point(fieldX, y), Font = f, Checked = true };
        Controls.Add(chkIsExpense); y += rowH;

        Controls.Add(MakeLabel("Note:"));
        txtNote = new TextBox { Location = new Point(fieldX, y), Width = 200, Font = f };
        Controls.Add(txtNote); y += rowH + 5;

        btnOk = new Button
        {
            Text = "OK",
            Location = new Point(fieldX, y),
            Width = 90,
            Height = 30,
            BackColor = Color.FromArgb(46, 139, 87),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = f
        };
        btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(fieldX + 100, y),
            Width = 100,
            Height = 30,
            Font = f
        };
        Controls.AddRange(new Control[] { btnOk, btnCancel });

        btnOk.Click += btnOk_Click;
        btnCancel.Click += btnCancel_Click;
    }
}