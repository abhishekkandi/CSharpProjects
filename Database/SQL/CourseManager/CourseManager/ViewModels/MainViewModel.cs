using Caliburn.Micro;
using CourseManager.Models;
using CourseManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.ViewModels
{
    class MainViewModel : Screen
    {
        private BindableCollection<EnrollmentModel> _enrollments = new BindableCollection<EnrollmentModel>();
        private BindableCollection<StudentModel> _students = new BindableCollection<StudentModel>();
        private BindableCollection<CourseModel> _courses = new BindableCollection<CourseModel>();
        private EnrollmentModel _selectedEnrollment;
        private string _appStatus;
        private readonly string _connectionString = @"Data Source=localhost;Initial Catalog=CourseReport;Integrated Security=True";
        private EnrollmentCommand _enrollmentCommand;

        public MainViewModel()
        {
            SelectedEnrollment = _selectedEnrollment;

            try
            {
                _enrollmentCommand = new EnrollmentCommand(_connectionString);
                Enrollments.AddRange(_enrollmentCommand.GetList());

                StudentCommand studentCommand = new StudentCommand(_connectionString);
                Students.AddRange(studentCommand.GetList());

                CourseCommand courseCommand = new CourseCommand(_connectionString);
                Courses.AddRange(courseCommand.GetList());
            }
            catch(Exception ex)
            {
                UpdateAppStatus(ex.Message);
            }
        }

        public StudentModel SelectedEnrollmentStudent
        {
            get
            {
                try
                {
                    var studentDictionary = _students.ToDictionary(x => x.StudentId);

                    if (SelectedEnrollment != null && studentDictionary.ContainsKey(SelectedEnrollment.StudentId))
                    {
                        return studentDictionary[SelectedEnrollment.StudentId];
                    }
                }
                catch (Exception ex)
                {
                    UpdateAppStatus(ex.Message);
                }

                return null;
            }
            set
            {
                try
                {
                    var selectedErollmentStudent = value;

                    SelectedEnrollment.StudentId = selectedErollmentStudent.StudentId;

                    NotifyOfPropertyChange(() => SelectedEnrollment);
                }
                catch (Exception ex)
                {
                    UpdateAppStatus(ex.Message);
                }
            }
        }

        public CourseModel SelectedEnrollmentCourse
        {
            get
            {
                try
                {
                    var courseDictionary = _courses.ToDictionary(x => x.CourseId);

                    if(SelectedEnrollment != null && courseDictionary.ContainsKey(SelectedEnrollment.CourseId))
                    {
                        return courseDictionary[SelectedEnrollment.CourseId];
                    }
                }
                catch(Exception ex)
                {
                    UpdateAppStatus(ex.Message);
                }

                return null;
            }
            set
            {
                try
                {
                    var selectedErollmentCourse = value;

                    SelectedEnrollment.CourseId = selectedErollmentCourse.CourseId;

                    NotifyOfPropertyChange(() => SelectedEnrollment);
                }
                catch(Exception ex)
                {
                    UpdateAppStatus(ex.Message);
                }
            }
        }

        public BindableCollection<EnrollmentModel> Enrollments
        {
            get { return _enrollments; }
            set { _enrollments = value; }
        }

        public BindableCollection<CourseModel> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        public BindableCollection<StudentModel> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public string AppStatus
        {
            get { return _appStatus; }
            set { _appStatus = value; }
        }

        public EnrollmentModel SelectedEnrollment
        {
            get
            {
                return _selectedEnrollment;
            }
            set
            {
                _selectedEnrollment = value;
                NotifyOfPropertyChange(() => SelectedEnrollment);
                NotifyOfPropertyChange(() => SelectedEnrollmentCourse);
                NotifyOfPropertyChange(() => SelectedEnrollmentStudent);
            }
        }

        private void UpdateAppStatus(string message)
        {
            AppStatus = message;
            NotifyOfPropertyChange(() => AppStatus);
        }

        public void CreateNewEnrollment()
        {
            try
            {
                SelectedEnrollment = new EnrollmentModel();
                UpdateAppStatus("New enrollment created.");
            }
            catch(Exception ex)
            {
                UpdateAppStatus(ex.Message);
            }
        }

        public void SaveEnrollment()
        {
            try
            {
                var enrollmentDictionary = _enrollments.ToDictionary(x => x.EnrollmentId);

                if(SelectedEnrollment != null)
                {
                    _enrollmentCommand.Upsert(SelectedEnrollment);

                    Enrollments.Clear();
                    Enrollments.AddRange(_enrollmentCommand.GetList());

                    UpdateAppStatus("Enrollment Saved");
                }
            }
            catch (Exception ex)
            {
                UpdateAppStatus(ex.Message);
            }
        }
    }
}
