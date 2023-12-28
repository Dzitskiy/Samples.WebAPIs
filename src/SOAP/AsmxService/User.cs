namespace AsmxService
{
    [System.Serializable]
    public class User
    {
        private int _operationResult;
        private string _fullName;

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                _fullName = $"{FirstName} {MiddleName} {LastName}";               
                return _fullName;
             }
            
            set 
            { 
                _fullName = value; 
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public int SomeImportantAndPrivateOperation
        {
            get { return _operationResult; }
            set { _operationResult = value; }
        }

        public User() { }

        public User(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}