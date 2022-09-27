namespace doctorsAPI.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Position { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Place { get; set; }

    }
}
