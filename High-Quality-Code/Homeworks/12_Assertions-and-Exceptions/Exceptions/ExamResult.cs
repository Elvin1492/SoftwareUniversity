﻿using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "Grade can not be a negatie number.");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "Grade can not be a negatie number.");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("Max grade", "Max grade can not be less than Min grade.");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("Commetns can not be empty.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
