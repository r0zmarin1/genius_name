namespace genius_name.Model
{
    public class Passport
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }
        public DateTime DataGetPassport { get; set; }
        public  string Organization { get; set; }
        public string Serial {  get; set; }
        public int Number { get; set; }
        public string Gender { get; set; }
    }
}
