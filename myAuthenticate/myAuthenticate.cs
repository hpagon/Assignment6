using System;
using System.IO;
using System.Xml;
using PasswordLibrary;

namespace myAuthenticate
{
    public class MyAuthenticate
    {
        public bool myAuthenticate(string usernameInfo, string passwordInfo, string file)
        {
            // Hash the provided password
            string username = usernameInfo;
            string password = PasswordLibrary.PasswordHasher.HashPassword(passwordInfo);
            string filePath = file;

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file '{filePath}' does not exist."); // Detailed error message
                }

                using (FileStream FS = new FileStream(filePath, FileMode.Open))
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load(FS);
                    XmlNodeList children = xd.DocumentElement.ChildNodes;

                    foreach (XmlNode child in children)
                    {
                        if (child.Name == "User")
                        {
                            string childUsername = child["Username"]?.InnerText;
                            string childPassword = child["Password"]?.InnerText;

                            // Check if username and password match
                            if (username == childUsername && password == childPassword)
                            {
                                return true; // Match found
                            }
                        }
                    }
                }

                return false; // No matches found after iterating through all users
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading file", ex);
            }
        }
    }
}
