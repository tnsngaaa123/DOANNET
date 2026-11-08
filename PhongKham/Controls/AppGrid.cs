using System.ComponentModel;

namespace PhongKham.Controls;

public sealed class AppGrid : DataGridView
{
    private bool _binding, _userSelected;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool HasUserSelection => _userSelected && SelectedRows.Count > 0;

    public void BindRows(object data)
    {
        _binding = true;
        _userSelected = false;
        try
        {
            DataSource = data;
            ClearInitialSelection();
        }
        finally { _binding = false; }
    }

    public void RestoreUserSelection(int row)
    {
        _userSelected = true;
        CurrentCell = Rows[row].Cells[0];
        Rows[row].Selected = true;
    }

    private void ClearInitialSelection()
    {
        CurrentCell = null;
        ClearSelection();
    }

    public void ClearUserSelection()
    {
        _userSelected = false;
        ClearInitialSelection();
    }

    protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
    {
        if (!_userSelected)
            ClearInitialSelection();
        base.OnDataBindingComplete(e);
    }

    protected override void OnEnter(EventArgs e)
    {
        base.OnEnter(e);
        if (!_userSelected)
            ClearInitialSelection();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (HitTest(e.X, e.Y).Type == DataGridViewHitTestType.None)
        {
            ClearUserSelection();
            base.OnMouseDown(e);
            ClearUserSelection();
            return;
        }
        if (HitTest(e.X, e.Y).RowIndex >= 0)
            _userSelected = true;
        base.OnMouseDown(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode is Keys.Up or Keys.Down or Keys.Home or Keys.End or Keys.PageUp or Keys.PageDown)
            _userSelected = true;
        base.OnKeyDown(e);
    }

    protected override void OnSelectionChanged(EventArgs e)
    {
        if (!_binding && _userSelected)
            base.OnSelectionChanged(e);
    }
}
