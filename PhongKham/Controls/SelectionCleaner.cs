namespace PhongKham.Controls;

public static class SelectionCleaner
{
    public static void Attach(Control root)
    {
        var wired = new HashSet<Control>();
        void Wire(Control control)
        {
            if (!wired.Add(control))
                return;
            control.ControlAdded += (_, e) => { if (e.Control is not null) Wire(e.Control); };
            control.Disposed += (_, _) => wired.Remove(control);
            control.MouseDown += (_, e) =>
            {
                if (e.Button != MouseButtons.Left)
                    return;
                bool blank = control is Panel or Label or Form or UserControl;
                if (control is DataGridView grid)
                    blank = grid.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.None;
                if (blank)
                    Clear(root);
            };
            foreach (Control child in control.Controls)
                Wire(child);
        }
        Wire(root);
    }

    public static void Clear(Control root)
    {
        if (root is AppGrid grid)
            grid.ClearUserSelection();
        foreach (Control child in root.Controls)
            Clear(child);
    }
}