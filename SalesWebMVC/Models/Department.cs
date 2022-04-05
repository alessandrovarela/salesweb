using System;
namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Department()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

