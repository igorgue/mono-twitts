//
// ObjectCalls.cs
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
using System.IO;
using System.Xml;
using System.Collections;

namespace MonoTwitts.Core
{
    /// <summary>
    /// Basically transform the XML strings got from Core to status and user objects
    /// </summary>
    public class ObjectCalls
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectCalls() { }
        
        /// <summary>
        /// Get an status array
        /// </summary>
        /// <returns>
        /// A <see cref="Status"/>
        /// </returns>
        public static Status[] GetPublicTimeline()
        {
            return GetStatusObjects(new Core().GetPublicTimeline(Core.OutputFormatType.XML));
        }
        
        /// <summary>
        /// Gets your friends timeline by a given twitter username and password
        /// </summary>
        /// <param name="username">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="password">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="Status"/>
        /// </returns>
        public static Status[] GetFrindsTimeline(string username, string password)
        {
            return GetStatusObjects(new Core().GetFriendsTimeline(username, password, Core.OutputFormatType.XML));
        }
        
        /// <summary>
        /// Gets another user timeline
        /// </summary>
        /// <param name="username">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="password">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="idAnotherUser">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="Status"/>
        /// </returns>
        public static Status[] GetUserTimeline(string username, string password, string idAnotherUser)
        {
            if(!string.IsNullOrEmpty(idAnotherUser)) {
            	return GetStatusObjects(new Core().GetUserTimeline(username, password, idAnotherUser, Core.OutputFormatType.XML));
            } else {
                return GetStatusObjects(new Core().GetUserTimeline(username, password, username, Core.OutputFormatType.XML));
            }  
        }
        
        /// <summary>
        /// Gets the current user timeline
        /// </summary>
        /// <param name="username">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="password">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="Status"/>
        /// </returns>
        public static Status[] GetUserTimeline(string username, string password)
        {
            return GetUserTimeline(username, password, null);
        }
        
        /// <summary>
        /// Show a status object, does not work right now :(
        /// </summary>
        /// <param name="statusId">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="Status"/>
        /// </returns>
        public static Status Show(string statusId)
        {
            throw new System.Exception("For some reason Show does not work :( as it should");
        }
        
        /// <summary>
        /// Send an status update to twitter
        /// </summary>
        /// <param name="username">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="password">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="status">
        /// A <see cref="System.String"/>
        /// </param>
        public static void Update(string username, string password, string status)
        {
            new Core().Update(username, password, status, Core.OutputFormatType.XML);
        }
        
        /// <summary>
        /// Gets a status object array from a twitter XML string
        /// </summary>
        /// <param name="xml">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="Status"/>
        /// </returns>
        public static Status[] GetStatusObjects(string xml)
        {
            ArrayList statuses = new ArrayList();

            Status status = new Status();
            status.User = new User();

            XmlTextReader reader = new XmlTextReader(new StringReader(xml));

            while(reader.Read()) {
                if(reader.NodeType == XmlNodeType.Element) {
                    if(reader.LocalName != "statuses" &&
                       reader.LocalName != "status" &&
                       reader.LocalName != "user" &&
                       reader.IsStartElement()) {
                        switch(reader.LocalName) {
                            case "created_at":
                                status.Created = reader.ReadString();
                                break;
                            case "id":
                                //Add validation for status_id or user_id
                                if(status.StatusId == null) {
                                	status.StatusId = reader.ReadString();
                                } else {
                                    status.User.Id = reader.ReadString();
                                }
                                break;
                            case "text":
                                status.Text = reader.ReadString();
                                break;
                            case "source":
                                status.Source = reader.ReadString();
                                break;
                            case "truncated":
                                status.Truncated = (reader.ReadString() == "true") ? true : false;
                                break;
                            case "in_reply_to":
                                status.InReplyTo = reader.ReadString();
                                break;
                            case "in_reply_to_user_id":
                                status.InReplyToUserId = reader.ReadString();
                                break;
                                //user stuff
                            case "name":
                                status.User.Name = reader.ReadString();
                                break;
                            case "screen_name":
                                status.User.ScreenName = reader.ReadString();
                                break;
                            case "location":
                                status.User.Location = reader.ReadString();
                                break;
                            case "description":
                                status.User.Description = reader.ReadString();
                                break;
                            case "profile_image_url":
                                status.User.ProfileImageUrl = reader.ReadString();
                                break;
                            case "url":
                                status.User.Url = reader.ReadString();
                                break;
                            case "protected":
                                status.User.UpdatesProtected = (reader.ReadString() == "true") ? true : false;
                                break;
                            case "followers_count":
                                status.User.FollowersCount = int.Parse(reader.ReadString());
                                break;
                            default:
                                throw new System.Exception(String.Format("ERROR: Element {0} is not taken",
                                                            reader.LocalName));
                        }
                    }

                    if(reader.LocalName == "status") {
                        statuses.Add(status);
                        status = null;
                        status = new Status();
                        status.User = new User();
                    }
                }
            }

            return (Status[])(statuses.ToArray(typeof(Status)));
        }
        
        //FIXME: I don't really know if this need to be added, it looks
        // redundant for me but helpful
        /// <summary>
        /// Get a status object from a XML string
        /// </summary>
        /// <param name="xml">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="Status"/>
        /// </returns>
        public static Status GetStatusObject(string xml)
        {
            Status status = new Status();
            status.User = new User();

            XmlTextReader reader = new XmlTextReader(new StringReader(xml));

            while(reader.Read()) {
                if(reader.NodeType == XmlNodeType.Element) {
                    if(reader.LocalName != "statuses" &&
                       reader.LocalName != "status" &&
                       reader.LocalName != "user" &&
                       reader.IsStartElement()) {
                        switch(reader.LocalName) {
                            case "created_at":
                                status.Created = reader.ReadString();
                                break;
                            case "id":
                                //Validation for status_id or user_id
                                if(status.StatusId == null) {
                                    status.StatusId = reader.ReadString();
                                } else {
                                    status.User.Id = reader.ReadString();
                                }
                                break;
                            case "text":
                                status.Text = reader.ReadString();
                                break;
                            case "source":
                                status.Source = reader.ReadString();
                                break;
                            case "truncated":
                                status.Truncated = (reader.ReadString() == "true") ? true : false;
                                break;
                            case "in_reply_to":
                                status.InReplyTo = reader.ReadString();
                                break;
                            case "in_reply_to_user_id":
                                status.InReplyToUserId = reader.ReadString();
                                break;
                                //User data
                            case "name":
                                status.User.Name = reader.ReadString();
                                break;
                            case "screen_name":
                                status.User.ScreenName = reader.ReadString();
                                break;
                            case "location":
                                status.User.Location = reader.ReadString();
                                break;
                            case "description":
                                status.User.Description = reader.ReadString();
                                break;
                            case "profile_image_url":
                                status.User.ProfileImageUrl = reader.ReadString();
                                break;
                            case "url":
                                status.User.Url = reader.ReadString();
                                break;
                            case "protected":
                                status.User.UpdatesProtected = (reader.ReadString() == "true") ? true : false;
                                break;
                            case "followers_count":
                                status.User.FollowersCount = int.Parse(reader.ReadString());
                                break;
                            default:
                                throw new System.Exception(String.Format("ERROR: Element {0} is not taken",
                                                            reader.LocalName));
                        }
                    }
                }
            }

            return status;
        }
    }
}
