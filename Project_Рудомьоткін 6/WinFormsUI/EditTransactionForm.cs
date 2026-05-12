using Core;
using Microsoft.VisualBasic;

namespace WinFormsUI;

public partial class EditTransactionForm : Form
{
    public Transaction? Result { get; private set; }
    private readonly int _id;

    public EditTransactionForm(int nextId)
    {
        _id = nextId;
        InitializeComponent();
        Text = "Add Transaction";
    }

    public EditTransactionForm(Transaction t)
    {
        _id = t.Id;
        InitializeComponent();
        Text = "Edit Transaction";
        txtTitle.Text = t.Title;
        numAmount.Value = (decimal)t.Amount;
        dtpDate.Value = t.Date;
        chkIsExpense.Checked = t.IsExpense;
        txtNote.Text = t.Note;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Enter title!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        Result = new Transaction(_id, txtTitle.Text.Trim(), (double)numAmount.Value,
            dtpDate.Value, chkIsExpense.Checked, 1, txtNote.Text.Trim());
        DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e) =>
        DialogResult = DialogResult.Cancel;
}