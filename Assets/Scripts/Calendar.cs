using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Calendar : MonoBehaviour
{
    /// <summary>
    /// Cell or slot in the calendar. All the information each day should now about itself
    /// </summary>
    /// 
    public class ButtonExtras : MonoBehaviour
    {
        public Text buttonText; // assign this in the inspector
    }
    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;

        /// <summary>
        /// Constructor of Day
        /// </summary>
        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.obj = obj;
            UpdateColor(dayColor);
            UpdateDay(dayNum);
        }

        /// <summary>
        /// Call this when updating the color so that both the dayColor is updated, as well as the visual color on the screen
        /// </summary>
        public void UpdateColor(Color newColor)
        {
            obj.GetComponent<Image>().color = newColor;
            dayColor = newColor;
        }

        /// <summary>
        /// When updating the day we decide whether we should show the dayNum based on the color of the day
        /// This means the color should always be updated before the day is updated
        /// </summary>
        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if (dayColor == Color.white || dayColor == new Color32(168, 212, 148, 255))
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    /// <summary>
    /// All the days in the month. After we make our first calendar we store these days in this list so we do not have to recreate them every time.
    /// </summary>
    private List<Day> days = new List<Day>();

    /// <summary>
    /// Setup in editor since there will always be six weeks. 
    /// Try to figure out why it must be six weeks even though at most there are only 31 days in a month
    /// </summary>
    public Transform[] weeks;

    /// <summary>
    /// This is the text object that displays the current month and year
    /// </summary>
    public TextMeshProUGUI MonthAndYear;
   
    /// <summary>
    /// this currDate is the date our Calendar is currently on. The year and month are based on the calendar, 
    /// while the day itself is almost always just 1
    /// If you have some option to select a day in the calendar, you would want the change this objects day value to the last selected day
    /// </summary>
    public DateTime currDate = DateTime.Now;

    public TextMeshProUGUI ToDoListDate;

    /// <summary>
    /// In start we set the Calendar to the current date
    /// </summary>
    private void Start()
    {
        UpdateCalendar(DateTime.Now.Year, DateTime.Now.Month);
        if (ToDoListDate != null)
            ToDoListDate.text = "Events for\n" + string.Format("{0:MMMM dd, yyyy}", DateTime.Now);
    }

    /// <summary>
    /// Anytime the Calendar is changed we call this to make sure we have the right days for the right month/year
    /// </summary>
    void UpdateCalendar(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);
        currDate = temp;
        MonthAndYear.text = temp.ToString("MMMM") + " " + temp.Year.ToString();
        int startDay = GetMonthStartDay(year, month);
        int endDay = GetTotalNumberOfDays(year, month);


        ///Create the days
        ///This only happens for our first Update Calendar when we have no Day objects therefore we must create them

        if (days.Count == 0)
        {
            for (int w = 0; w < 6; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;
                    if (currDay < startDay || currDay - startDay >= endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.grey, weeks[w].GetChild(i).gameObject);
                    }
                    else
                    {
                        newDay = new Day(currDay - startDay, Color.white, weeks[w].GetChild(i).gameObject);
                    }
                    days.Add(newDay);
                }
            }
        }
        ///loop through days
        ///Since we already have the days objects, we can just update them rather than creating new ones
        else
        {
            for (int i = 0; i < 42; i++)
            {
                if (i < startDay || i - startDay >= endDay)
                {
                    days[i].UpdateColor(Color.grey);
                }
                else
                {
                    days[i].UpdateColor(Color.white);
                }

                days[i].UpdateDay(i - startDay);
            }
        }

        ///This just checks if today is on our calendar. If so, we highlight it in green
        if (DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days[(DateTime.Now.Day - 1) + startDay].UpdateColor(new Color32(168, 212, 148, 255));
        }

    }

    /// <summary>
    /// This returns which day of the week the month is starting on
    /// </summary>
    int GetMonthStartDay(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);

        //DayOfWeek Sunday == 0, Saturday == 6 etc.
        return (int)temp.DayOfWeek;
    }

    /// <summary>
    /// Gets the number of days in the given month.
    /// </summary>
    int GetTotalNumberOfDays(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    /// <summary>
    /// This either adds or subtracts one month from our currDate.
    /// The arrows will use this function to switch to past or future months
    /// </summary>
    public void SwitchMonth(int direction)
    {
        if (direction < 0)
        {
            currDate = currDate.AddMonths(-1);
        }
        else
        {
            currDate = currDate.AddMonths(1);
        }

        UpdateCalendar(currDate.Year, currDate.Month);
    }

    public TextMeshProUGUI inputDueDate;
    public void setText()
    {
        GameObject buttonPressed = EventSystem.current.currentSelectedGameObject;
        string day = buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text;
        if (day == "Add Task" || day == "Add Event")
        {
            inputDueDate.text =  string.Format("{0:MM/dd/yyyy}", DateTime.Now);
        }
        else if(day != "")
        {
            string[] MonthAndYearString = MonthAndYear.text.Split(' ');
            string month = convertMonthString(MonthAndYearString[0]);
            string year = MonthAndYearString[1];
            inputDueDate.text = month + "/" + day + "/" + year;
        }
    }


    public void setToDoListText()
    {
        GameObject buttonPressed = EventSystem.current.currentSelectedGameObject;
        string day = buttonPressed.GetComponentInChildren<TextMeshProUGUI>().text;
        if(day != "")
        {
            string[] MonthAndYearString = MonthAndYear.text.Split(' ');
            string month = MonthAndYearString[0];
            string year = MonthAndYearString[1];
            ToDoListDate.text = "Events for\n" + month + " " + day + ", " + year;
        }
    }

    public string convertMonthString(string month)
    {
        if (month == "January")
            return "01";
        else if (month == "February")
            return "02";
        else if (month == "March")
            return "03";
        else if (month == "April")
            return "04";
        else if (month == "May")
            return "05";
        else if (month == "June")
            return "06";
        else if (month == "July")
            return "07";
        else if (month == "August")
            return "08";
        else if (month == "September")
            return "09";
        else if (month == "October")
            return "10";
        else if (month == "November")
            return "11";
        else if (month == "December")
            return "12";
        else
            return "0";
    }
}
