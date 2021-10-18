using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Assignment4.Core;
namespace Assignment4.Entities
{
    public class TasksControllerTest
    {
        public TasksControllerTest(KanbanContext context_)
        {
            //context = context_;
            Seed(context_);
        }

        //public KanbanContext context { get;}

    public void Seed(KanbanContext context)
        {

            var usr1 = new User
            {
                Id = 1,
                Email = "damail@itu.dk",
                Name = "Gamerman",
                Tasks = new List<Task>(),
            };

            var usr2 = new User
            {
                Id = 2,
                Email = "bupbup@htomd.dk",
                Name = "Mememan",
                Tasks = new List<Task>(),
            };

            var usr3 = new User
            {
                Id = 3,
                Email = "Frickster@yyyy.de",
                Name = "Justman",
                Tasks = new List<Task>(),
            };

            var tag1 = new Tag
            {
                Id = 1,
                Name = "Gaming",
                Tasks = new List<Task>()
            };

            var tag2 = new Tag
            {
                Id = 2,
                Name = "Funny",
                Tasks = new List<Task>()
            };

            var tag3 = new Tag
            {
                Id = 3,
                Name = "Serious",
                Tasks = new List<Task>()
            };

            var task1 = new Task
            {
                Id = 1,
                AssignedTo = null,
                Description = "Work on that game",
                State = Core.State.Active,
                Tags = new List<Tag>(),
                Title = "Game work"
            };

            var task2 = new Task
            {
                Id = 2,
                AssignedTo = null,
                Description = "Work on that dank meme",
                State = Core.State.Resolved,
                Tags = new List<Tag>(),
                Title = "Meme work"
            };

            var task3 = new Task
            {
                Id = 3,
                AssignedTo = null,
                Description = "Work on that serious thing",
                State = Core.State.New,
                Tags = new List<Tag>(),
                Title = "Serious work"
            };
            //Users
            usr1.Tasks.Add(task1);

            usr2.Tasks.Add(task2);

            usr3.Tasks.Add(task3);

            //Tags
            tag1.Tasks.Add(task1);

            tag2.Tasks.Add(task2);

            tag3.Tasks.Add(task3);
            tag3.Tasks.Add(task1);

            //Tasks
            task1.Tags.Add(tag1);
            task1.Tags.Add(tag3);
            task1.AssignedTo = usr1;

            task2.Tags.Add(tag2);
            task2.AssignedTo = usr2;

            task3.Tags.Add(tag3);
            task3.AssignedTo = usr3;

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(task1, task2, task3);

            context.SaveChanges();
        }
    }
}
