using System;
public class WritingAssignment : Assignment
    {
        private string title;

        // Constructor
        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            this.title = title;
        }

        // Method to get writing information
        public string GetWritingInformation()
        {
            return $"{title} by {base.GetSummary().Split('-')[0].Trim()}";
        }
    }