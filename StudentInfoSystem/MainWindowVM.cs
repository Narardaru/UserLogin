using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using StudentInfoSystem;
using UserLogin;

namespace StudentInfoSystem
{
    class MainWindowVM : ObservableBase
    {
        private Student _student;
        public Student Student
        {
            get { return _student; }
            set { _student = value; RaisePropertyChangedEvent("Student"); }
        }

        private bool _canEditProperty = true;
        public bool CanEditProperty
        {
            get { return _canEditProperty; }
            set { _canEditProperty = value; RaisePropertyChangedEvent("CanEditProperty"); }
        }

        public MainWindowVM(Student student, MainWindow main)
        {
            if (student == null)
            {
                student = new Student();
                main = new MainWindow();
            }
            Student = student;
            LoadStudentData(main);
        }

        public ICommand LoadStudentDataCommand
        {
            get { return new RelayCommand(LoadStudentData); }
        }

        private void LoadStudentData(MainWindow main)
        {
                main.txtFirstName.Text = Student.FirstName;
                main.txtMiddleName.Text = Student.MiddleName;
                main.txtLast.Text = Student.LastName;
                main.txtFaculty.Text = Student.Faculty;
                main.txtSpecialty.Text = Student.Specialty;
                main.txtDegree.Text = Student.Degree;
                main.txtStatus.ItemsSource = main.StudStatusChoices;
                main.txtCourse.Text = Student.Course.ToString();
                main.txtStream.Text = Student.Stream.ToString();
                main.txtGroup.Text = Student.Group.ToString();
                main.txtFacultyNumber.Text = Student.FacultyNumber.ToString();
        }

        public ICommand ClearStudentDataCommand
        {
            get { return new RelayCommand(ClearStudentData); }
        }

        private void ClearStudentData()
        {
            Student = new Student();
        }

        public ICommand DeactivateEditingCommand
        {
            get { return new RelayCommand(DeactivateEditing); }
        }

        private void DeactivateEditing()
        {
            CanEditProperty = false;
        }

        public ICommand ActivateEditingCommand
        {
            get { return new RelayCommand(ActivateEditing); }
        }

        private void ActivateEditing()
        {
            CanEditProperty = true;
        }
    }
}
