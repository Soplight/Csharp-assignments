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
        public Student(int id){
            this.Id = id;

            var currentTime = DateTime.Now;

            if(DateTime.Compare(currentTime, StartDate) == 0)
            {

                this.Status = Status.New;

            } else if (DateTime.Compare(currentTime, EndDate) > 0)
            {

                this.Status = Status.Graduated;

            } else if (DateTime.Compare(currentTime, StartDate) > 0){

                this.Status = Status.Active;

            } else {

                this.Status = Status.Dropout;

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
