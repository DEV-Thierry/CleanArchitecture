using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public DateTime DataInclusao {get; private set;}
        public DateTime DataAlteracao {get; set;}
        public bool Ativo { get; set; }

        public User(Guid id, string firstName, string lastName, string email, string password, bool ativo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Ativo = ativo;
        }

        public void IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentNullException("Email cannot be Empty", nameof(Email));
            }
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            var isValid= Regex.IsMatch(Email, emailPattern);

            if(!isValid)
                throw new ArgumentException("Invalid Email",nameof(Email));
        }

        public static User Create(string firstName, string lastName, string email, string password){
            var user = new User(Guid.NewGuid(), firstName, lastName, email, password, true);
            user.Password = BCrypt.Net.BCrypt.HashPassword(password,10);
            user.IsValidEmail();
            user.DataInclusao = DateTime.Now;
            return user;
        }
    }
}