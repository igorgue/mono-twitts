// User.cs
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
        /// Define user's data
        /// </summary>
        public class User
        {
                private string id = null;
                private string name = null;
                private string screenName = null;
                private string location = null;
                private string description = null;
                private string profile_image_url = null;
                private string url = null;
                private bool updates_protected = false;
                private int followers_count;
                
                /// <summary>
                /// Constructor
                /// </summary>
                public User ()
                {
                }
                
                public string Id {
                        set { id = value; }
                        get { return id; }
                }
                
                public string Name {
                        set { name = value; }
                        get { return name; }
                }
                
                public string ScreenName {
                        set { screenName = value; }
                        get { return screenName; }
                }
                
                public string Location {
                        set { location = value; }
                        get { return location; }
                }
                
                public string Description {
                        set { description = value; }
                        get { return description; }
                }
                
                public string ProfileImageUrl {
                        set { profile_image_url = value; }
                        get { return profile_image_url; }
                }
                
                public string Url {
                        set { url = value; }
                        get { return url; }
                }
                
                public bool UpdatesProtected {
                        set { updates_protected = value; }
                        get { return updates_protected; }
                }
                
                public int FollowersCount {
                        set { followers_count = value; }
                        get { return followers_count; }
                }
        }
}
