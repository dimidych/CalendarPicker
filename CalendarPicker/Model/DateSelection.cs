using System;

namespace CalendarPicker.Model
{
    [Serializable]
    public class DateSelection
    {
        public DateTime[] SelectedDates { get; set; }
    }
}