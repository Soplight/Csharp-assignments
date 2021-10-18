using System;
using Assignment4.Core;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//HUSK AT ET PUBLIC INTERFACE MED PUBLIC METODER, DER SKAL METODERNE OGSÅ VÆRE PUBLIC
namespace Assignment4.Entities
{
    public class TaskRepository : ITaskRepository
    {

        private readonly KanbanContext _context;//define kanbancontext

        public TaskRepository(KanbanContext context)//construct task repository
        {
            _context = context;
        }

        private static IReadOnlyCollection<string> convertTagsToStringCollection(ICollection<Tag> oldTags) 
        {
            var temp = new List<string>();
            foreach (Tag t in oldTags)
            {
                temp.Add(t.Name);
            }
            return temp;
        }

        private User getUserFromId(int? id)
        {

            /*var user = (_context.Users
                        .Include(u => u.Id == userid)
                        .Select(u => u)).First();*/

            var user = (from u in _context.Users
                       where u.Id == id
                       select u).First();

            return user;
        }
        public IReadOnlyCollection<TaskDTO> All()
        {

            var task = _context.Tasks.Include(task => task.Tags)
                        .Include(task => task.AssignedTo)
                        .Select(t => new TaskDTO {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            AssignedToId = t.AssignedTo == null ? null : t.AssignedTo.Id,
                            Tags = convertTagsToStringCollection(t.Tags),
                            State = t.State//ctrl space for at få mang. fields!
                        })
                        .ToList().AsReadOnly();//Tasks og deres reateret tags
            return task;

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="task"></param>
        /// <returns>The id of the newly created task</returns>
        public int Create(TaskDTO task) 
        {
           /* var tagCollection2 = (_context.Tags
                .Include(tags => (task.Tags.Contains(tags.Name)))
                .Select(tag => tag)).ToList();*/
           var taskTags = task.Tags;

           var tagCollection = (from tag in _context.Tags
                                 where taskTags.Contains(tag.Name)
                                 select tag).ToList();


            var t = new Task{
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Tags = tagCollection,
                AssignedTo = (task.AssignedToId == null ? null : getUserFromId(task.AssignedToId)),
                State = task.State
            };

            _context.Add(t);
            _context.SaveChanges();

            return t.Id;
        }

        public void Delete(int taskId) 
        { 
            var taskToBeDeleted = (from t in _context.Tasks
                       where t.Id == taskId
                       select t).First();

            _context.Tasks.Remove(taskToBeDeleted);
        }

        public TaskDetailsDTO FindById(int id) 
        {
            var task = (from t in _context.Tasks
                                 where t.Id == id
                                 select t).First();

            var taskDetailsDTO = new TaskDetailsDTO 
            {
                Id = task.Id,
                AssignedToEmail = task.AssignedTo.Email,
                AssignedToId = task.AssignedTo.Id,
                AssignedToName = task.AssignedTo.Name,
                Description = task.Description,
                State = task.State,
                Tags = convertTagsToStringCollection(task.Tags),
                Title = task.Title
            };

            return taskDetailsDTO;
        }

        public void Update(TaskDTO task) { Console.WriteLine("blep"); }

        public void Dispose(){
            {
                _context.Dispose();
            }
        }
    }
}
