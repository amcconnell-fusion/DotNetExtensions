using System;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void AdjustHour_hour_0_to_am()
        {
            var dateTime = new DateTime(2014, 7, 7, 0, 32, 46);
            var actual = dateTime.AdjustHour(TimeAmPm.Am);
            Assert.AreEqual(0, actual.Hour);
        }

        [Test]
        public void AdjustHour_hour_0_to_pm()
        {
            var dateTime = new DateTime(2014, 7, 7, 0, 32, 46);
            var actual = dateTime.AdjustHour(TimeAmPm.Pm);
            Assert.AreEqual(12, actual.Hour);
        }

        [Test]
        public void AdjustHour_hour_12_to_am()
        {
            var dateTime = new DateTime(2014, 7, 7, 12, 32, 46);
            var actual = dateTime.AdjustHour(TimeAmPm.Am);
            Assert.AreEqual(0, actual.Hour);
        }

        [Test]
        public void AdjustHour_hour_12_to_pm()
        {
            var dateTime = new DateTime(2014, 7, 7, 12, 32, 46);
            var actual = dateTime.AdjustHour(TimeAmPm.Pm);
            Assert.AreEqual(12, actual.Hour);
        }

        [Test]
        public void AdjustHour_hour_23_to_am()
        {
            var dateTime = new DateTime(2014, 7, 7, 23, 32, 46);
            var actual = dateTime.AdjustHour(TimeAmPm.Am);
            Assert.AreEqual(11, actual.Hour);
        }

        [Test]
        public void AdjustHour_hour_23_to_pm()
        {
            var dateTime = new DateTime(2014, 7, 7, 23, 32, 46);
            var actual = dateTime.AdjustHour(TimeAmPm.Pm);
            Assert.AreEqual(23, actual.Hour);
        }

        [Test]
        public void AdjustHour_hour_6_to_am()
        {
            var dateTime = new DateTime(2014, 7, 7, 6, 32, 46);
            var actual = dateTime.AdjustHour(TimeAmPm.Am);
            Assert.AreEqual(6, actual.Hour);
        }

        [Test]
        public void AdjustHour_hour_6_to_pm()
        {
            var dateTime = new DateTime(2014, 7, 7, 6, 32, 46);
            var actual = dateTime.AdjustHour(TimeAmPm.Pm);
            Assert.AreEqual(18, actual.Hour);
        }

        [Test]
        public void DateOfFirstDayInMonth_contains_no_time_component()
        {
            var expected = new DateTime(2064, 4, 1);
            var dateTime = new DateTime(2064, 4, 30, 22, 30, 40, 500);
            var actual = dateTime.DateOfFirstDayInMonth();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateOfLastDayInMonth_contains_no_time_component()
        {
            var expected = new DateTime(2064, 4, 30);
            var dateTime = new DateTime(2064, 4, 1, 22, 30, 40, 500);
            var actual = dateTime.DateOfLastDayInMonth();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateOfLastDayInMonth_leapYear()
        {
            var expected = new DateTime(2016, 2, 29);
            var dateTime = new DateTime(2016, 2, 1);
            var actual = dateTime.DateOfLastDayInMonth();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateOfLastDayInMonth_non_leapYear()
        {
            var expected = new DateTime(2014, 2, 28);
            var dateTime = new DateTime(2014, 2, 1);
            var actual = dateTime.DateOfLastDayInMonth();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBoundedDay_lower_bounding_applied()
        {
            var actual = DateTimeExtensions.GetBoundedDay(2014, 3, -2);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void GetBoundedDay_no_bounding_needed()
        {
            const int day = 4;
            var actual = DateTimeExtensions.GetBoundedDay(2014, 3, day);
            Assert.AreEqual(day, actual);
        }

        [Test]
        public void GetBoundedDay_upper_bounding_applied()
        {
            var actual = DateTimeExtensions.GetBoundedDay(2014, 3, 200);
            Assert.AreEqual(31, actual);
        }

        [Test]
        public void GetHourFor12HourClock_hour_0()
        {
            var dateTime = DateTime.Today;
            var actual = dateTime.GetHourFor12HourClock();
            Assert.AreEqual(12, actual);
        }

        [Test]
        public void GetHourFor12HourClock_hour_12()
        {
            var dateTime = new DateTime(2014, 7, 7, 12, 32, 46);
            var actual = dateTime.GetHourFor12HourClock();
            Assert.AreEqual(12, actual);
        }

        [Test]
        public void GetHourFor12HourClock_hour_22()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.GetHourFor12HourClock();
            Assert.AreEqual(10, actual);
        }

        [Test]
        public void GetTimeAmPm_Am()
        {
            var dateTime = new DateTime(2014, 7, 7, 11, 32, 46);
            var actual = dateTime.GetTimeAmPm();
            Assert.AreEqual(TimeAmPm.Am, actual);
        }

        [Test]
        public void GetTimeAmPm_Pm()
        {
            var dateTime = new DateTime(2014, 7, 7, 12, 32, 46);
            var actual = dateTime.GetTimeAmPm();
            Assert.AreEqual(TimeAmPm.Pm, actual);
        }

        [Test]
        public void SetDaySafe()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            const int newDay = 11;
            var actual = dateTime.SetDaySafe(newDay);
            Assert.AreEqual(newDay, actual.Day);
        }

        [Test]
        public void SetDaySafe_lower_bounding_applied()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetDaySafe(0);
            Assert.AreEqual(1, actual.Day);
        }

        [Test]
        public void SetDaySafe_preserves_hour()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetDaySafe(10);
            Assert.AreEqual(dateTime.Hour, actual.Hour);
        }

        [Test]
        public void SetDaySafe_preserves_minute()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetDaySafe(10);
            Assert.AreEqual(dateTime.Minute, actual.Minute);
        }

        [Test]
        public void SetDaySafe_preserves_month()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetDaySafe(10);
            Assert.AreEqual(dateTime.Month, actual.Month);
        }

        [Test]
        public void SetDaySafe_preserves_second()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetDaySafe(10);
            Assert.AreEqual(dateTime.Second, actual.Second);
        }

        [Test]
        public void SetDaySafe_preserves_year()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetDaySafe(10);
            Assert.AreEqual(dateTime.Year, actual.Year);
        }

        [Test]
        public void SetDaySafe_upper_bounding_applied()
        {
            var dateTime = new DateTime(2014, 2, 3, 22, 32, 46);
            var actual = dateTime.SetDaySafe(33);
            Assert.AreEqual(28, actual.Day);
        }

        [Test]
        public void SetHourSafe()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            const int newHour = 5;
            var actual = dateTime.SetHourSafe(newHour);
            Assert.AreEqual(newHour, actual.Hour);
        }

        [Test]
        public void SetHourSafe_lower_bounding_applied()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetHourSafe(-1);
            Assert.AreEqual(0, actual.Hour);
        }

        [Test]
        public void SetHourSafe_preserves_day()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetHourSafe(5);
            Assert.AreEqual(dateTime.Day, actual.Day);
        }

        [Test]
        public void SetHourSafe_preserves_minute()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetHourSafe(5);
            Assert.AreEqual(dateTime.Minute, actual.Minute);
        }

        [Test]
        public void SetHourSafe_preserves_month()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetHourSafe(5);
            Assert.AreEqual(dateTime.Month, actual.Month);
        }

        [Test]
        public void SetHourSafe_preserves_second()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetHourSafe(5);
            Assert.AreEqual(dateTime.Second, actual.Second);
        }

        [Test]
        public void SetHourSafe_preserves_year()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetHourSafe(5);
            Assert.AreEqual(dateTime.Year, actual.Year);
        }

        [Test]
        public void SetHourSafe_upper_bounding_applied()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetHourSafe(100);
            Assert.AreEqual(23, actual.Hour);
        }

        [Test]
        public void SetMinuteSafe()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            const int newMinute = 5;
            var actual = dateTime.SetMinuteSafe(newMinute);
            Assert.AreEqual(newMinute, actual.Minute);
        }

        [Test]
        public void SetMinuteSafe_lower_bounding_applied()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMinuteSafe(-1);
            Assert.AreEqual(0, actual.Minute);
        }

        [Test]
        public void SetMinuteSafe_preserves_day()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMinuteSafe(5);
            Assert.AreEqual(dateTime.Day, actual.Day);
        }

        [Test]
        public void SetMinuteSafe_preserves_hour()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMinuteSafe(5);
            Assert.AreEqual(dateTime.Hour, actual.Hour);
        }

        [Test]
        public void SetMinuteSafe_preserves_month()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMinuteSafe(5);
            Assert.AreEqual(dateTime.Month, actual.Month);
        }

        [Test]
        public void SetMinuteSafe_preserves_second()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMinuteSafe(5);
            Assert.AreEqual(dateTime.Second, actual.Second);
        }

        [Test]
        public void SetMinuteSafe_preserves_year()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMinuteSafe(5);
            Assert.AreEqual(dateTime.Year, actual.Year);
        }

        [Test]
        public void SetMinuteSafe_upper_bounding_applied()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMinuteSafe(60);
            Assert.AreEqual(59, actual.Minute);
        }

        [Test]
        public void SetMonthSafe()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            const Month newMonth = Month.August;
            var actual = dateTime.SetMonthSafe(newMonth);
            Assert.AreEqual((int) newMonth, actual.Month);
        }

        [Test]
        public void SetMonthSafe_adjusts_day()
        {
            var dateTime = new DateTime(2014, 1, 31, 22, 32, 46);
            var actual = dateTime.SetMonthSafe(Month.September);
            Assert.AreEqual(30, actual.Day);
        }

        [Test]
        public void SetMonthSafe_adjusts_day_for_leapYear()
        {
            var dateTime = new DateTime(2014, 1, 29, 22, 32, 46);
            var actual = dateTime.SetMonthSafe(Month.February);
            Assert.AreEqual(28, actual.Day);
        }

        [Test]
        public void SetMonthSafe_preserves_day()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMonthSafe(Month.August);
            Assert.AreEqual(dateTime.Day, actual.Day);
        }

        [Test]
        public void SetMonthSafe_preserves_hour()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMonthSafe(Month.August);
            Assert.AreEqual(dateTime.Hour, actual.Hour);
        }

        [Test]
        public void SetMonthSafe_preserves_minute()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMonthSafe(Month.August);
            Assert.AreEqual(dateTime.Minute, actual.Minute);
        }

        [Test]
        public void SetMonthSafe_preserves_second()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMonthSafe(Month.August);
            Assert.AreEqual(dateTime.Second, actual.Second);
        }

        [Test]
        public void SetMonthSafe_preserves_year()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetMonthSafe(Month.August);
            Assert.AreEqual(dateTime.Year, actual.Year);
        }

        [Test]
        public void SetSecondSafe()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            const int newSecond = 5;
            var actual = dateTime.SetSecondSafe(newSecond);
            Assert.AreEqual(newSecond, actual.Second);
        }

        [Test]
        public void SetSecondSafe_lower_bounding_applied()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetSecondSafe(-1);
            Assert.AreEqual(0, actual.Second);
        }

        [Test]
        public void SetSecondSafe_preserves_day()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetSecondSafe(5);
            Assert.AreEqual(dateTime.Day, actual.Day);
        }

        [Test]
        public void SetSecondSafe_preserves_hour()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetSecondSafe(5);
            Assert.AreEqual(dateTime.Hour, actual.Hour);
        }

        [Test]
        public void SetSecondSafe_preserves_minute()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetSecondSafe(5);
            Assert.AreEqual(dateTime.Minute, actual.Minute);
        }

        [Test]
        public void SetSecondSafe_preserves_month()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetSecondSafe(5);
            Assert.AreEqual(dateTime.Month, actual.Month);
        }

        [Test]
        public void SetSecondSafe_preserves_year()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetSecondSafe(5);
            Assert.AreEqual(dateTime.Year, actual.Year);
        }

        [Test]
        public void SetSecondSafe_upper_bounding_applied()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetSecondSafe(60);
            Assert.AreEqual(59, actual.Second);
        }

        [Test]
        public void SetYearSafe()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            const int newYear = 2016;
            var actual = dateTime.SetYearSafe(newYear);
            Assert.AreEqual(newYear, actual.Year);
        }

        [Test]
        public void SetYearSafe_adjusts_day_for_leapYear()
        {
            var dateTime = new DateTime(2016, 2, 29, 7, 22, 32, 46);
            var actual = dateTime.SetYearSafe(2015);
            Assert.AreEqual(28, actual.Day);
        }

        [Test]
        public void SetYearSafe_lower_bounding_applied()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetYearSafe(0);
            Assert.AreEqual(1, actual.Year);
        }

        [Test]
        public void SetYearSafe_preserves_day()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetYearSafe(2020);
            Assert.AreEqual(dateTime.Day, actual.Day);
        }

        [Test]
        public void SetYearSafe_preserves_hour()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetYearSafe(2015);
            Assert.AreEqual(dateTime.Hour, actual.Hour);
        }

        [Test]
        public void SetYearSafe_preserves_minute()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetYearSafe(2015);
            Assert.AreEqual(dateTime.Minute, actual.Minute);
        }

        [Test]
        public void SetYearSafe_preserves_month()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetYearSafe(2020);
            Assert.AreEqual(dateTime.Month, actual.Month);
        }

        [Test]
        public void SetYearSafe_preserves_second()
        {
            var dateTime = new DateTime(2014, 7, 7, 22, 32, 46);
            var actual = dateTime.SetYearSafe(2015);
            Assert.AreEqual(dateTime.Second, actual.Second);
        }

        [Test]
        public void ToEpoch_post_Unix()
        {
            const long numberOfSecondsSinceBeginningOfUnixEpoch = 432000;
            var dateTime = new DateTime(1970, 1, 6);
            var actual = dateTime.ToEpoch();
            Assert.AreEqual(numberOfSecondsSinceBeginningOfUnixEpoch, actual);
        }

        [Test]
        public void ToEpoch_pre_Unix()
        {
            const long numberOfSecondsUntilBeginningOfUnixEpoch = -86400;
            var dateTime = new DateTime(1969, 12, 31);
            var actual = dateTime.ToEpoch();
            Assert.AreEqual(numberOfSecondsUntilBeginningOfUnixEpoch, actual);
        }

        [Test]
        public void ToUrlFriendlyDate_converts_date()
        {
            const string expected = "2013-02-13";
            var actual = DateTime.Parse(expected).ToUrlFriendlyDate();
            Assert.AreEqual(expected, actual);
        }
    }
}