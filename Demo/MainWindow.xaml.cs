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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Purpose : This class is used to create main form and link control on the form to approriate event handlers.
    ///           It is also used to add "Student" objects on to the "student_List" in "ModuleList" class using its "store"object.
    ///           It further uses  "Class_Record2 object of "Class_List" class to display show all student records by opening new window.
    /// Date modified : 22-10-2017
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private ModuleList store = new ModuleList();         // creates an private object of "ModuleList" class to access its data memebrs
        int search_Number;                                   // "searcht_Number" variale of type inetger used to store the search number find/delete event handlers
        private  int auto_Matric = 10000;                     // private variable "auto_Matric" used to provide auto incremented value for "matric_No" in student class


        public MainWindow()
        {
            InitializeComponent();

        }

        private void bt_Add_Click(object sender, RoutedEventArgs e)
        {
            Student S1 = new Student();

            try                                                          // try used to handle any exception which may occur at run-time in the code in its block
            {
                S1.pFirst_Name = tb_Fname.Text;                          // assigns value entered by the user in "tb_Fname" textbox to private "first_Name" of "Student" variable class using its property
                S1.pSur_Name = tb_Sname.Text;                            // assigns value entered by the user in "tb_Sname" textbox to private "sur_Name" of "Student" variable class using its property
                S1.pCoursework_Mark = double.Parse(tb_CwMark.Text);      // converts value enterd by the user in "tb_CwMark" textbox to double and assign it to private "coursework_Mark" variable of "Student" class using its property
                S1.pExam_Mark = double.Parse(tb_ExamMark.Text);          // converts value enterd by the user in "tb_ExamMark" textbox to double and assign it to private "exam_Mark" variable of "Student" class using its property
                S1.pPercent = S1.getMark();                              // assigns calculated value to private "percent" variable of "Student" class using private method "getMark" used to calculate overall percentage of coursework and exam
                S1.pDob = dp_Dob.SelectedDate.Value;

                S1.pMatric = ++auto_Matric;                              // assigns auto incremented value to private "matric_No" of student class using its property

                store.add(S1);                                          // stores student object/instance of "Student" class onto "student_List" of "ModuleList" class using its "store" instance and "add" method
                lbox_StudentRecord.Items.Add(S1.pMatric);               // add matriculation number to the "StudentRecord" list-box on the form

                clearForm();                                            // calls clearForm Method too clear the form
                MessageBox.Show("Student " + S1.pFirst_Name + " " + S1.pSur_Name + " succesfully enrolled and assigned " + S1.pMatric + " as matriculation number.", "Message", MessageBoxButton.OK); // Message box to display confirmation mehod that student is added to list
            }

            catch (ArgumentNullException)                               // Catch block to catch Argument null Exception used to handle exception when no input is entered to first/sur name textboxes
            {
                MessageBox.Show("First/Sur name fields cannot be blank or white spaces.","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);                  // Messagebox display error message
            }

            catch (FormatException)                                     // Catch block to catch FormatException used to handle exceptions wrong data type(non double) value is enterd into to coursework/exam marks textboxes
            {
                MessageBox.Show("Coursework/Exam mark fields cannot be blank or non-numeric.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);             // Messagebox display error message
            }

            catch (ArgumentOutOfRangeException)                         // Catch block to catch Argument out of range exception used to handle exceptions when input value is not within the range specified in the coursework/exam marks properties
            {
                MessageBox.Show("Coursework marks must be in range the of 0-20.\n\n Exam Marks must be in range of 0-40.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);      // Messagebox display error message
            }

            catch (Exception)                                           // Catch block to catch any unhandled exceptions in above catch blocks in our case also used to handle exceptions for "d.o.b"
            {
                MessageBox.Show("D.O.B field can not be blank.\nPlease select a date.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);                     // Messagebox display error message
            }

        }

        /*#########################
         * "bt_Find_Click" event is used to find student/object of "Student" class from the "student_List" 
         * in "Module_List" class using "find" method of "ModuleList" class which is accessed with its instance called "store"
         *########################*/

        private void bt_Find_Click(object sender, RoutedEventArgs e)
        {

            try                         // try used to handle any exception which may occur at run-time
            {
                search_Number = int.Parse(tb_MatricNo.Text);        // converting string/text from the text box to integer type
                if (store.find(search_Number) != null)             // "find" method of modulelist class used inside if condition to find out it returns null or not
                {                                                  // which executes if block only if specified search number matches matricnumber in list

                    Student found_result = store.find(search_Number);           // creates new instance of student class in if block and store returned instance in "result"

                    lb_Display_Found_deatils.Content = "Matriculation no.  : " + found_result.pMatric.ToString() +                                   // lb_Display_Found_deatils label display matriculation number on form by converting search record to string
                                                      "\nFirst name             :  " + found_result.pFirst_Name +                          // same  label used to display First name obtained from result object on form using pFirst_Name Property
                                                      "\nSur name              :  " + found_result.pSur_Name +                             // same  label used to display Sur name obtained from result object on form using pSur_Name Property
                                                      "\nD.o.b                     :  " + found_result.pDob.ToString("dd/mm/yyyy") +       // same  label used to display date of birth on form obtained from result object using date picker
                                                      "\nCoursework mark  :  " + found_result.pCoursework_Mark.ToString() +                // same  label used to display Course work marks on form by converting them to string
                                                      "\nExam mark            :  " + found_result.pExam_Mark.ToString() +                  // same  label used to display Exam marks on form by converting them to string
                                                      "\nTotal Percentage   :  " + found_result.pPercent.ToString() + "%";                 // same  label used to display total percentage scored in both both coursework and exam on form by converting them to string
                  
                }
                else                                       // else block executed if "find" method return find no student records associated with "searchnumber" 
                {
                    MessageBox.Show("No such record exist. \nEnter a valid number in the range of 10001-50000", "Message", MessageBoxButton.OK);      // message box dsplays error and  message to enter valid searchnumber
                }

            }
            catch (FormatException)                            // catches exception if non numeric value entered in the search box
            {

                MessageBox.Show("Invalid input. \nInput must be a number in the range of 10001-50000 range.", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);      // message box dsplays error and  message to enter valid searchnumber
            }

        }


        /*#########################
         * Clear_Form method used to clear text boxes and  labels  on the form 
         *########################*/

        public void clearForm()
        {

            lb_Matric_Display.Content = "Auto generated";     // display"Auto generated" on lb_Matric_Display label on form
            tb_Fname.Clear();                   // clears tb_Fname text box on form
            tb_Sname.Clear();                   // clears tb_Sname text box on form
            tb_CwMark.Clear();                  // clears tb_CwMark text box on form
            tb_ExamMark.Clear();                // clears tb_ExamMark text box on form
            dp_Dob.SelectedDate = null;         // clears dp_Dob date picker on form
            lb_Display_Found_deatils.Content = "";  // clears lb_Display_Found_deatils label

        }


        /*#########################
         * This is an event handler for "Delete" button. It is called when delete button is pressed on the form
         * It uses nuber eneterd by user in the matriculation text box to first find if an object associacted with 
         * that matriculation exist in the list or not?
         * if it doesnot exist then it shows error using the message box associated with text box 
         * otherwise it deletes that object from the list and confirm it using a message box detailing which object has been deleted. 
         * It also clears the form and delete entry from the list-box on the form which displays all the matriculation numbers.
         *########################*/
        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {

            try                                                      // try used to handle any exception which may occur at run-time
            {
                search_Number = int.Parse(tb_MatricNo.Text);        // converting string/text from the text box to integer type and store it in "searchNumber"
                MessageBoxResult confirmDelete = MessageBox.Show("Are you sure you want to delete student with "+search_Number+ " matriculation number from list ?", "Warning", MessageBoxButton.YesNo);                                    // creates a new instance of MessageVoxResult to store "Yes/No" respose of user
                                                                         // Displays message box to user with  message and waits for user to respond in yes/no
                if (confirmDelete == MessageBoxResult.Yes)              // if confition checks if user response was "Yes" to the "confirmDelete" MessageBoxResult
                {


                    if (store.delete(search_Number) == true)            // nested if statement calls "delete" method of "ModuleList" class and checks if it returned                                                    true or false
                    {
                        clearForm();                                    // if condition is true then excecute this code block and clear form
                        lbox_StudentRecord.Items.Remove(search_Number);  // removes matriculation number from the "StudentRecord" list-box on the form
                        MessageBox.Show("Student with " + search_Number + " matriculation number is successfully deleted from list."); // Message box display                                                                                                                                       confrimation message that matched record has been deleted from the "student_List"
                    }
                    else                                                 // nested else block gets executed only if "delete" method returns false
                    {
                        MessageBox.Show("No such record exist \nEnter a valid number in range of 10001-50000,");  //Message box  display error message

                    }
                }
                else                                              // main else block only gets executed if user respose is NO to the "confirmDelete" MessageBoxResult
                {
                    MessageBox.Show("Deletion operation is cancelled.");                    // Message box displays cancelletion message
                }

            }
            catch (FormatException)                             // catches exception if non numeric value entered in the search box
            {

                MessageBox.Show("Invalid input.\nInput must be a number in the range 10001 and 50000.");       // message box dsplays error 
            }



        }


        /*#########################
         * "lbox_StudentRecord_MouseDoubleClick" is event handler for listbox. It is used to display the details related  
         * to the matriculation number from the listbox to the main form.
         * It also uses "find" method to first search the object related to the selected matricultion number from the listbox 
         * and then display details associated with that number on the main form.
         *#########################*/

        private void lbox_StudentRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbox_StudentRecord.SelectedValue == null)
            {
                MessageBox.Show("No value Selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int selected_Number = (int)lbox_StudentRecord.SelectedValue;          // converting string/text from the list_box to integer type and store it in "selectedNumber"

                Student found_result = store.find(selected_Number);                // creates new instance of student class in if block and store returned instance in "result"

                lb_Display_Found_deatils.Content = "Matriculation no.  : " + found_result.pMatric.ToString() +                                   // lb_Display_Found_deatils label display matriculation number on form by converting search record to string
                                                            "\nFirst name             :  " + found_result.pFirst_Name +                          // same  label used to display First name obtained from                                                                                                  result object on form using pFirst_Name Property
                                                            "\nSur name              :  " + found_result.pSur_Name +                             // same  label used to display Sur name obtained from                                                                                                    result object on form using pSur_Name Property
                                                            "\nD.o.b                     :  " + found_result.pDob.ToString("dd/mm/yyyy") +       // same  label used to display date of birth on form                                                                                                     obtained from result object using date picker
                                                            "\nCoursework mark  :  " + found_result.pCoursework_Mark.ToString() +                // same  label used to display Course work marks on form by                                                                                              converting them to string
                                                            "\nExam mark            :  " + found_result.pExam_Mark.ToString() +                  // same  label used to display Exam marks on form by                                                                                                      converting them to string
                                                            "\nTotal Percentage   :  " + found_result.pPercent.ToString() + "%";                 // same  label used to display total percentage scored in                                                                                     both both coursework and exam on form by converting them to string
            }
        }


        /*#########################
         * bt_ShowAll_Click is an event handler for the "Show All" button on the form which is used list all the 
         * added records/objects onto the "student_list" by opening a new window.
         *#########################*/
        private void bt_ShowAll_Click(object sender, RoutedEventArgs e)
        {
            ClassList Class_Record = new ClassList();       // crates an instance of "ClassList" class 

            Class_Record.Show();                            // "Show" method used to open new window for "Class_Recors" instance of 
                                                            // "Class_List" class  to show all students details

        }


        /*#########################
        * bt_Clear_Click is an event handler for the "Clear" button on the form which is used clear the 
        * form.
        *#########################*/
        private void bt_Clear_Click(object sender, RoutedEventArgs e)
        {
            clearForm();                                    // call "clearForm method to clear form
                
        }
    }
}
