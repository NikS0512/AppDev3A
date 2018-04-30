using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StudApp_AppDev.Models
{
    public class Student
    {
        [Key]
        [JsonProperty(PropertyName = "studentNumber")]
        //[Required(ErrorMessage = "Student number required.")]
        //[Display(Name = "Student Number")]
        //[StringLength(8)]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        //[Required(ErrorMessage = "Student's first name rrquired.")]
        //[Display(Name = "First Name")]
        public string FName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        //[Required(ErrorMessage = "Student's last name required.")]
        //[Display(Name = "Last Name")]
        public string LName { get; set; }

        [JsonProperty(PropertyName = "email")]
        //[Required(ErrorMessage = "Student's email required.")]
        //[EmailAddress(ErrorMessage = "Email is not valid.")]
        //[Display(Name = "Email")]
        public string Stud_Email { get; set; }

        [JsonProperty(PropertyName = "telephone")]
        //[Required(ErrorMessage = "Student's telephone number required.")]
        //[Display(Name = "Telephone Number")]
        //[StringLength(10)]
        public string Tel_No { get; set; }

        [JsonProperty(PropertyName = "mobile")]
        //[Required(ErrorMessage = "Student's mobile number required.")]
        //[Display(Name = "Mobile Number")]
        //[StringLength(10)]
        public string Mobile_No { get; set; }

        [JsonProperty(PropertyName = "isValid")]
        //[Required(ErrorMessage = "Please select student's status.")]
        //[Display(Name = "Active Status")]
        public bool Stud_Valid { get; set; }
    }
}