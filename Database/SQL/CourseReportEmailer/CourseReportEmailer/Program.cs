using CourseReportEmailer.Models;
using CourseReportEmailer.Repository;
using CourseReportEmailer.Workers;
using System;
using System.Collections.Generic;

namespace CourseReportEmailer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EnrollmentDetailReportCommand command = new EnrollmentDetailReportCommand(@"Data Source=localhost;Initial Catalog=CourseReport;Integrated Security=True");
                IList<EnrollmentDetailReportModel> enrollments = command.GetList();

                var reportFileName = "EnrollmentDetailReports.xlsx";
                EnrollmentDetailReportSpreadSheetCreator enrollmentSheetCreator = new EnrollmentDetailReportSpreadSheetCreator();
                enrollmentSheetCreator.Create(reportFileName, enrollments);

                EnrollmentDetailReportEmailSender emailer = new EnrollmentDetailReportEmailSender();
                emailer.Send(reportFileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong: {0}", ex.Message);
            }
        }
    }
}
