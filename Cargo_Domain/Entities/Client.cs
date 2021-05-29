using System;
using System.Collections.Generic;
using System.Globalization;
using Cargo_Domain.Interfaces;

namespace Cargo_Domain.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }


        public DateTime _dateOfBirth;
        public string DateOfBirth
        {
            get => _dateOfBirth.ToString("yyyy.MM.dd");
            set
            {
                if (value != null)
                {
                    try
                    {
                        _dateOfBirth = DateTime.ParseExact(value.Split(' ')[0], "MM/dd/yyyy", null);
                    }
                    catch (Exception e)
                    {
                        _dateOfBirth = DateTime.ParseExact(value.Split(' ')[0], "dd/MM/yyyy", null);
                    }
                }
            }
        }


        public DateTime _registrationDate;
        public string RegistrationDate
        {
            get => _registrationDate.ToString("yyyy.MM.dd");
            set
            {
                if (value != null)
                {
                    try
                    {
                        _registrationDate = DateTime.ParseExact(value.Split(' ')[0], "MM/dd/yyyy", null);
                    }
                    catch (Exception e)
                    {
                        _registrationDate = DateTime.ParseExact(value.Split(' ')[0], "dd/MM/yyyy", null);
                    }
                }
            }
        }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CountOfOrders { get; set; }

        public ICollection<Cargo> Cargos { get; set; }
    }
}