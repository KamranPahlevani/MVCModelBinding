using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Models
{
    public class Person
    {
        public Person()
        {
        }
        /// <summary>
        /// not display and not render hidden field that only not rendered hidden field in scaffold mode
        /// </summary>
        [ScaffoldColumn(false)]
        /// <summary>
        /// not display and but render hidden field
        /// </summary>
        [HiddenInput(DisplayValue=false)]
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Address HomeAddress { get; set; }

        [AdditionalMetadata("RenderList", "true")]
        public bool IsApproved { get; set; }

        public Role Role { get; set; }
    }

    [Bind(Exclude="Line1")]
    public class Address
    {
        [DataType(DataType.MultilineText)]
        public string Line1 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Line2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }
    }

    public enum Role
    {
        Admin,
        User,
        Guest
    }
}