using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects

/// <summary>
/// Purpose : This class is used to store attributes of students to be added to the list in modulelist class.
///           All the attributes are private which are accessed and set using their properties.
///           It also has a getMark method which calculates the combined percentage obtained in exam and coursework.
/// Date modified : 22-10-2017
/// </summary>           
{
    public class Student
    {
        private int matric_No;              // private variable "matric_no" of type integer stores matriculation number assigned to student       
        private string first_Name;          // private variable "first_Name" of type string stores first name of  student 
        private string sur_Name;            // private variable "sur_Name" of type string stores sur name of  student 
        private double coursework_Mark;     // private variable "coursework_Mark" of type double stores marks obtained in coursework by student 
        private double exam_Mark;           // private variable "exam" of type double stores marks obtained in exam by student 
        private DateTime dob;               // private variable "dob" of type datetime stores date of birth of student
        private double percent;             // private variable "percent" of type double stores overall % of marks obtained in both exam and course work
      
 

        /*#########################
         * "Matric" property used to access (get) and set value to the private "matric_No" variable
         *#########################*/

        public int pMatric
        {
            get                                 
            {
                return matric_No;
            }
            set                                        // set block used to set value of private matric_No variable
            {
              matric_No = value;                     //  assigned value to private matric_No variable
            }
        }


        /*#########################
         * "First_Name"  property used to access and set value to the private "first_Name" variable 
         *#########################*/

        public string pFirst_Name
        {
            get                                         // used to get value of private First_name variable
            {
                return first_Name;                      // returns first_name
            }
            set                                         // set block used to set value of private First_name variable
            {
                if (string.IsNullOrWhiteSpace(value))   // if statement check if value assigned to property is null or while space
                {
                    throw new ArgumentNullException();  // if value is null or white space it throws exception which is catched in Main window's catch block to display error message
                }
                
                first_Name = value;                 // if no exception occurs value gets assigned to private first_name variable
      
            }

        }


        /*##########################
         * "First_Name"  property used to access and set value to the private "first_Name" variable 
         *##########################*/
        public string pSur_Name
        {
            get                                                  // used to get value of private Surt_name variable
            {
                return sur_Name;                                 // returns first_name
            }
            set                                                  // set block used to set value of private Sur_name variable
            {
                if (string.IsNullOrWhiteSpace(value))            // if statement check if value assigned to property is null or while space
                {
                    throw new ArgumentNullException();           // if value is null or white space it throws exception which is catched in Main window's catch block to display error message
                }

                sur_Name = value;                            // if no exception occurs value gets assigned to private Sur_name variable
            
            }
        }


        /* #################################### 
         * "Coursework_Mark"  property used to access and set value to the private "coursework_Mark" variable
         *  ###################################*/

        public double pCoursework_Mark
        {
            get 
            {
                return coursework_Mark;                          // returns coursework_Mark_name
            }

            set
            {
                if (value < 0 || value > 20)                    // if statement checks if value is less than 0 or greater than 20 
                {
                    throw new ArgumentOutOfRangeException();    // if condition is true than throws exception which is catched in Main window's catch block to display error message
                }

                coursework_Mark = value;                        // if no exception occurs value gets assigned to private coursework_Mark variable
              
            }
        }


        /* #################################### 
        * "Coursework_Mark"  property used to access and set value to the private "coursework_Mark" variable
        *  ###################################*/

        public double pExam_Mark
        {
            get 
            {
                return exam_Mark;                             // returns coursework_Mark_name
            }

            set
            {
                if (value < 0 || value > 40)                  // if statement checks if value is less than 0 or greater than 40 
                {
                    throw new ArgumentOutOfRangeException();  // if condition is true than throws exception which is catched in Main window's catch block to display error message
                }

                exam_Mark = value;                            // if no exception occurs value gets assigned to private exam_Mark variable
                
            }
        }


        /* #################################### 
        * "pPercent"  property used to access and set value to the private "percent" variable
        *  ###################################*/

        public double pPercent
        {
            get
            {
                return percent;                     // returns percent
            }
            set
            {
                percent = value;                    // assigns value to private "percent" variable
            }
        }


        /* ####################################
         * "pDob"  property used to access and set value to the private "dob" variable
         * ###################################*/
        public DateTime pDob            
        {
            get 
            {
                return dob.Date ; 
            }

            set
            {
                try                         // try block checks if any exceptions occurs in the block code
                {
                    dob = value;            // assigns value to private variable "dob"
                }
                catch (Exception)           // catch block to catch any exceptions which may occur in try block
                {
                    throw new Exception();  // if exception occurs than throws exception which is catched in Main window's catch block to display error message
                }
                
            }
        }



         /*####################################
         * getMark() method used to calculate the overall result in percentage using coursework_Mark and exam_Mark
         * It returns calculated combined percentage as double data type.
         * ###################################*/

        public double getMark()
        {
           double perCW = coursework_Mark * (100.0 / 20.0);     // variable "perCW" of double type h stores calculated % of marks obtained in course work
           double perExam = exam_Mark * (100.0 / 40.0);         // variable "perExam" of double type stores calculated % of marks obtained in exam
           double combined_Percent = (perCW + perExam) / 2;     // variable "combined_Percentage" of double type which stores overall % of marks obtained in both exam and course work
           return combined_Percent;                             // returns "combined_Percentage"
           
        }    
    }
}
