using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Diagnostics.Contracts;
namespace WpfMDS1
{
    // Student is a simple class that stores a name and an
    // IsEnrolled value.
    public class Student
    {
        // The default constructor is required for creation from XAML.
        public Student()
        {
        }

        // The StudentName property is a string that holds the first and last name.
        public string StudentName { get; set; }

        // The IsEnrolled property gets or sets a value indicating whether
        // the student is currently enrolled.
        public bool IsEnrolled { get; set; }


        public bool test (Student pSt)
        {
            Contract.Requires(pSt != null);
            return false;
        }
    }

    // The StudentList collection is declared for convenience,
    // because declaring generic types in XAML is inconvenient.
    public class StudentList : ObservableCollection<Student>
    {

    }
}
