﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LMSV1.Models;

/*
 This class contains the necesssary information about each course that will be created
and submit it into the database for storage
 */
public class CourseCreation 
{    
    [Required]
    public int ID { get; set; }  // Primary key

    [Required(ErrorMessage = "Course ID is required.")]
    [Display(Name = "Course ID")]
    public required string CourseID { get; set; }

    [Required(ErrorMessage = "Course Name is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Course name must be between 6 and 100 characters.")]
    [Display(Name = "Course Name")]
    public required string CourseName { get; set; }

    [Required(ErrorMessage = "Credit hours is required.")]
    [Display(Name = "Credit Hours")]
    public required string CreditHours { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    [Display(Name = "Location")]
    public required string Location { get; set; }

    [Required(ErrorMessage = "Meeting times is required.")]
    [Display(Name = "Meet Times")]
    public required string MeetDays { get; set; }

    [Required(ErrorMessage = "Start and End time is required.")]
    [Display(Name = "Start and End Times")]
    public required string StartEndTimes { get; set; }

}