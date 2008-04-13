//
// StatusViewItem.cs
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
using Gnome;

using MonoTwitts.Core;

namespace MonoTwitts.Ui
{
    /// <summary>
    /// A entry to the Twitts view
    /// </summary>
    public partial class StatusViewItem: Gtk.Bin
    {
        private Status status;
        
        /// <summary>
        /// Create a StatusViewItem from a status object
        /// </summary>
        /// <param name="status">
        /// A <see cref="Status"/>
        /// </param>
        public StatusViewItem(Status st)
        {
            this.Build();
            
            status = st;
            
            // Set status data
            text.Text = status.Text;
            username.Label = status.User.Name;
            dateTime.Text = status.Created.ToString();
        }

        protected virtual void OnUsernameClicked(object sender, System.EventArgs e)
        {
            Gnome.Url.Show(String.Format("http://twitter.com/{0}", status.User.ScreenName));
        }
    }
}
