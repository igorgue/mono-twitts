//
// Main.cs
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

using MonoTwitts.Ui;

namespace MonoTwitts
{
    class MainClass
    {   
        public static void Main(string[] args)
        {
            //TwitterObjectCalls.Update("igorgue", "igf123", "Test test test2");
//            Status[] statusArray = TwitterObjectCalls.GetUserTimeline("igorgue", "igf123");
//            
//            System.Console.WriteLine(String.Format("Number of Twitts: {0}", statusArray.Length));
//            foreach (Status st in statusArray) {
//                if(!string.IsNullOrEmpty(st.StatusId)) {
//                    System.Console.WriteLine("User: {0}\nWeb: {1}\nText: {2}", st.User.Id, st.User.Url, st.Text);
//                    System.Console.WriteLine("*********************");	
//                }
//            }
            Application.Init();
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowAll();
            
            Application.Run();
        }
    }
}