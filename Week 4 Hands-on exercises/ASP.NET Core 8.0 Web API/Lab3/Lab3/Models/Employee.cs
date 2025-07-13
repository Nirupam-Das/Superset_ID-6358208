
using System;
using System.Collections.Generic;

namespace Lab3.Models;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Salary { get; set; }
    public bool Permanent { get; set; }
    public Department Department { get; set; } = default!;
    public List<Skill> Skills { get; set; } = new();
    public DateTime DateOfBirth { get; set; }
}
