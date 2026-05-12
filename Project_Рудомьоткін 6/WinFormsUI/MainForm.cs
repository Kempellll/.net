using Core;

namespace WinFormsUI;

public partial class MainForm : Form
{
    private List<Transaction> _transactions = new();
    private BindingSource _bindingSource = new();

    public MainForm()
    {
        InitializeComponent();
        SetupGrid();
        LoadSampleData();
    }

    private void SetupGrid()
    {
        _bindingSource.DataSource = _transactions;
        dataGridView.DataSource = _bindingSource;
        dataGridView.AutoGenerateColumns = false;
        dataGridView.Columns.Clear();
        dataGridView.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 40 },
            new DataGridViewTextBoxColumn { HeaderText = "Title", DataPropertyName = "Title", Width = 180 },
            new DataGridViewTextBoxColumn { HeaderText = "Amount", DataPropertyName = "Amount", Width = 90, DefaultCellStyle = { Format = "F2" } },
            new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "Date", Width = 90, DefaultCellStyle = { Format = "dd.MM.yyyy" } },
            new DataGridViewCheckBoxColumn { HeaderText = "Expense", DataPropertyName = "IsExpense", Width = 65 },
            new DataGridViewTextBoxColumn { HeaderText = "Note", DataPropertyName = "Note", Width = 150 }
        );
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView.ReadOnly = true;
        dataGridView.AllowUserToAddRows = false;
    }

    private void LoadSampleData()
    {
        _transactions.AddRange(new[]
        {
            new Transaction(1,  "Supermarket", 850.50,  new DateTime(2024,6,1),  true,  1, ""),
            new Transaction(2,  "Salary",      25000,   new DateTime(2024,6,5),  false, 2, ""),
            new Transaction(3,  "Cafe",        320,     new DateTime(2024,6,7),  true,  3, ""),
            new Transaction(4,  "Utilities",   1450,    new DateTime(2024,6,10), true,  4, ""),
            new Transaction(5,  "Freelance",   5000,    new DateTime(2024,6,12), false, 2, ""),
        });
        RefreshGrid();
    }

    private void RefreshGrid()
    {
        _bindingSource.DataSource = null;
        _bindingSource.DataSource = _transactions;
        UpdateStatusBar();
    }

    private void UpdateStatusBar()
    {
        double income = _transactions.Where(t => !t.IsExpense).Sum(t => t.Amount);
        double expense = _transactions.Where(t => t.IsExpense).Sum(t => t.Amount);
        double balance = income - expense;
        statusLabel.Text = $"Records: {_transactions.Count} | Income: {income:F2} | Expenses: {expense:F2} | Balance: {balance:F2}";
    }

    private int GetNextId() =>
        _transactions.Count == 0 ? 1 : _transactions.Max(t => t.Id) + 1;

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var form = new EditTransactionForm(GetNextId());
        if (form.ShowDialog() == DialogResult.OK)
        {
            _transactions.Add(form.Result!);
            RefreshGrid();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dataGridView.CurrentRow?.DataBoundItem is not Transaction selected) return;
        var form = new EditTransactionForm(selected);
        if (form.ShowDialog() == DialogResult.OK)
        {
            int idx = _transactions.IndexOf(selected);
            _transactions[idx] = form.Result!;
            RefreshGrid();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dataGridView.CurrentRow?.DataBoundItem is not Transaction selected) return;
        var confirm = MessageBox.Show($"Delete {selected.Title}?", "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm == DialogResult.Yes)
        {
            _transactions.Remove(selected);
            RefreshGrid();
        }
    }

    private void btnSaveJson_Click(object sender, EventArgs e)
    {
        using var dlg = new SaveFileDialog { Filter = "JSON|*.json", FileName = "transactions.json" };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            JsonStorage.Save(_transactions, dlg.FileName);
            MessageBox.Show("Saved!", "JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnLoadJson_Click(object sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog { Filter = "JSON|*.json" };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            var loaded = JsonStorage.Load(dlg.FileName);
            if (loaded.Count > 0) { _transactions = loaded; RefreshGrid(); }
        }
    }

    private void btnSaveXml_Click(object sender, EventArgs e)
    {
        using var dlg = new SaveFileDialog { Filter = "XML|*.xml", FileName = "expenses.xml" };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            XmlStorage.SaveExpenses(_transactions, dlg.FileName);
            MessageBox.Show("Saved!", "XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}