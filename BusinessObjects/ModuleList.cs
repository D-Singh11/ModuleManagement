using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects

/// <summary>
/// Purpose : This class  stores a private list  of students  added to it in MainWindow class and list is accessed  using its property.
/// It also has 3 methods - 
///                         "add" method  used to add a student object/record to "student_List"
///                         "find" method used to find a student object/record in the "student_List"
///                         "delete" method used to delete a student object/record from the "student_List".
/// Date modified : 22-10-2017
/// </summary>
{
    public class ModuleList

    {
        private static List<Student> student_List = new List<Student>();       // private list "syudent_List" to store objects/instances of student class




        public void add(Student newStudent)                 // add method which takes one argument of type Student
        {                                                   //  and add instance of student class on "student_list" list 
            student_List.Add(newStudent);                   //  calls pre-wriiten "Add" method of "List" class  
        }

        public List<Student> pShowStudentList              // "pShowStudentList" property used to access (get) the private "StudentList" list in another class
        {
            get { return student_List; }                   // get block returns the "student_List"

        }


        /*#########################
         * "find" method which takes one argument of integer type to check if number passed as argument matches 
         * with any of the student record in "student_List".if match found it returns object associated with it 
         * otherwise return null.
         *#########################*/

        public Student find(int matric)
        {
            foreach (Student student in student_List)            // foreach loop used to iterate through the "student_List" 
            {
                if (matric == student.pMatric)                  // if condition checks if number passes as argument to find method matches with any of the matriculation number in list
                {
                    return student;                             // if condition is true than return student object
                }
               
            }

            return null;                                        // otherwise return null if no matriculation number matches with argument passed to find method

        }


        /*#########################
         * "delete" method which takes one argument of integer type to check if number passed as argument matches 
         * with any of the student record in "student_List". if match found it remove object associated with it and returns true
         * otherwise return false.
         *#########################*/

        public bool delete(int matric)
        {
            Student student = this.find(matric);                  // creates an object of "Student" class to store the object returned by the "find" method by passing it record number to be deleted
            if (student != null)                                  // if condition checks if an student object is null or not  
            {
                student_List.Remove(student);                    // if "student" object is not null means it has a Student class object in it returned by "find"                                                         method 
                                                                 // from the "student_List"and removes it from the list
                return true;                                     // returns true if matched record is deleted from the list
            }
            else                                                 
            {
                return false;                                    // othrwise return false if no record matched with the argument passed to delete method
            }

        }

        
    }
}
