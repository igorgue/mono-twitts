// MainWindow.cs created with MonoDevelop
// User: igor at 10:40 PM 3/29/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{    
    public MainWindow (): base (Gtk.WindowType.Toplevel)
    {
        Build ();
    }
    
    protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    {
        Application.Quit ();
        a.RetVal = true;
    }
}