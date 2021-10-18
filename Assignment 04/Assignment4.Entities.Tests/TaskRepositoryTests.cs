using System;
using Xunit;
using Assignment4.Entities;
using Assignment4.Core;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;// to allow creation of new connections

namespace Assignment4.Entities.Tests
{
    public class TaskRepositoryTests : IDisposable
    {
        private readonly TaskRepository _repo;
        private readonly KanbanContext _context;

        public TaskRepositoryTests()//this is initialized when xUnit is run.
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();//To open the connection to a inmemory database
            var builder = new DbContextOptionsBuilder<KanbanContext>();
            builder.UseSqlite(connection);//tell mycontext to use this open connection
            var context = new KanbanContext(builder.Options);//tell the context to use these options
            context.Database.EnsureCreated();//Ensure the datbase exists and is created.

            //creation of task 1 and it's values
            var task1 = new Task
            {
                Id = 1,
                AssignedTo = null,
                Description = "Work on that game",
                State = State.Active,
                Tags = new List<Tag>(),
                Title = "Game work"
            };

            var usr1 = new User
            {
                Id = 1,
                Email = "damail@itu.dk",
                Name = "Gamerman",
                Tasks = new List<Task>(),
            };

            var tag1 = new Tag
            {
                Id = 1,
                Name = "Gaming",
                Tasks = new List<Task>()
            };

            task1.Tags.Add(tag1);
            task1.AssignedTo = usr1;

            tag1.Tasks.Add(task1);
            usr1.Tasks.Add(task1);

            //Creation of task 2 and it's values

            var task2 = new Task
            {
                Id = 2,
                AssignedTo = null,
                Description = "Work on that dank meme",
                State = Core.State.Resolved,
                Tags = new List<Tag>(),
                Title = "Meme work"
            };

            var usr2 = new User
            {
                Id = 2,
                Email = "bupbup@htomd.dk",
                Name = "Mememan",
                Tasks = new List<Task>(),
            };

            var tag2 = new Tag
            {
                Id = 2,
                Name = "Funny",
                Tasks = new List<Task>()
            };

            task2.Tags.Add(tag2);
            task2.AssignedTo = usr2;

            tag2.Tasks.Add(task2);
            usr2.Tasks.Add(task2);

            //Creation of task 3 and it's values
            var task3 = new Task
            {
                Id = 3,
                AssignedTo = null,
                Description = "Work on that serious thing",
                State = Core.State.New,
                Tags = new List<Tag>(),
                Title = "Serious work"
            };

            var usr3 = new User
            {
                Id = 3,
                Email = "Frickster@yyyy.de",
                Name = "Justman",
                Tasks = new List<Task>(),
            };


            var tag3 = new Tag
            {
                Id = 3,
                Name = "Serious",
                Tasks = new List<Task>()
            };

            task3.Tags.Add(tag3);
            task3.AssignedTo = usr3;

            tag3.Tasks.Add(task3);
            usr3.Tasks.Add(task3);

            context.Tasks.AddRange(task1, task2, task3);//add data //task2, 3
            context.Users.AddRange(usr1, usr2, usr3); //usr2,3
            context.Tags.AddRange(tag1, tag2, tag3); //tags2, 3
            context.SaveChanges();//save changes

            _context = context; //save context to _context readonly
            _repo = new TaskRepository(_context);// set repo (allows interaction with db) with defined _context
        }

        [Fact]
        public void Test_Readall_function()
        {
            //Arrange
            var taskdto1 = new TaskDTO
            {Id = 1, AssignedToId = 1, Description = "Work on that game", State = State.Active, Tags = new List<string>{"Gaming"}, Title = "Game work"};
            //Act
            var result = _repo.All();
            //Assert
            Assert.Equal(taskdto1.Id, result.First().Id);
            Assert.Equal(taskdto1.AssignedToId, result.First().AssignedToId);
            Assert.Equal(taskdto1.Description, result.First().Description);
            Assert.Equal(taskdto1.State, result.First().State);
            Assert.Equal(taskdto1.Tags.ElementAt(0), result.First().Tags.ElementAt(0));
            Assert.Equal(taskdto1.Title, result.First().Title);
        }

        [Fact]
        public void Test_Creation_Of_Task() 
        {
            //Arrange
             var AddedTaskDTO = new TaskDTO
            {Id = 4, AssignedToId = 3, Description = "Another serious task", State = State.Resolved, Tags = new List<string>{"Serious"}, Title = "Super serious task"};

            //act
            var result = _repo.Create(AddedTaskDTO);

            Assert.Equal(4, result);
        }


        [Fact]
        public void Test_Finding_Task_By_Id()
        {
            //Arrange
            var expectedDTO = new TaskDetailsDTO {
                Id = 2,
                AssignedToId = 2,
                AssignedToEmail = "bupbup@htomd.dk",
                AssignedToName = "Mememan",
                Description = "Work on that dank meme",
                State = Core.State.Resolved,
                Tags = new List<string>{"Funny"},
                Title = "Meme work" };
            //Act
            var result =_repo.FindById(2);
            //Assert
            Assert.Equal(expectedDTO.Id, result.Id);
            Assert.Equal(expectedDTO.AssignedToId, result.AssignedToId);
            Assert.Equal(expectedDTO.AssignedToEmail, result.AssignedToEmail);
            Assert.Equal(expectedDTO.AssignedToName, result.AssignedToName);
            Assert.Equal(expectedDTO.Description, result.Description);
            Assert.Equal(expectedDTO.State, result.State);
            Assert.Equal(expectedDTO.Tags, result.Tags);
            Assert.Equal(expectedDTO.Title, result.Title);
        }

        /*[Fact]
        public void Test_Task_Deletion() 
        {
            //Arrange
            _repo.Delete(3)
        }*/



        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
