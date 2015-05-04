using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyHelpers
{
    public class TimeHelper
    {
        // -----------------------------------------------------------------------
        // ThisHourNow
        // -----------------------------------------------------------------------
        public static DateTime ThisHourNow()
        {
            return ThisHour(DateTime.Now);
        }

        // -----------------------------------------------------------------------
        // ThisHour
        // -----------------------------------------------------------------------
        public static DateTime ThisHour(DateTime oDateTime)
        {
            DateTime oNewDateTime = new DateTime(
                    oDateTime.Year,
                    oDateTime.Month,
                    oDateTime.Day,
                    oDateTime.Hour,
                    0,
                    0
                    );

            return oNewDateTime;
        }

        // -----------------------------------------------------------------------
        // ThisHour
        // -----------------------------------------------------------------------
        public static DateTime ThisHourTomorrow(DateTime oDateTime)
        {
            DateTime oNewDateTime = new DateTime(
                    oDateTime.Year,
                    oDateTime.Month,
                    oDateTime.Day,
                    oDateTime.Hour,
                    0,
                    0
                    );

            oNewDateTime = oNewDateTime.AddDays(1);

            return oNewDateTime;
        }

        // -----------------------------------------------------------------------
        public static DateTime GetDateFromDateTimePickers(DateTimePicker oDate, DateTimePicker oTime)
        {
            DateTime oDateTime = new DateTime(
                 oDate.Value.Year,
                 oDate.Value.Month,
                 oDate.Value.Day,
                 oTime.Value.Hour,
                 oTime.Value.Minute,
                 oTime.Value.Second);

            return oDateTime;
        }

        // -----------------------------------------------------------------------
        // GetFirstDayOfMonth
        // -----------------------------------------------------------------------
        public static int GetFirstDayOfMonth(int iMonth, int iYear)
        {
            DateTime oDateTime = new DateTime(
                    iYear,
                    iMonth,
                    1
                    );

            return oDateTime.Day;
        }

        // -----------------------------------------------------------------------
        // GetLastDayOfMonth
        // -----------------------------------------------------------------------
        public static int GetLastDayOfMonth(int iMonth, int iYear)
        {
            DateTime oDateTime = new DateTime(
                    iYear,
                    iMonth,
                    DateTime.DaysInMonth(iYear, iMonth)
                    );

            return oDateTime.Day;
        }

        // -----------------------------------------------------------------------
        // GetDateForFirstDayOfMonth
        // -----------------------------------------------------------------------
        public static DateTime GetDateForFirstDayOfMonth(DateTime oDateTime)
        {
            DateTime dtFirstDayOfMonth = new DateTime(
                    oDateTime.Year,
                    oDateTime.Month,
                    1
                    );

            return dtFirstDayOfMonth;
        }

        // -----------------------------------------------------------------------
        // GetDateForLastDayOfMonth
        // -----------------------------------------------------------------------
        public static DateTime GetDateForLastDayOfMonth(DateTime oDateTime)
        {
            DateTime oLastDateInMonth = new DateTime(
                    oDateTime.Year,
                    oDateTime.Month,
                    DateTime.DaysInMonth(oDateTime.Year, oDateTime.Month)
                    );

            return oLastDateInMonth;
        }


        // -----------------------------------------------------------------------
        // GetFirstDOW
        // Returns a the first day of the week for a given date. 
        // In this routine, Sunday is considered to be the first day of the 
        // However, the day considered to be the first day of the week may vary depending
        // upon culture. Cultural specific coding is not covered in this sample
        // -----------------------------------------------------------------------
        public static DateTime GetFirstDOW(DateTime dtDate)
        {
            DateTime FirstDayofWeek = dtDate;

            //CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
            switch (dtDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    FirstDayofWeek = dtDate;
                    break;
                case DayOfWeek.Monday:
                    FirstDayofWeek = dtDate.AddDays(-1);
                    break;
                case DayOfWeek.Tuesday:
                    FirstDayofWeek = dtDate.AddDays(-2);
                    break;
                case DayOfWeek.Wednesday:
                    FirstDayofWeek = dtDate.AddDays(-3);
                    break;
                case DayOfWeek.Thursday:
                    FirstDayofWeek = dtDate.AddDays(-4);
                    break;
                case DayOfWeek.Friday:
                    FirstDayofWeek = dtDate.AddDays(-5);
                    break;
                case DayOfWeek.Saturday:
                    FirstDayofWeek = dtDate.AddDays(-6);
                    break;

            }
            return FirstDayofWeek;

        }



        // -----------------------------------------------------------------------
        // GetLastDOW
        // Returns a the last day of the week for a given date. 
        // In this routine, Sunday is considered to be the last day of the 
        // However, the day considered to be the last day of the week may vary depending
        // upon culture. Cultural specific coding is not covered in this sample.
        // -----------------------------------------------------------------------
        public static DateTime GetLastDOW(DateTime dtDate)
        {
            DateTime LastDayofWeek = dtDate;
            //CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
            switch (dtDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    LastDayofWeek = dtDate.AddDays(6);
                    break;
                case DayOfWeek.Monday:
                    LastDayofWeek = dtDate.AddDays(5);
                    break;
                case DayOfWeek.Tuesday:
                    LastDayofWeek = dtDate.AddDays(4);
                    break;
                case DayOfWeek.Wednesday:
                    LastDayofWeek = dtDate.AddDays(3);
                    break;
                case DayOfWeek.Thursday:
                    LastDayofWeek = dtDate.AddDays(2);
                    break;
                case DayOfWeek.Friday:
                    LastDayofWeek = dtDate.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    LastDayofWeek = dtDate;
                    break;
            }

            return LastDayofWeek;

        }


    }
}
