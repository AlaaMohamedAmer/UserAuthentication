using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthentication
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, string email, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
        }
    }

    public class SignInManager
    {
        private List<User> users = new List<User>();

        public bool SignUp(string firstName, string lastName, string email, string username, string password)
        {
            if (users.Exists(u => u.Email == email))
            {
                Console.WriteLine("Email is already registered. Please use a different email.");
                return false;
            }

            Console.WriteLine("Sign Up Successful!");
            return true;
        }
    }

    public class LoginManager
    {
        private List<User> users = new List<User>();

        public LoginManager(List<User> users)
        {
            this.users = users;
        }

        public bool LogIn(string email, string password)
        {
            // Perform login logic, checking credentials in memory
            User user = users.Find(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                Console.WriteLine("Login Successful!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Email or Password. Please try again.");
                return false;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            SignInManager signInManager = new SignInManager();

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            signInManager.SignUp(firstName, lastName, email, username, password);

            LoginManager loginManager = new LoginManager(signInManager.GetUsers());

            Console.Write("Enter Login Email: ");
            string loginEmail = Console.ReadLine();

            Console.Write("Enter Login Password: ");
            string loginPassword = Console.ReadLine();

            loginManager.LogIn(loginEmail, loginPassword);
        }
    }
}