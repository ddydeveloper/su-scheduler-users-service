using System;

namespace SuSchedulerUsers.Dtos
{
    public class Company
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Created { get; set; }
    }
}