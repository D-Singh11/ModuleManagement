using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for ClassList.xaml
    /// Purpose: This class is used to display the list of all students in a new window. It has an instance of "ModuleList" class 
    ///          to access the list of all student object added to "student_List" list. It uses data-grid "dg_ShowAll" to display the 
    ///          details of students in a tabular form using "student_List" as source for it.
    /// Date modified : 22-10-2017
    /// </summary>
    public partial class ClassList : Window
    {

        private ModuleList students = new ModuleList();               // creates an object of "ModuleList" class to access its data memebrs
       
        public ClassList()                                            // Auto generated constructor of "ClassList" class
        {
            InitializeComponent();

            dg_ShowAll.ItemsSource = students.pShowStudentList;       // Binds "dg_ShowAll" data-grid with its data source's "LList" property using "students"  object  
        }
        
    }
}
