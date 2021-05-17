using System;

namespace FreightTransport_BLL.DTOs
{
    public class DriverSalaryInformationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int Experience { get; set; }
        public double Salary { get; set; }
    }
}