using System;

namespace Assignment_02
{

    public enum Status{
            New,
            Active,
            Dropout,
            Graduated
        }
    public class Student
    {
        public Student(int id, DateTime end, DateTime start, DateTime grad, string name, string surname)
        {
            this.Id = id;
            this.GivenName = name;
            this.Surname = surname;
            this.StartDate = start;
            this.EndDate = end;
            this.GraduationDate = grad;

            var currentTime = DateTime.Now;

            if(EndDate < GraduationDate && DateTime.Now > EndDate)
            {

                this.Status = Status.Dropout;

            } else if (StartDate < DateTime.Now && DateTime.Now < StartDate.AddMonths(6))
            {

                this.Status = Status.New;

            } else if (DateTime.Now > GraduationDate && GraduationDate == EndDate){

                this.Status = Status.Graduated;

            } else {

                this.Status = Status.Active;

            }

        }
        public int Id{get; private set;}

        public string GivenName{get; set;}

        public string Surname{get; set;}

        public Status Status{get;}

        public DateTime StartDate{get; set;}

        public DateTime EndDate{get; set;}

        public DateTime GraduationDate{get; set;}

        public override string ToString(){
            return "This is Student " + Id.ToString() + ". Name is " + GivenName + " "
            + Surname + ". His current study status is: " + Status.ToString();
        }
    }
}
