using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class User
{
    // Properties to store the username and hashed password of the user
    public string Username { get; }
    public string PasswordHash { get; }

    // Constructor to initialize a new user with a username and hashed password
    public User(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }
}
