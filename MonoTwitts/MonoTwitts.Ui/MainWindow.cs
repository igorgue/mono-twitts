//
// MainWindow.cs
//
// Copyright (c) 2008 Igor Guerrero Fonseca <igor@ubuntu.org.ni>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using Gtk;

using MonoTwitts.Core;

namespace MonoTwitts.Ui
{
    /// <summary>
    /// Application window
    /// </summary>
    public partial class MainWindow: Gtk.Window
    {
        private VBox areaStatus;
        private Viewport w4;
        
        /// <summary>
        /// Add the twitts to the box
        /// </summary>
        public void AddTwitts()
        {
            if(w4 != null) {
                w4.Destroy();
                w4 = null;   
            }
            w4 = new Gtk.Viewport();
            w4.ShadowType = ((Gtk.ShadowType)(0));
            
            scrolledwindow.Add(w4);
            areaStatus = null;
            scrolledwindow.Remove(areaStatus);
            
            // Container child GtkViewport.Gtk.Container+ContainerChild
            areaStatus = new Gtk.VBox();
            areaStatus.Name = "areaStatus";
            areaStatus.Spacing = 6;
            
            w4.Add(areaStatus);
            scrolledwindow.Add(w4);
            
            Status[] sts = ObjectCalls.GetPublicTimeline();
            foreach(Status st in sts) {
                StatusViewItem stItem = new StatusViewItem(st);
                areaStatus.Add(stItem);
                if(st.StatusId != sts[sts.Length - 1].StatusId)
                    areaStatus.Add(new Gtk.HSeparator());
            }
        }
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow(): base(Gtk.WindowType.Toplevel)
        {
            Build ();
            this.WidthRequest = 400;
            this.HeightRequest = 300;
            AddTwitts();
        }
        
        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit ();
            a.RetVal = true;
        }
        
        protected virtual void OnAboutActionActivated(object sender, System.EventArgs e)
        {
            AboutDialog aboutus = new AboutDialog();
            aboutus.Run();
            aboutus.Destroy();
        }

        protected virtual void OnRefreshActionActivated (object sender, System.EventArgs e)
        {
            //FIXME: Not workee
            //AddTwitts();
        }
    }
}
