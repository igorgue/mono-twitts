// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoTwitts.Ui {
    
    
    public partial class MainWindow {
        
        private Gtk.Action MenuAction;
        
        private Gtk.Action HelpAction;
        
        private Gtk.Action AboutAction;
        
        private Gtk.RadioAction FriendsAction;
        
        private Gtk.RadioAction PublicAction;
        
        private Gtk.RadioAction DirectAction;
        
        private Gtk.RadioAction ResponsesAction;
        
        private Gtk.Action PreferencesAction;
        
        private Gtk.Action RefreshAction;
        
        private Gtk.Action QuitAction;
        
        private Gtk.VBox vbox1;
        
        private Gtk.MenuBar menubar;
        
        private Gtk.ScrolledWindow scrolledwindow;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoTwitts.Ui.MainWindow
            Gtk.UIManager w1 = new Gtk.UIManager();
            Gtk.ActionGroup w2 = new Gtk.ActionGroup("Default");
            this.MenuAction = new Gtk.Action("MenuAction", Mono.Unix.Catalog.GetString("Menu"), null, null);
            this.MenuAction.ShortLabel = Mono.Unix.Catalog.GetString("Menu");
            w2.Add(this.MenuAction, "<Control>m");
            this.HelpAction = new Gtk.Action("HelpAction", Mono.Unix.Catalog.GetString("Help"), null, null);
            this.HelpAction.ShortLabel = Mono.Unix.Catalog.GetString("Help");
            w2.Add(this.HelpAction, "<Control>h");
            this.AboutAction = new Gtk.Action("AboutAction", Mono.Unix.Catalog.GetString("About"), null, "gtk-about");
            this.AboutAction.ShortLabel = Mono.Unix.Catalog.GetString("About");
            w2.Add(this.AboutAction, null);
            this.FriendsAction = new Gtk.RadioAction("FriendsAction", Mono.Unix.Catalog.GetString("Friends"), null, null, 0);
            this.FriendsAction.Group = new GLib.SList(System.IntPtr.Zero);
            this.FriendsAction.ShortLabel = Mono.Unix.Catalog.GetString("Friends");
            w2.Add(this.FriendsAction, null);
            this.PublicAction = new Gtk.RadioAction("PublicAction", Mono.Unix.Catalog.GetString("Public"), null, null, 0);
            this.PublicAction.Group = this.FriendsAction.Group;
            this.PublicAction.ShortLabel = Mono.Unix.Catalog.GetString("Public");
            w2.Add(this.PublicAction, null);
            this.DirectAction = new Gtk.RadioAction("DirectAction", Mono.Unix.Catalog.GetString("Direct"), null, null, 0);
            this.DirectAction.Group = this.FriendsAction.Group;
            this.DirectAction.ShortLabel = Mono.Unix.Catalog.GetString("Direct");
            w2.Add(this.DirectAction, null);
            this.ResponsesAction = new Gtk.RadioAction("ResponsesAction", Mono.Unix.Catalog.GetString("@ Responses"), null, null, 0);
            this.ResponsesAction.Group = this.FriendsAction.Group;
            this.ResponsesAction.ShortLabel = Mono.Unix.Catalog.GetString("@ Responses");
            w2.Add(this.ResponsesAction, null);
            this.PreferencesAction = new Gtk.Action("PreferencesAction", Mono.Unix.Catalog.GetString("Preferences"), null, "gtk-preferences");
            this.PreferencesAction.ShortLabel = Mono.Unix.Catalog.GetString("Preferences");
            w2.Add(this.PreferencesAction, null);
            this.RefreshAction = new Gtk.Action("RefreshAction", Mono.Unix.Catalog.GetString("Refresh"), null, "gtk-refresh");
            this.RefreshAction.ShortLabel = Mono.Unix.Catalog.GetString("Refresh");
            w2.Add(this.RefreshAction, null);
            this.QuitAction = new Gtk.Action("QuitAction", Mono.Unix.Catalog.GetString("Quit"), null, "gtk-quit");
            this.QuitAction.ShortLabel = Mono.Unix.Catalog.GetString("Quit");
            w2.Add(this.QuitAction, null);
            w1.InsertActionGroup(w2, 0);
            this.AddAccelGroup(w1.AccelGroup);
            this.Name = "MonoTwitts.Ui.MainWindow";
            this.Title = Mono.Unix.Catalog.GetString("Mono Twitt");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child MonoTwitts.Ui.MainWindow.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            w1.AddUiFromString("<ui><menubar name='menubar'><menu action='MenuAction'><menuitem action='RefreshAction'/><separator/><menuitem action='FriendsAction'/><menuitem action='PublicAction'/><menuitem action='DirectAction'/><menuitem action='ResponsesAction'/><separator/><menuitem action='PreferencesAction'/><separator/><menuitem action='QuitAction'/></menu><menu action='HelpAction'><menuitem action='AboutAction'/></menu></menubar></ui>");
            this.menubar = ((Gtk.MenuBar)(w1.GetWidget("/menubar")));
            this.menubar.Name = "menubar";
            this.vbox1.Add(this.menubar);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.menubar]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.scrolledwindow = new Gtk.ScrolledWindow();
            this.scrolledwindow.CanFocus = true;
            this.scrolledwindow.Name = "scrolledwindow";
            this.scrolledwindow.ShadowType = ((Gtk.ShadowType)(4));
            this.scrolledwindow.BorderWidth = ((uint)(5));
            this.vbox1.Add(this.scrolledwindow);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.scrolledwindow]));
            w4.Position = 1;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 413;
            this.DefaultHeight = 455;
            this.Show();
            this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
            this.AboutAction.Activated += new System.EventHandler(this.OnAboutActionActivated);
            this.RefreshAction.Activated += new System.EventHandler(this.OnRefreshActionActivated);
        }
    }
}
