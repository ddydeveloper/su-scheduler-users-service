using System;

namespace SuSchedulerUsers.Dtos
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime Created { get; set; }
        
        public Position Position { get; set; }
        
        public Company Company { get; set; }
    }
}