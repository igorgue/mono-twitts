// Status.cs
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

namespace MonoTwitts.Core
{
    /// <summary>
    /// Define a status from twitter user
    /// </summary>
    public class Status
    {   
        // Status related
        private DateTime created;
        private string statusId = null;
        private string text = null;
        private string source = null;
        private bool truncated = false;
        private string inReplyTo = null;
        private string inReplyToUserId = null;
        
        // User related
        private User user = null;
        
        public Status() { }
        
        /// <value>
        /// Given a twitter datetime string we create and return a C# DateTime
        /// </value>
        public object Created {
            set {
                string time = ((string)value).Substring(4);
                
                string[] months = {"Jan", "Feb", "Mar", "Apr", "May", 
                    "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
                
    			for(int i = 0; i < months.Length; i++) {
    				time = time.Replace(months[i], String.Format("{0:00}", i + 1));
    			}
                created = DateTime.ParseExact(time, "MM dd HH:mm:ss +0000 yyyy", null);
            }
            get { return (DateTime)created; }
        }
        
        public string StatusId {
            set { statusId = value; }
            get { return statusId; }
        }
        
        public string Text {
            set { text = value; }
            get { return text; }
        }
        
        public string Source {
            set { source = value; }
            get { return source; }
        }
        
        public bool Truncated {
            set { truncated = value; }
            get { return truncated; }
        }
		
        public string InReplyTo {
            set { inReplyTo = value; }
            get { return inReplyTo; }
        }
        
        public string InReplyToUserId {
            set { inReplyToUserId = value; }
            get { return inReplyToUserId; }
        }
        
		public User User {
            set { user = value; }
			get { return user; }
		}
    }
}
